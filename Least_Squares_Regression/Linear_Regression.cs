using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Least_Squares_Regression
{
    public class Linear_Regression
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

        public static void Result(double[,] datatable)
        {
            int n=datatable.GetLength(0);  //number of points
            int m = 1;  //Because this is linear 
            double sum_of_prod_of_xi_and_yi = 0;
            double sum_of_square_of_xi = 0;
            double sum_of_xi= 0;
            double sum_of_yi= 0;
            for(int i = 0; i < n; i++)
            {
                sum_of_prod_of_xi_and_yi += (datatable[i, 0] * datatable[i, 1]);
                sum_of_square_of_xi += (datatable[i, 0] * datatable[i, 0]);
                sum_of_xi += (datatable[i, 0]);
                sum_of_yi += (datatable[i, 1]);
            }
            double means_of_xi = sum_of_xi / n;
            double means_of_yi=sum_of_yi / n;

            double a1=((n*sum_of_prod_of_xi_and_yi)-(sum_of_xi*sum_of_yi))/((n*sum_of_square_of_xi)-(sum_of_xi*sum_of_xi));
            double a0 = means_of_yi - (a1 * means_of_xi);

            Console.WriteLine($"Result: y={a0} + {a1}x");


        }

      


    }
}
