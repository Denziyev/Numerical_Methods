using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton_s_interpolating_polynomial.Data
{
    public static class Interpolation
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

        private static double[] b(double[,]datatable,int numberofpoints)   //the set of coefficient
        {
            double[] coefficients = new double[numberofpoints];
            
            coefficients[0] = datatable[0,1];
            
            for (int j = 1; j < numberofpoints; j++)
            {
                coefficients[j]=f(datatable, j, 0);
            }            

            return coefficients;
        }

        private static double f(double[,] datatable,int firstindex,int lastindex)   // i-th coeficient
        {
            if (firstindex - lastindex == 1)
            {
                return (datatable[firstindex, 1] - datatable[lastindex, 1]) / (datatable[firstindex, 0] - datatable[lastindex, 0]);
            }
            
            return (f(datatable, firstindex, lastindex+1)-f(datatable,firstindex-1,lastindex))/ (datatable[firstindex, 0] - datatable[lastindex, 0]);
        }

        public static void showcoefficient(int number_of_points, double[,] datatable)  //display the coefficients
        {
            string temppoly = "";
            string resultpolynomial="";
            string coefficientpolynomial = "";
            for(int i = 0; i <= number_of_points-1; i++)
            {
                temppoly = "";
                double tempp = b(datatable, number_of_points)[i];
                if (tempp < 0)
                {
                coefficientpolynomial=$"{tempp}";
                }
                else
                {
                    coefficientpolynomial = $"+{tempp}";
                }
                for(int j = 0; j < i; j++) {
                    if (datatable[j,0] < 0) { 
                    temppoly += $"(x+{-datatable[j, 0]})";
                    }
                    else
                    {
                        temppoly += $"(x-{datatable[j, 0]})";
                    }                
                }
                resultpolynomial += $"{coefficientpolynomial}{temppoly}";
            }

            resultpolynomial= resultpolynomial.Remove(0,1).Insert(0," ");
            Console.WriteLine("Newton interpolating polynomial:");
            Console.WriteLine(resultpolynomial);
        }

        public static double[] variableproducts(double[,] datatable,int n)     //(x-x0)(x-x1)(x-x2)....(x-x(n-1))
        {
            double[] variables = new double[n];
            Console.WriteLine("Enter the value of x:");
            double x = double.Parse(Console.ReadLine());
            variables[0] =1;

            
            for (int j = 1; j <n; j++)
            {
                variables[j] = variables[j - 1] * (x - datatable[j-1,0]);
            }

            return variables;
        }

        public static void showresult(double[,] datatable, int n, double[] variablepro)   //The value of Polynomial function in x
        {

            double result = 0;
            for(int i = 0; i < n; i++)
            {
                result += (b(datatable, n)[i] * variablepro[i]);
            }
            Console.WriteLine($"Result of f(x) = {result}");

        }

    }
}
   

