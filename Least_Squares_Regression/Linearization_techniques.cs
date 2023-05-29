using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Least_Squares_Regression
{
    public class Linearization_techniques
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

        public static void Result_Non_Linear_Model(double[,] datatable)
        {
            int size= datatable.GetLength(0);
            double[] log_X_Values = new double[size];
            double[] log_Y_Values = new double[size];

            for (int i = 0; i < size; i++)
            {
                log_X_Values[i] = Math.Log10(datatable[i,0]);
                log_Y_Values[i] = Math.Log10(datatable[i,1]);
            }

            double slope, intercept;
            LinearRegression(log_X_Values, log_Y_Values, out slope, out intercept);

            Console.WriteLine($"Linear equation: y = {Math.Exp(intercept):0.###} * x^{slope:0.###}");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the value of x: ");
            double x=double.Parse(Console.ReadLine());
            Console.WriteLine($"Result:   f({x})={Math.Exp(intercept) * Math.Pow(x, slope)}");
        }

        public static void Result_exponential_Model(double[,] datatable)
        {
            int size = datatable.GetLength(0);
            double[] ln_X_Values = new double[size];
            double[] ln_Y_Values = new double[size];
            double[] X_values= new double[size];
            for(int i = 0;i < size; i++)
            {
                X_values[i] = datatable[i,0];
                ln_X_Values[i] = Math.Log(datatable[i,0]);
                ln_Y_Values[i] = Math.Log(datatable[i,1]);
            }

            double slope, intercept;
            LinearRegression(X_values, ln_Y_Values, out slope,out intercept);
            Console.WriteLine($"Linear equation: y = {Math.Exp(intercept):0.###} * e^({slope:0.###}x)");
            Console.WriteLine(" ");
            Console.WriteLine("Enter the value of x: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine($"Result:   f({x})={Math.Exp(intercept) * Math.Pow(Math.E, x*slope)}");
        }

        static void LinearRegression(double[] xValues, double[] yValues, out double slope, out double intercept)
        {
            double sumX = 0, sumY = 0, sumXY = 0, sumXX = 0;
            double n = xValues.Length;

            for (int i = 0; i < n; i++)
            {
                double x = xValues[i];
                double y = yValues[i];

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumXX += x * x;
            }


            slope = (n * sumXY - sumX * sumY) / (n * sumXX - sumX * sumX);
            intercept = (sumY - slope * sumX) / n;
        }

    }
}
