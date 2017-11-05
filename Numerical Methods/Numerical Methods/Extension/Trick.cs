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
    }
}
