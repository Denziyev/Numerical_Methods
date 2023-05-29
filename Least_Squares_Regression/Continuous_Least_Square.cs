using MathNet.Numerics.LinearRegression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Least_Squares_Regression
{
    public class Continuous_Least_Square
    {
       

        public static void FitContinuousLeastSquares(double First,double last,double step)
        {
            int n =(int) ((last - First)/step);
            double[] x = new double[n];
            double[] y =new double[n];

            double valueofx = First;
            int index = 0;
            for (index = 0, valueofx = First; index < n && valueofx <= last; valueofx += step, index++)
            {
                x[index] = valueofx;
                y[index]=1/valueofx;
            }

            // Perform continuous least squares fitting
            (double A, double B) coefficients = SimpleRegression.Fit(x, y);

            // Extract the intercept and slope from the coefficients tuple
            double intercept = coefficients.A;
            double slope = coefficients.B;

            // Print the fitted parameters
            Console.WriteLine($"y={slope}x+{intercept}");
            Console.WriteLine("Enter the value of x: ");
            double xvalue=double.Parse(Console.ReadLine());
            double resultt=slope*xvalue+intercept;
            Console.WriteLine($"Result: y({xvalue})={resultt}");
        }
    }
}
