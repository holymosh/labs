namespace Numerical_Methods.Interfaces
{
    public interface ILuDecomposition : IPrintable
    {
        IMatrix GetMatrixL { get; }
        IMatrix GetMatrixU { get; }
        IMatrix CalculateReverseMatrix();
        IMatrix JoinLU();
    }
}
