using System;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CourseWork
{
    public class MatrixManager
    {
        public string ParseAndSolve(string notParsed)
        {
            var splited = notParsed.Split(' ', '\n');
            var size = Int32.Parse(splited[0]);
            var values = new double[size, size];
            var current = 1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    values[i, j] = Double.Parse(splited[current]);
                    current++;
                }
            }
            var result = string.Empty;
            var eigenvalues = DenseMatrix.OfArray(values).Evd().EigenValues;
            for (int i = 0; i < eigenvalues.Count; i++)
            {
                result += eigenvalues[i].Real + "\n";
            }

            return result;
        }


        double[,] Calc(double[,] massive, int n, int k)
        {
            if (k != n)
            {
                int i, j;
                double sum = 0;
                var b = new double[n, n];
                for (j = 0; j < n; j++)
                    b[k + 1, j] = (massive[k + 1, j] / massive[k + 1, k]);
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (i != k + 1 && j != k + 1)
                        {
                            b[i, j] = massive[i, j] - massive[i, k] * b[k + 1, j];
                            massive[i, j] = b[i, j];
                        }
                    }
                }
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        sum += b[i, j] * massive[j, k];
                        massive[i, k + 1] = sum;
                    }
                }
                k++;
                massive = Calc(massive, n, k);
            }
            return massive;
        }
    }
}