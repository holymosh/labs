using System;
using System.Collections.Generic;

public class Program
{
    public static double[] solution(List<Double> b, int n, double[,] l, double[,] u)
    {
        var solution = new double[n];
        var y = new double[n];
        for (var j = 0; j < n; j++)
        {
            y[j] = b[j];
            for (var i = 0; i < j; i++)
                y[j] -= l[j,i] * y[i];
        }
        for (var j = n - 1; j >= 0; j--)
        {
            solution[j] = y[j];
            for (var i = j + 1; i < n; i++)
                solution[j] -= u[j,i] * solution[i];
            solution[j] /= u[j,j];
        }
        return solution;
    }

    public static void LU()
    {
        int n;
        Console.WriteLine("Введите количество строк массива: ");
        n = Int32.Parse(Console.ReadLine());
        double[,] matrix= new double[n,n];
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine("Введите " + i + " строку: ");
            for (var j = 0; j < n; j++)
            {
                matrix[i,j] = Double.Parse(Console.ReadLine());
            }
        }
        var l = new double[n,n];
        var u = new double[n,n];
        for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
        {
            u[0,i] = matrix[0,i];
            l[i,0] = matrix[i,0] / u[0,0];
            double sum = 0;
            for (var k = 0; k < i; k++)
                sum += l[i,k] * u[k,j];
            u[i,j] = matrix[i,j] - sum;
            if (i > j)
            {
                l[j,i] = 0;
            }
            else
            {
                sum = 0;
                for (var k = 0; k < i; k++)
                    sum += l[j,k] * u[k,i];
                l[j,i] = (matrix[j,i] - sum) / u[i,i];
            }
        }
        Console.WriteLine("L:");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(l[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("U:");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(u[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();


        var solution = new double[n];
        var inverseMatrix = new double[n,n];
        List<Double> b = new List<double>();
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
                if (i == j) b.Add(1.0);
                else b.Add(0.0);
            solution = Program.solution(b, n, l, u);
            for (var j = 0; j < n; j++) inverseMatrix[j,i] = solution[j];
        }
        Console.WriteLine("Inverse:");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(inverseMatrix[i,j] + " ");
            }
            Console.WriteLine();
        }
        for (var j = 0; j < n; j++) for (var i = 0; i < n; i++) solution[j] += matrix[i,j] * b[i];
        Console.WriteLine("Решение: ");
        for (var i = 0; i < n; i++)
        {
            Console.Write(solution[i] + " ");
        }
        Console.WriteLine();
    }

