using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Numerical_Methods.Classes
{
    class MathNetClasses
    {
        public void Test()
        {
            Matrix<double> matrix = DenseMatrix.OfArray(new double[2,2]);
        }
    }
}
