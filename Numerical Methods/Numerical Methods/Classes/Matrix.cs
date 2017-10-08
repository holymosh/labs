using System;
using Numerical_Methods.Interfaces;

namespace Numerical_Methods.Classes
{
    public class Matrix : IMatrix
    {
        private double[,] _matrix;
        public int Width => _matrix.GetLength(1);
        public int Height => _matrix.GetLength(0);
        public double[,] GetArray => _matrix;

        public IMatrix CreateTransposedMatrix()
        {
            var matrix = new Matrix(Height,Width);
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    matrix[column, row] = _matrix[row, column];
                }
            }
            return matrix;
        }


        public Matrix(double[,] matrix)
        {
            _matrix = matrix;
        }

        public Matrix(int width, int height)
        {
            _matrix = new double[height, width];
        }

        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }

        public IMatrix Multiply(double value)
        {
            var newMatrix = new double[Height,Width];
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    newMatrix[row, column] = _matrix[row, column] * value;
                }
            }
            return new Matrix(newMatrix);
        }

        public double MultiplyElementsOnMainDiagonal()
        {
            double result = 1;
            for (int row = 0; row < Height; row++)
            {
                result *= _matrix[row, row];
            }
            return result;
        }

        public IMatrix Multiply(IMatrix matrix)
        {
            if (!Width.Equals(matrix.Height))
            {
                throw new ArgumentException("can't multiply");
            }
            var newMatrix = new double[Height,matrix.Width];
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < matrix.Width; column++)
                {
                    for (int k = 0; k < matrix.Height; k++)
                    {
                        newMatrix[row, column] += _matrix[row, k] * matrix[k, row];
                    }
                }
            }
            return new Matrix(newMatrix);
        }

        public ILuDecomposition CreateLuDecomposition()
        {
            double[,] L = new double[Width, Width];
            double[,] U = new double[Width, Width];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    U[0, i] = _matrix[0, i];
                    L[i, 0] = _matrix[i, 0] / U[0, 0];
                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += L[i, k] * U[k, j];
                    }
                    U[i, j] = _matrix[i, j] - sum;
                    if (i > j)
                    {
                        L[j, i] = 0;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[j, k] * U[k, i];
                        }
                        L[j, i] = (_matrix[j, i] - sum) / U[i, i];
                    }
                }
            }
            IMatrix matrixL = new Matrix(L);
            IMatrix matrixU = new Matrix(U);
            return new LuDecomposition(matrixL,matrixU);
        }


        public void Print()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int column = 0; column < Width; column++)
                {
                    Console.Write($"{_matrix[row,column]} ");
                }
                Console.WriteLine();
            }
        }

    }
}

