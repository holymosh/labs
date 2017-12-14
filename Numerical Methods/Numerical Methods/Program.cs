#region  //usings

using System;
using System.IO;
using MathNet.Numerics.LinearAlgebra;
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
            //program.Task5();
            program.Task8();
        }


        public void Task5()
        {
            // qr
            Console.WriteLine("qr");
            var A = Matrix.OfArray(new double[4, 4]
            {
                {8, 2, 3,1},
                {2,8,1,2},
                {1,2,8,4},
                {1,1,1,7 }
            });
            var B = Matrix.OfArray(new double[4, 1]
            {
                {1},
                {2},
                {2},
                {3}
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

        public void Task8()
        {
            using (var reader = new StreamReader(@"C:\Users\MI\Documents\labs\Numerical Methods\Numerical Methods\Extension\LU.txt"))
            {
                var size = Int32.Parse(reader.ReadLine());
                var matrix = new double[size,size];
                var vertical = new double[size];
                for (int i = 0; i < size; i++)
                {
                    var values = reader.ReadLine().Split(' ');
                    for (int j = 0; j < size; j++)
                    {
                        matrix[i, j] = double.Parse(values[j]);
                    }
                }
                var A = Matrix.OfArray(matrix);
                var splited = reader.ReadLine().Split(' ');
                for (int i = 0; i < size; i++)
                {
                    vertical[i] = double.Parse(splited[i]);
                }
                var lu = A.LU();
                lu.Inverse().Print("inversed");
                var l = lu.L;
                var u = lu.U;
                var B = new Matrix(size,1);
                for (int i = 0; i < size; i++)
                {
                    B[i, 0] = vertical[i];
                }
                var solved = lu.Solve(B);
                l.Print("L");
                u.Print("U");
                solved.Print("solved");
            }
        }
    }

}