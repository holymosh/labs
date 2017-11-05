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

        public Matrix()
        {
        }

        public Matrix(int n, int m)
        {
            Values = new double[n,m];
        }

        public Matrix SolveViaIterationMethod(Matrix b)
        {
            var N = 3;
            int i, j;
            double[] x0 = { };
            double delta;
            double[] E = new double[N];
            double[] x = new double[N];
            for (int k = 0; k < b.RowCount; k++)
            {
                x0[0] = b[k];
            }

            do
            {
                for (i = 0; i < N; i++)
                {
                    x[i] = 0;
                    for (j = 0; j < N; j++)
                    {
                        x[i] = x[i] + Values[i, j] * x0[j];
                    }
                    x[i] = x[i] + b[i];
                    E[i] = Math.Abs(x[i] - x0[i]);
                }
                delta = E[0];
                for (i = 1; i < N; i++)
                {
                    if (delta < E[i]) delta = E[i];
                };
                x0 = x;
            } while (delta <= 0.000001);
            return new Matrix(x);
        }

        public static Matrix OfArray(double[,] newValues )
        {
            return new Matrix(values:newValues);
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

        public Qr QR() => new Qr(this);


        public double this[int i, int j]
        {
            get => Values[i, j];
            set => Values[i, j] = value;
        }

        public double this[int i] => Values[i,0];
    }
}
