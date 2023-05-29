using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spline_Interpolation_Polynomial.Data
{
     public class Cubic_Spline
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
        public void Spline(double[,] datatable, int n, out double yu, out double dy, out double d2y)
            {
            double[] x=new double[datatable.GetLength(0)];
            double[] y = new double[datatable.GetLength(0)];

            for (int i = 0;i < n;i++)
            {
                x[i] = datatable[i,0];
                y[i]= datatable[i,1];
            }

            double[] e = new double[n];
                double[] f = new double[n];
                double[] g = new double[n];
                double[] r = new double[n];

                Tridiag(x, y, n, out e, out f, out g, out r);
                double[] d2x = new double[n];
                Decomp(e, f, g, n - 1);
                Subst(e, f, g, r, n - 1, d2x);
            Console.WriteLine("Enter the value of x:");
            double xu=double.Parse(Console.ReadLine());
            Interpol(x, y, n, d2x, xu, out yu, out dy, out d2y);
            }

            private void Tridiag(double[] x, double[] y, int n, out double[] e, out double[] f, out double[] g, out double[] r)
            {
                e = new double[n];
                f = new double[n];
                g = new double[n];
                r = new double[n];

                double[] h = new double[n - 1];
                double[] p = new double[n - 1];
                double[] q = new double[n - 1];

                for (int i = 0; i < n - 1; i++)
                {
                    h[i] = x[i + 1] - x[i];
                    p[i] = 6 * (y[i + 1] - y[i]) / h[i];
                }

                q[0] = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    q[i] = h[i - 1] / (h[i - 1] + h[i]);
                }

                e[0] = 0;
                f[0] = 2;
                g[0] = 1;
                r[0] = p[0];

                for (int i = 1; i < n - 1; i++)
                {
                    e[i] = q[i - 1];
                    f[i] = 2 + q[i - 1] + (1 - q[i]);
                    g[i] = 1 - q[i];
                    r[i] = p[i];
                }

                e[n - 1] = 1;
                f[n - 1] = 2;
                g[n - 1] = 0;
                r[n - 1] = p[n - 2];
            }

            private void Decomp(double[] e, double[] f, double[] g, int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    double factor = e[i] / f[i - 1];
                    f[i] -= factor * g[i - 1];
                    e[i] = factor;
                }
            }

            private void Subst(double[] e, double[] f, double[] g, double[] r, int n, double[] d2x)
            {
                for (int i = 1; i <= n; i++)
                {
                    r[i] -= e[i] * r[i - 1];
                }

                d2x[n] = r[n] / f[n];

                for (int i = n - 1; i >= 0; i--)
                {
                    d2x[i] = (r[i] - g[i] * d2x[i + 1]) / f[i];
                }
            }

            private void Interpol(double[] x, double[] y, int n, double[] d2x, double xu, out double yu, out double dy, out double d2y)
            {
                int i = 1;
                while (i < n && xu >= x[i])
                {
                    i++;
                }

                double h = x[i] - x[i - 1];
                double c1 = (d2x[i] - d2x[i - 1]) / (6 * h);
                double c2 = d2x[i - 1] / 2;
                double c3 = (y[i] - y[i - 1]) / h - (2 * h * d2x[i - 1] + h * d2x[i]) / 6;
                double c4 = y[i - 1];

                double t = xu - x[i - 1];
                yu = c1 * Math.Pow(t, 3) + c2 * Math.Pow(t, 2) + c3 * t + c4;
                dy = 3 * c1 * Math.Pow(t, 2) + 2 * c2 * t + c3;
                d2y = 6 * c1 * t + 2 * c2;
            }
        

    }
}
