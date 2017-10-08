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
    }
}
