using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inverse_Interpolation_Polynomial.Data
{
    public class InverseClass
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

        public static void showpolynomial(double[,] datatable, int number_of_points)
        {
            string resultpoly = "";
            string term = $" ";
            for (int i = 0; i < number_of_points; i++)
            {

                string temppoly = "";

                for (int j = 0; j < number_of_points; j++)
                {
                    if (j != i)
                    {
                        temppoly += $"((y-{datatable[j, 1]})/({datatable[i, 1]}-{datatable[j, 1]}))";
                    }
                }
                resultpoly += $" + {temppoly}{datatable[i, 0]}";
            }
            Console.WriteLine("Lagrange Interpolating Polynomial: ");
            Console.WriteLine(resultpoly);
        }

        public static void interpolate(double[,] datatable, int number_of_points)
        {
            double result = 0;
            Console.WriteLine("Enter the value of y:");
            double y = double.Parse(Console.ReadLine());
            for (int i = 0; i < number_of_points; i++)
            {
                double term = datatable[i, 0];
                for (int j = 0; j < number_of_points; j++)
                {
                    if (j != i)
                    {
                        term = term * (y - datatable[j, 1]) / (double)(datatable[i, 1] - datatable[j, 1]);
                    }
                }
                result += term;
            }
            Console.WriteLine($"Result of x = {result}");

        }
    }
}
   
