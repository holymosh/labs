using Numerical_Methods.Interfaces;
using System;

namespace Numerical_Methods.Classes
{
    public class LuDecomposition: ILuDecomposition
    {
        private IMatrix L;
        private IMatrix U;

        public IMatrix GetMatrixL => L;

        public IMatrix GetMatrixU => U;

        public IMatrix CalculateReverseMatrix()
        {
            return MatrixInverse(JoinLU());
        }

        public IMatrix JoinLU()
        {
            var values = new double[L.Width,L.Width];
            for (int row = 0; row < L.Height; row++)
            {
                for (int column = 0; column < L.Width; column++)
                {
                    if (row<=column)
                    {
                        values[row, column] = U[row, column];
                    }
                    else
                    {
                        values[row, column] = L[row, column];
                    }
                }
            }

            var result = new Matrix(values);
            result.Print();
            return result;
        }


        public LuDecomposition(IMatrix l, IMatrix u)
        {
            L = l;
            U = u;
        }

        public LuDecomposition()
        {
        }

        public void Print()
        {
            Console.WriteLine("\nL matrix: \n");
            L.Print();
            Console.WriteLine("\nU matrix: \n");
            U.Print();
        }

        private IMatrix MatrixInverse(IMatrix matrix)
        {
            int r = matrix.Height;
            int c = r;
            int n = r;
            int[] indx = new int[n];
            double[,] result = new double[n,n];
            double[] col = new double[n];
            double[] x = new double[n];
            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    col[i] = 0.0;
                }
                col[j] = 1.0;
                x = MatrixBackSub(matrix, indx, col);
                for (int i = 0; i < n; i++)
                {
                    result[i, j] = x[i];
                }
            }
            return new Matrix(result);
        }

        private double[] MatrixBackSub(IMatrix luMatrix, int[]indx, double[] b)
        {
            int ii = 0; int ip = 0;
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
                    for (int j = ii; j < i-1; j++)
                    {
                        sum -= luMatrix[i,j] * x[j];
                    }
                }
                else if (sum.Equals(0.0))
                {
                    ii = i;
                }
                x[i] = sum;
            }
            for (int i =n-1; i>=0 ; --i)
            {
                sum = x[i];
                for (int j = i+1; j < n; j++)
                {
                    sum -= luMatrix[i, j] * x[j];
                }
                x[i] = sum / luMatrix[i, i];
            }
            return x;
        } 

    }
}
