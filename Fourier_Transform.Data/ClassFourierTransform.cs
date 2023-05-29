using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fourier_Transform.Data
{
    public class ClassFourierTransform
    {
        public static Complex[] DFT(Complex[] coefficients)
        {
            int length = coefficients.Length;
            Complex[] result = new Complex[length];

            for (int k = 0; k < length; k++)
            {
                result[k] = Complex.Zero;

                for (int n = 0; n < length; n++)
                {
                    Complex expo = Complex.FromPolarCoordinates(1, -2 * Math.PI * k * n / length);
                    result[k] += coefficients[n] * expo;
                }
            }

            return result;
        }

        public static Complex[] InverseDFT(Complex[] transformed)
        {
            int length = transformed.Length;
            Complex[] result = new Complex[length];

            for (int n = 0; n < length; n++)
            {
                result[n] = Complex.Zero;

                for (int k = 0; k < length; k++)
                {
                    Complex expo = Complex.FromPolarCoordinates(1, 2 * Math.PI * k * n / length);
                    result[n] += transformed[k] * expo;
                }

                result[n] /= length;
            }

            return result;
        }

        public static int[] PolynomialMultiplicationn(int[] p, int[] q)
        {
            int length = p.Length + q.Length - 1;
            Complex[] pCoeffs = new Complex[length];
            Complex[] qCoeffs = new Complex[length];

            // Pad the coefficient sequences to the same length
            for (int i = 0; i < p.Length; i++)
                pCoeffs[i] = new Complex(p[i], 0);

            for (int i = 0; i < q.Length; i++)
                qCoeffs[i] = new Complex(q[i], 0);

            // Compute the DFT of the padded coefficient sequences
            Complex[] P = DFT(pCoeffs);
            Complex[] Q = DFT(qCoeffs);

            // Element-wise multiplication of transformed sequences
            Complex[] R = new Complex[length];
            for (int i = 0; i < length; i++)
                R[i] = P[i] * Q[i];

            // Compute the inverse DFT of the transformed result sequence
            Complex[] r = InverseDFT(R);

            // Extract the non-zero coefficients of the resulting polynomial
            int[] product = new int[length];
            for (int i = 0; i < length; i++)
                product[i] = (int)Math.Round(r[i].Real);

            return product;
        }
    }
}
