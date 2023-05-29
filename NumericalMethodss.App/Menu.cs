
using Fourier_Transform.Data;
using Inverse_Interpolation_Polynomial.Data;
using Lagrange_Interpolation_Polynomial.Data;
using Least_Squares_Regression;
using Monte_Carlo_Integration.Data;
using Newton_s_interpolating_polynomial.Data;
using Power_Method.Data;
using Spline_Interpolation_Polynomial.Data;

namespace Menu
{
    public static class Methods
    {
        public static void NewtonInterpolationMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());

            double[,] Datatable = Interpolation.setdatatable(number_of_points);                      //x ve y-leri userden alib data table qururuq

            Interpolation.showcoefficient(number_of_points, Datatable);                            //display the coefficients

            double[] variableprod = Interpolation.variableproducts(Datatable, number_of_points);   //(x-x0)(x-x1)(x-x2)....(x-x(n-1))

            Interpolation.showresult(Datatable, number_of_points, variableprod);                    //The value of Polynomial function in x
        }

        public static void LagrangeInterpolationMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());

            double[,] Datatable = LagrangeClass.setdatatable(number_of_points);
            LagrangeClass.showpolynomial(Datatable, number_of_points);
            LagrangeClass.interpolate(Datatable, number_of_points);
        }


        public static void InverseInterpolationMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());

            double[,] Datatable = InverseClass.setdatatable(number_of_points);
            InverseClass.showpolynomial(Datatable, number_of_points);
            InverseClass.interpolate(Datatable, number_of_points);
        }

        public static void SplineInterpolationMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());
            Console.WriteLine("1.Linear Spline Interpolation");
            Console.WriteLine("2.Quadratic Spline Interpolation");
            Console.WriteLine("3.Cubic Spline Interpolation");
            int request = int.Parse(Console.ReadLine());
            switch (request)
            {
                case 1:
                    double[,] Datatable = Linear_Spline.setdatatable(number_of_points);
                    Console.WriteLine(" ");
                    Linear_Spline.ShowResult(Datatable);
                    break;
                case 3:
                    Datatable = Linear_Spline.setdatatable(number_of_points);
                    Console.WriteLine(" ");
                    

                    Cubic_Spline spline = new Cubic_Spline();
                    spline.Spline(Datatable, Datatable.GetLength(0), out double yu, out double dy, out double d2y);

                    Console.WriteLine($"Interpolated value at xu: {yu}");
                    Console.WriteLine($"Derivative at xu: {dy}");
                    Console.WriteLine($"Second derivative at xu: {d2y}");
                    break;
            }
        }
        public static void LinearRegressionMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());

            double[,] Datatable = Linear_Regression.setdatatable(number_of_points);
            Console.WriteLine(" ");
            Linear_Regression.Result(Datatable);

        }

        public static void LinearizationTechniqueMenu()
        {
            Console.WriteLine("Enter the number of points");
            int number_of_points = int.Parse(Console.ReadLine());

            double[,] Datatable = Linearization_techniques.setdatatable(number_of_points);
            Console.WriteLine(" ");
            Console.WriteLine("1.Exponential model or 2.Non-linear model?");
            int request=int.Parse(Console.ReadLine());
            switch (request)
            {
                case 1:
                   Linearization_techniques.Result_exponential_Model(Datatable);
                    break;
                case 2:
                    Linearization_techniques.Result_Non_Linear_Model(Datatable);
                    break;

            }

        }

        public static void ContinuousLeastSquareMenu()
        {
            Console.WriteLine("Enter the first number: ");
            double First = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the last number: ");
            double last=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the step size: ");
            double step=double.Parse(Console.ReadLine());
            Console.WriteLine(" ");
            Continuous_Least_Square.FitContinuousLeastSquares(First,last,step);
        }

        public static void MonteCarloAreaMenu()
        {
            Console.WriteLine("Enter Lower bound of the interval: ");
            double a=Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Upper bound of the interval: ");
            double b = double.Parse(Console.ReadLine());
            
            int numPoints = 1000000;  // Number of random points to generate

            double area = Calculate_Area.MonteCarloArea(a,b,numPoints);
            if (area < 0)
            {
                area = -area;
            }
            Console.WriteLine("Approximate area: " + area);
        }

        public static void FourierTransformMenu()
        {

            int[] pCoeffs = { 1, 3, 4, 0, -3 };
            int[] qCoeffs = { 1, -1, 2, 3, 0, 0, 0 };

            // Perform polynomial multiplication using DFT
            int[] resultCoeffs = ClassFourierTransform.PolynomialMultiplicationn(pCoeffs, qCoeffs);

           // Print the resulting polynomial
           int resultDeg = resultCoeffs.Length - 1;
            string resultStr = "";

            for (int i = resultDeg; i >= 0; i--)
            {
                if (resultCoeffs[i] != 0)
                {
                    if (resultStr != "")
                        resultStr += " + ";

                    resultStr += $"{resultCoeffs[i]}*x^{i}";
                }
            }

            Console.WriteLine("The product of p(x) and q(x) is: " + resultStr);
        }


        public static void PowerMethodMenu()
        {
            double[,] matrix = {
            { 0.987, 0.4, -0.48 },
            { -0.079, 0.5, -0.47 },
            { 0.082, 0.4, 0.418 }
        };

            // Set the number of iterations
            int maxIterations = 100;

            // Set the tolerance for convergence
            double tolerance = 1e-6;

            // Perform power method to find eigenvalues and eigenvectors
            EigenResult result = EigenValuesandEigenVectors.PowerMethodEigen(matrix, maxIterations, tolerance);

            // Display the eigenvalues and eigenvectors
            Console.WriteLine("Eigenvalues:");
            foreach (double eigenvalue in result.Eigenvalues)
            {
                Console.WriteLine(eigenvalue);
            }

            Console.WriteLine("\nEigenvectors:");
            for (int i = 0; i < result.Eigenvectors.GetLength(0); i++)
            {
                Console.Write("Eigenvalue {0}: ", result.Eigenvalues[i]);
                for (int j = 0; j < result.Eigenvectors.GetLength(1); j++)
                {
                    Console.Write(result.Eigenvectors[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
    }
}