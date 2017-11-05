using System;

namespace Numerical_Methods.Models
{
    public class Qr
    {
        private readonly int m;
        private readonly int n;
        public Matrix Q => getQ();
        public Matrix R => getR();
        private double[,] QR;
        private readonly double[] Rdiag;

        public Qr(Matrix A)
        {
            m = A.RowCount;
            n = A.ColumnCount;
            Rdiag = new double[n];

            for (var k = 0; k < n; k++)
            {
                double nrm = 0;

                if (nrm != 0.0)
                {
                    if (QR[k, k] < 0)
                        nrm = -nrm;
                    for (var i = k; i < m; i++)
                        QR[i, k] /= nrm;
                    QR[k, k] += 1.0;

                    for (var j = k + 1; j < n; j++)
                    {
                        var s = 0.0;
                        for (var i = k; i < m; i++)
                            s += QR[i, k] * QR[i, j];
                        s = -s / QR[k, k];
                        for (var i = k; i < m; i++)
                            QR[i, j] += s * QR[i, k];
                    }
                }
                Rdiag[k] = -nrm;
            }
        }

        public bool isFullRank()
        {
            for (var j = 0; j < n; j++)
                if (Rdiag[j] == 0)
                    return false;
            return true;
        }

        public Matrix getH()
        {
            var X = new Matrix(m, n);
            var H = X.Values;
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
                if (i >= j)
                    H[i, j] = QR[i, j];
                else
                    H[i, j] = 0.0;
            return X;
        }


        public Matrix getR()
        {
            var X = new Matrix(n, n);
            var R = X.Values;
            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                if (i < j)
                    R[i, j] = QR[i, j];
                else if (i == j)
                    R[i, j] = Rdiag[i];
                else
                    R[i, j] = 0.0;
            return X;
        }


        public Matrix getQ()
        {
            var X = new Matrix(m, n);
            var Q = X.Values;
            for (var k = n - 1; k >= 0; k--)
            {
                for (var i = 0; i < m; i++)
                    Q[i, k] = 0.0;
                Q[k, k] = 1.0;
                for (var j = k; j < n; j++)
                    if (QR[k, k] != 0)
                    {
                        var s = 0.0;
                        for (var i = k; i < m; i++)
                            s += QR[i, k] * Q[i, j];
                        s = -s / QR[k, k];
                        for (var i = k; i < m; i++)
                            Q[i, j] += s * QR[i, k];
                    }
            }
            return X;
        }


        public Matrix solve(Matrix B)
        {
            if (B.RowCount != m)
                throw new ArgumentException();

            var nx = B.ColumnCount;
            var X = B.Values;

            for (var k = 0; k < n; k++)
            for (var j = 0; j < nx; j++)
            {
                var s = 0.0;
                for (var i = k; i < m; i++)
                    s += QR[i, k] * X[i, j];
                s = -s / QR[k, k];
                for (var i = k; i < m; i++)
                    X[i, j] += s * QR[i, k];
            }
            for (var k = n - 1; k >= 0; k--)
            {
                for (var j = 0; j < nx; j++)
                    X[k, j] /= Rdiag[k];
                for (var i = 0; i < k; i++)
                for (var j = 0; j < nx; j++)
                    X[i, j] -= X[k, j] * QR[i, k];
            }
            return new Matrix(X);
        }
    }
}