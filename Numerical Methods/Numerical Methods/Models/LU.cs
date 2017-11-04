namespace Numerical_Methods.Models
{
    public class LU
    {
        public Matrix L { get; }
        public Matrix U { get; }

        public LU(Matrix l, Matrix u)
        {
            L = l;
            U = u;
        }

        public Matrix Inverse()
        {
            var n = L.Values.GetLength(0);
            var values = new double[n, n];
            for (int row = 0; row < n; row++)
            {
                for (int column = 0; column < n; column++)
                {
                    if (row <= column)
                    {
                        values[row, column] = U.Values[row, column];
                    }
                    else
                    {
                        values[row, column] = L.Values[row, column];
                    }
                }
            }
            int r = n;
            int c = r;
            int[] indx = new int[n];
            double[,] result = new double[n, n];
            double[] col = new double[n];
            double[] x = new double[n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    col[i] = 0.0;
                }
                col[j] = 1.0;
                x = MatrixBackSub(values, indx, col);
                for (int i = 0; i < n; i++)
                {
                    result[i, j] = x[i];
                }
            }
            return new Matrix(result);
        }

        private double[] MatrixBackSub(double[,] values, int[] indx, double[] b)
        {
            int ii = 0;
            int ip = 0;
            int n = b.Length;
            double sum = 0.0;
            double[] x = new double[b.Length];
            b.CopyTo(x, 0);
            for (int i = 0; i < n; i++)
            {
                ip = indx[i];
                sum = x[ip];
                x[ip] = x[i];
                if (ii.Equals(0))
                {
                    for (int j = ii; j < i - 1; j++)
                    {
                        sum -= values[i, j] * x[j];
                    }
                }
                else if (sum.Equals(0.0))
                {
                    ii = i;
                }
                x[i] = sum;
            }
            for (int i = n - 1; i >= 0; --i)
            {
                sum = x[i];
                for (int j = i + 1; j < n; j++)
                {
                    sum -= values[i, j] * x[j];
                }
                x[i] = sum / values[i, i];
            }
            return x;
        }

        public Matrix Solve(Matrix B)
        {
            return B.Multiply(Inverse());
        }
    }
}
