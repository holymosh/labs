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
                {2,3,4},
                {1,2,3},
                {9,8,6},
            });
            matrix.Print();
            matrix.CreateLuDecomposition().Print();
            var reveredMatrix = matrix.CreateLuDecomposition().CalculateReverseMatrix();
            reveredMatrix.Print();
        }
    }
}
