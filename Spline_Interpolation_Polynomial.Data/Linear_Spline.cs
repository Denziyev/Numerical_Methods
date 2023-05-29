using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation_Polynomial.Data
{
    public class Linear_Spline
    {

        public static double[,] setdatatable(int number_of_points)  //x ve y-leri userden alib data table qururuq
        {

            double[,] datatable = new double[number_of_points, 2];
            for (int i = 0; i < number_of_points; i++)
            {
                Console.WriteLine($"Enter x{i}");
                double xofpoint = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter y{i}");
                double yofpoint = double.Parse(Console.ReadLine());
                datatable[i, 0] = xofpoint;
                datatable[i, 1] = yofpoint;
            }
            Console.WriteLine("Data table is created succesfully");
            return datatable;
        }

        public static double slopes(double[,] datatable,int index) 
        {
            double[] result = new double[datatable.GetLength(0)-1];
            for (int i = 0;i < datatable.GetLength(0)-1; i++)
            {
                result[i] = (double)(datatable[i+1, 1] - datatable[i , 1]) / (datatable[i+1, 0] - datatable[i,0]);
            }
             return result[index];
        }

        public static void printfunction(double[,] datatable)
        {
            string polynom = "";
            for(int i = 0;i < datatable.GetLength(0) - 1; i++)
            {
                polynom += $"f(x)={datatable[i, 1]}+{slopes(datatable, i)}(x-{datatable[i, 0]})        {datatable[i, 0]}<=x<={datatable[i+1,0]}\n";
            }
            Console.WriteLine(polynom);
        }

        public static void ShowResult(double[,] datatable)
        {
            Console.WriteLine("Enter the value of x: ");
            double x=double.Parse(Console.ReadLine());
            double result;
            for(int i = 0; i < datatable.GetLength(0)-1; i++)
            {
                if (x >= datatable[i,0] && x <= datatable[i + 1, 0])
                {
                    result=datatable[i, 1] + (slopes(datatable, 1) * (x - datatable[1, 0]));
                   
                            Console.WriteLine($"The value of f({x}):{result}");
                    break;
                }
            }
        }

    }
}
