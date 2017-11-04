#region  //usings

using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;
using LU = MathNet.Numerics.LinearAlgebra.Factorization.LU<double>;

#endregion

namespace Numerical_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Task8();
        }

        public void Task5()
        {
        }

        public void Task7()
        {
        }

        public void Task8()
        {
            // LU
            Console.WriteLine("LU");
            var A = Matrix.OfArray(new double[3, 3]
            {
                {1, 2, 3},
                {3, 5, 7},
                {1, 3, 4}
            });
            var B = Matrix.OfArray(new double[3, 1]
            {
                {3},
                {0},
                {1}
            });
            var X = A.LU().Solve(B);
            for (int i = 0; i < X.RowCount; i++)
            {
                for (int j = 0; j < X.ColumnCount; j++)
                {
                    Console.Write($"{X[i, j]} ");
                }
                Console.WriteLine();
            }

            // roots method ( cholesky factorization)
        }
    }
}