using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Carlo_Integration.Data
{
    public class Calculate_Area
    {
        static double F(double x)
        {
            return Math.Sin(x);
        }

        static double G(double x)
        {
            return Math.Log(x + 2);
        }

        public static double MonteCarloArea(double a, double b, int numPoints)
        {
            Random random = new Random();
            int count = 0;

            for (int i = 0; i < numPoints; i++)
            {
                double x = random.NextDouble() * (b - a) + a;
                double y = random.NextDouble() * (F(x) - G(x)) + G(x);

                if (y >= 0)
                {
                    count++;
                }
            }

            double area = (count / (double)numPoints) * (b - a) * (F(b) - G(b));
            return area;
        }
    }
}
