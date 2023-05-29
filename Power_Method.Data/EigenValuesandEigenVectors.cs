using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Power_Method.Data
{
    public class EigenValuesandEigenVectors
    {
        public static EigenResult PowerMethodEigen(double[,] matrix, int maxIterations, double tolerance)
        {
            int n = matrix.GetLength(0);

            // Initialize the initial vector x0
            double[] x0 = Enumerable.Repeat(1.0, n).ToArray();

            // Normalize x0
            double[] x = NormalizeVector(x0);

            // Initialize the eigenvalues and eigenvectors arrays
            double[] eigenvalues = new double[n];
            double[,] eigenvectors = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                double lambdaPrev = 0.0;
                double lambda = 1.0;

                // Perform iterations until convergence or maxIterations reached
                int iteration = 0;
                while (Math.Abs(lambda - lambdaPrev) > tolerance && iteration < maxIterations)
                {
                    // Store the previous eigenvalue
                    lambdaPrev = lambda;

                    // Compute the matrix-vector product
                    double[] y = MultiplyMatrixVector(matrix, x);

                    // Update the vector x
                    x = NormalizeVector(y);

                    // Compute the eigenvalue estimate
                    lambda = DotProduct(x, y);

                    iteration++;
                }

                // Store the eigenvalue and eigenvector
                eigenvalues[i] = lambda;
                for (int j = 0; j < n; j++)
                {
                    eigenvectors[i, j] = x[j];
                }

                // Deflate the matrix by removing the found eigenvector
                matrix = DeflateMatrix(matrix, x, lambda);
            }

            return new EigenResult(eigenvalues, eigenvectors);
        }

        static double[] NormalizeVector(double[] vector)
        {
            double norm = Math.Sqrt(DotProduct(vector, vector));
            return vector.Select(x => x / norm).ToArray();
        }

        static double DotProduct(double[] vector1, double[] vector2)
        {
            return vector1.Zip(vector2, (x, y) => x * y).Sum();
        }

        static double[] MultiplyMatrixVector(double[,] matrix, double[] vector)
        {
            int n = matrix.GetLength(0);
            double[] result = new double[n];

            for (int i = 0; i < n; i++)
            {
                double sum = 0.0;
                for (int j = 0; j < n; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }
                result[i] = sum;
            }

            return result;
        }

        static double[,] DeflateMatrix(double[,] matrix, double[] eigenvector, double eigenvalue)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrix[i, j] - eigenvalue * eigenvector[i] * eigenvector[j];
                }
            }

            return result;
        }
    }

    public class EigenResult
    {
        public double[] Eigenvalues { get; }
        public double[,] Eigenvectors { get; }

        public EigenResult(double[] eigenvalues, double[,] eigenvectors)
        {
            Eigenvalues = eigenvalues;
            Eigenvectors = eigenvectors;
        }
    }
}
