using System;

namespace Numerical_Methods.Models
{
    public class Cholesky
    {
        public Matrix Factor { get; }

        public Cholesky(Matrix factor)
        {
            Factor = factor;
        }

        public Matrix Solve(Matrix b)
        {
            var n = Factor.RowCount;
            double[] y = { };
            for (int i = 0; i < n; i++)
            {
                double temp = 0;
                for (int k = 0; k < i; k++)
                    temp += Factor[k,i] * y[k];
                y[i] = (b[i] - temp) / Factor[i,i];

            }

            double[] x = { };
            for (int i = n - 1; i >= 0; i--)
            {
                double temp = 0;
                for (int k = i; k < n; k++)
                    temp += Factor[i,k] * x[k];
                x[i] = (y[i] - temp) / Factor[i,i];
            }
            return new Matrix(x);
        }

    }
}
