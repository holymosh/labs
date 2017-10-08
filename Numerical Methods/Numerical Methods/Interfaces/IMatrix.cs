using System;

namespace Numerical_Methods.Interfaces
{
    public interface IMatrix: IPrintable
    {
        int Width { get; }
        int Height { get; }
        ILuDecomposition CreateLuDecomposition();
        double[,] GetArray { get; }
    }
}
