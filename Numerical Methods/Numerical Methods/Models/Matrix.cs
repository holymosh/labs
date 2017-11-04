using System;

namespace Numerical_Methods.Models
{
    public class Matrix 
    {
        public double[,] Values { get; }

        public int RowCount => Values.GetLength(0);
        public int ColumnCount => Values.GetLength(0);

        public Matrix(double[,] values)
        {
            Values = values;
        }

        public Matrix(double[] values)
        {
            var n = values.Length;
            Values =  new double[n,1];
            for (int i = 0; i < n; i++)
            {
                Values[i, 1] = values[i];
            }
        }

        public static Matrix OfArray(double[,] newValues )
        {
            return new Matrix(values:newValues);
        }

        public LU LU()
        {
            var n = Values.GetLength(0);
            var m = Values.GetLength(1);
            double[,] L = new double[n,m];
            double[,] U = new double[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    U[0, i] = Values[0, i];
                    L[i, 0] = Values[i, 0] / U[0, 0];
                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += L[i, k] * U[k, j];
                    }
                    U[i, j] = Values[i, j] - sum;
                    if (i > j)
                    {
                        L[j, i] = 0;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[j, k] * U[k, i];
                        }
                        L[j, i] = (Values[j, i] - sum) / U[i, i];
                    }
                }
            }

            return new LU(new Matrix(L), new Matrix(U));
        }

        public Matrix Multiply(Matrix matrix)
        {
            var n = matrix.Values.GetLength(0);
            var newMatrix = new double[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    for (int k = 0; k <n; k++)
                    {
                        newMatrix[row, column] += Values[row, k] * matrix.Values[k, row];
                    }
                }
            }
            return new Matrix(newMatrix);
        }

        public Cholesky Cholesky()
        {
            int nn = Values.GetLength(0);
            double[,] a = new double[nn,nn];
            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < nn; j++)
                {
                    a[i, j] = Values[i, j];
                }
            }
            int n = (int)Math.Sqrt(a.Length);

            double[,] ret = new double[n, n];
            for (int r = 0; r < n; r++)
            for (int c = 0; c <= r; c++)
            {
                if (c == r)
                {
                    double sum = 0;
                    for (int j = 0; j < c; j++)
                    {
                        sum += ret[c, j] * ret[c, j];
                    }
                    ret[c, c] = Math.Sqrt(a[c, c] - sum);
                }
                else
                {
                    double sum = 0;
                    for (int j = 0; j < c; j++)
                        sum += ret[r, j] * ret[c, j];
                    ret[r, c] = 1.0 / ret[c, c] * (a[r, c] - sum);
                }
            }
            return new Cholesky(new Matrix(a));
        }

        public Matrix Transpose()
        {
            var n = Values.GetLength(0);
            var matrix = new double[n,n];
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    matrix[column, row] = Values[row, column];
                }
            }
            return new Matrix(matrix);
        }

        public double this[int i, int j] => Values[i,j];

        public double this[int i] => Values[i,0];
    }
}
