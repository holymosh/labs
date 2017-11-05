using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab1
{
    public static class MatrixExtensions
    {
        public static Matrix PrepareMatrixForIterations(this Matrix<double> equationMatrix)
        {
            var preparedMatrix = equationMatrix.Clone();
            
            for (var i = 0; i < equationMatrix.RowCount; i++)
            {
                for (var j = 0; j < equationMatrix.ColumnCount - 1; j++)
                {
                    preparedMatrix[i, j] /=  -equationMatrix[i, i];
                }

                preparedMatrix[i, equationMatrix.ColumnCount - 1] /= equationMatrix[i, i];
            }

            //LogMatrix();
            return preparedMatrix as Matrix;
        }


        public static (Matrix D, Matrix L, Matrix U) DluDecompose(this Matrix<double> leftPart)
        {
            var d = new DenseMatrix(leftPart.RowCount, leftPart.ColumnCount);
            var l = d.Clone();
            var u = d.Clone();
            
            for (var i = 0; i < leftPart.RowCount; i++)
            {
                for (var j = 0; j < leftPart.ColumnCount; j++)
                {
                    var a = i - j;
                    if (a > 0)
                        u[i, j] = leftPart[i, j];
                    if (a == 0)
                        d[i, j] = leftPart[i, j];
                    else
                        l[i, j] = leftPart[i, j];
                }
            }

            return ((Matrix D, Matrix L, Matrix U)) (d, l, u);
        }
    }
}