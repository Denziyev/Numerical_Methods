namespace Lagrange_Interpolation_Polynomial.Data
{
    public class LagrangeClass
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
                        temppoly += $"((x-{datatable[j, 0]})/({datatable[i, 0]}-{datatable[j, 0]}))";
                    }
                }
                resultpoly+= $" + {temppoly}{datatable[i,1]}";
            }

            resultpoly = resultpoly.Remove(0, 1).Insert(0, " ");
            Console.WriteLine("Lagrange Interpolating Polynomial: ");
            Console.WriteLine(resultpoly);
        }

        public  static void interpolate( double[,] datatable, int number_of_points)
        {
            double result = 0;
            Console.WriteLine("Enter the value of x:");
            double x=double.Parse(Console.ReadLine());
            for (int i = 0; i < number_of_points; i++)
            {
                double term = datatable[i,1];
                for (int j = 0; j < number_of_points; j++)
                {
                    if (j != i)
                    {
                        term = term * (x - datatable[j,0]) / (double)(datatable[i,0] - datatable[j,0]);
                    }
                }
                result += term;
            }
            Console.WriteLine($"Result of f(x) = {result}");

        }
    }
}
