using System;
using Numerical_Methods.Classes;
using Numerical_Methods.Interfaces;

namespace Numerical_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatrix matrix = new Matrix(new double[,]
            {
                {1,2,3 },
                {3,2,1 },
                {1,3,2 }
            });
            var decomposed = matrix.CreateLuDecomposition();
            decomposed.Print();
        }
    }
}
