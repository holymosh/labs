#region  //usings

using System;
using Matrix = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;
using static Numerical_Methods.Trick;
#endregion


namespace Numerical_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Task5();
        }


        public void Task5()
        {
            // qr
            Console.WriteLine("qr");
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
            var qr = A.QR();
            var q = qr.Q;
            var r = qr.R;
            Console.WriteLine("Q");
            Console.WriteLine();
            for (int i = 0; i < q.RowCount; i++)
            {
                for (int j = 0; j < q.ColumnCount; j++)
                {
                    Console.Write(q[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("R");
            Console.WriteLine();
            for (int i = 0; i < r.RowCount; i++)
            {
                for (int j = 0; j < r.ColumnCount; j++)
                {
                    Console.Write(r[i, j]+" ");
                }
                Console.WriteLine();
            }
            var solvedViaQr = qr.Solve(B);
            Console.WriteLine("result");
            for (int i = 0; i < solvedViaQr.RowCount; i++)
            {
                for (int j = 0; j < solvedViaQr.ColumnCount; j++)
                {
                    Console.Write(solvedViaQr[i, j] + " ");
                }
                Console.WriteLine();
            }   
            Console.WriteLine("solved via Iteration");
            Console.WriteLine();
            var solvedViaIteration = A.SolveViaIterationMethod(B);
            for (int i = 0; i < solvedViaIteration.RowCount; i++)
            {
                for (int j = 0; j < solvedViaIteration.ColumnCount; j++)
                {
                    Console.Write(solvedViaIteration[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}