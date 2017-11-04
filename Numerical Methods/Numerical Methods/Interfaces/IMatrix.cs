using System;

namespace Numerical_Methods.Interfaces
{
    public interface IMatrix: IPrintable
    {
        int Width { get; }
        int Height { get; }
        ILuDecomposition CreateLuDecomposition();
        double[,] GetArray { get; }
        IMatrix CreateTransposedMatrix();
        double this[int row, int i] { get; }
        IMatrix Multiply(double value);
        double MultiplyElementsOnMainDiagonal();
        IMatrix Multiply(IMatrix matrix);
        double MultiplyElementsOnMainDiagonalWithoutElementsOnCustomRowAndColumn(int row,int column);
    }
}
