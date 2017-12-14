using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Numerical_Methods
{
    public static class Trick
    {
        public static Matrix<double>  SolveViaIterationMethod(this Matrix matrix,Matrix B)
        {
            return matrix.QR().Solve(B);
        }

        public static void Print(this Matrix<double> matrix , string phrase) 
        {
            Console.WriteLine(phrase);
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

    }

}