    public static void squareRoot()
    {
        int n;
        Console.WriteLine("Введите количество строк массива: ");
        n = Int32.Parse(Console.ReadLine());
        double[,] matrix = new double[n,n];
        double[,] s = new double[n,n];
        double[] x = new double[n];
        double[] y = new double[n];
        double[] b = new double[n];
        for (var i = 0; i < n; i++) for (var j = 0; j < n; j++) s[i,j] = 0;
        for (var i = 0; i < n; i++)
        {
            x[i] = 0;
            y[i] = 0;
        }
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine("Введите " + i + " строку: ");
            for (var j = 0; j < n; j++)
            {
                matrix[i,j] = Double.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("Введите массив b: ");
        for (var i = 0; i < n; i++)
        {
            b[i] = Double.Parse(Console.ReadLine());
        }
        double temp;
        for (var i = 0; i < n; i++)
        {
            temp = 0;
            for (var k = 0; k < i; k++)
                temp += s[k,i] * s[k,i];
            s[i,i] = Math.Sqrt(matrix[i,i] - temp);
            for (var j = i; j < n; j++)
            {
                temp = 0;
                for (var k = 0; k < i; k++)
                    temp += s[k,i] * s[k,j];
                s[i,j] = (matrix[i,j] - temp) / s[i,i];
            }
        }

        Console.WriteLine("Матрица LT");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(s[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Матрица L");
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                Console.Write(s[j,i] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        for (var i = 0; i < n; i++)
        {
            temp = 0;
            for (var k = 0; k < i; k++)
                temp += s[k,i] * y[k];
            y[i] = (b[i] - temp) / s[i,i];
        }


        for (var i = 0; i < n; i++)
        {
            Console.Write(y[i] + " ");
        }
        Console.WriteLine();


        for (var i = n - 1; i >= 0; i--)
        {
            temp = 0;
            for (var k = i; k < n; k++)
                temp += s[i,k] * x[k];
            x[i] = (y[i] - temp) / s[i,i];
        }


        for (var i = 0; i < n; i++)
        {
            Console.WriteLine("x(" + i + ")=" + x[i]);
        }
    }


    public static void pow()
    {
        int n;
        double precision;
        Console.WriteLine("Введите количество строк массива: ");
        n = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Введите точность ");
        precision = Int32.Parse(Console.ReadLine());
        double[,] matrix = new double[n,n];
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine("Введите " + i + " строку: ");
            for (var j = 0; j < n; j++)
            {
                matrix[i, j] = Double.Parse(Console.ReadLine());
            }
        }
        var x = new double[n];

        var y = new double[n];
        double eigan_max_value = 0;
        double clarity_max = 1;
        var eigan_value = new double[n];
        var eigan_value1 = new double[n];
        for (var i = 0; i < n; i++)
        {
            eigan_value[i] = 0.0;
            x[i] = 1.0 / n;
            y[i] = 1;
        }

        while (clarity_max > precision)
        {
            double norma = 0;
            for (var i = 0; i < n; i++)
            {
                y[i] = 0;
                for (var j = 0; j < n; j++)
                    y[i] += matrix[i,j] * x[j];
            }
            for (var i = 0; i < n; i++) norma += y[i] * y[i];
            for (var i = 0; i < n; i++) eigan_value1[i] = y[i] / x[i];
            for (var i = 0; i < n; i++)
                x[i] = y[i] / norma;
            clarity_max = 0.0;
            for (var i = 0; i < n; i++)
                if (clarity_max < Math.Abs(eigan_value[i] - eigan_value1[i]))
                    clarity_max = Math.Abs(eigan_value[i] - eigan_value1[i]);
            eigan_max_value = 0;
            for (var i = 0; i < n; i++)
            {
                eigan_value[i] = eigan_value1[i];
                eigan_max_value += eigan_value[i];
            }
            eigan_max_value /= n;
        }

        Console.WriteLine(eigan_max_value);
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine(x[i] / x[0] + " ");
        }
        Console.WriteLine();

        Console.WriteLine();

        for (var i = 0; i < n; i++)
            matrix[i,i] -= eigan_max_value;
        y = new double[n];
        clarity_max = 1;
        var x2 = new double[n];

        double eigan_max_value2 = 0;
        eigan_value = new double[n];
        eigan_value1 = new double[n];
        for (var i = 0; i < n; i++)
        {
            eigan_value[i] = 0.0;
            x2[i] = 1.0 / n;
            y[i] = 1;
        }

        while (clarity_max > precision)
        {
            double norma = 0;
            for (var i = 0; i < n; i++)
            {
                y[i] = 0;
                for (var j = 0; j < n; j++)
                    y[i] += matrix[i,j] * x2[j];
            }
            for (var i = 0; i < n; i++) norma += y[i] * y[i];
            for (var i = 0; i < n; i++) eigan_value1[i] = y[i] / x2[i];
            for (var i = 0; i < n; i++)
                x2[i] = y[i] / norma;
            clarity_max = 0.0;
            for (var i = 0; i < n; i++)
                if (clarity_max < Math.Abs(eigan_value[i] - eigan_value1[i]))
                    clarity_max = Math.Abs(eigan_value[i] - eigan_value1[i]);
            eigan_max_value2 = 0;
            for (var i = 0; i < n; i++)
            {
                eigan_value[i] = eigan_value1[i];
                eigan_max_value2 += eigan_value[i];
            }
            eigan_max_value2 /= n;
        }
        eigan_max_value2 += eigan_max_value;
        Console.WriteLine("Минимальное собственное значение: ");
        Console.WriteLine(eigan_max_value2);
        Console.WriteLine("Собственный вектор: ");
        for (var i = 0; i < n; i++)
        {
            Console.WriteLine(x2[i] / x2[2] + " ");
        }
    }

    public static void Main(String[] args)
    {
        int n;
        Console.WriteLine("Выберите задачу: 1 - LU,2 - squareRoot, 3 - pow  ");
        n = Int32.Parse(Console.ReadLine());
        switch (n)
            {
                case 1:
                    LU();
                    break;
                case 2:
                    squareRoot();
                    break;
                case 3:
                    pow();
                    break;
            }
    }
}