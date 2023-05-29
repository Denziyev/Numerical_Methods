using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation_Polynomial.Data
{
    public  class Quadratic_Spline
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

        //coefficentmatrix[datatable.getlenth(0)*3-4]

        public static void check(double[,] datatable)
        {
            int size = (datatable.GetLength(0) * 3) - 4;
            double[,] coefficientmatrix=new double[size,size];
            double[,] rightsidee=new double[size,1];
                coefficientmatrix[0, 0] = datatable[1,0];
                coefficientmatrix[0, 1] = datatable[1,1];
            for(int i = 2; i < size; i++)
            {
                coefficientmatrix[0,i] = 0;
            }
            //for(int i=2;)
        }


    }
}
