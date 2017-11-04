using System;

public class Program
{
    private static void wrachenie()
    {
        var result = 1;
        int i, j, k;
        int maxI = 0, maxJ = 0;
        double max, fi;
        double[,] coefficients, solution;
        double precision;
        int size;

        Console.WriteLine("Введите точность ");
        precision = Double.Parse(Console.ReadLine());
        Console.WriteLine("Введите количество строк массива: ");
        size = Int32.Parse(Console.ReadLine());
        solution = new double[size,size];
        coefficients = new double[size,size];
        for (i = 0; i < coefficients.GetLength(0); i++)
        {
            Console.WriteLine("Введите " + i + " строку: ");
            for (j = 0; j < coefficients.GetLength(1); j++)
            {
                coefficients[i,j] = Int32.Parse(Console.ReadLine());
            }
        }

        for (i = 0; i < size; i++)
        {
            for (j = 0; j < size; j++)
                solution[i,j] = 0;
            solution[i,i] = 1;
        }
        var matrixTurn = new double[size,size];
        var temp = new double[size,size];
        var fault = 0.0;
        for (i = 0; i < size; i++)
        for (j = i + 1; j < size; j++)
            fault += coefficients[i,j] * coefficients[i,j];
        fault = Math.Sqrt(2 * fault);
        while (fault > precision)
        {
            max = 0.0;
            for (i = 0; i < size; i++)
            for (j = i + 1; j < size; j++)
                if (coefficients[i,j] > 0 && coefficients[i,j] > max)
                {
                    max = coefficients[i,j];
                    maxI = i;
                    maxJ = j;
                }
                else if (coefficients[i,j] < 0 && Math.Abs(coefficients[i,j]) > max)
                {
                    max = Math.Abs(coefficients[i,j]);
                    maxI = i;
                    maxJ = j;
                }
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                    matrixTurn[i,j] = 0;
                matrixTurn[i,i] = 1;
            }
            if (coefficients[maxI,maxI] == coefficients[maxJ,maxJ])
            {
                matrixTurn[maxI,maxI] = matrixTurn[maxJ,maxJ] =
                    matrixTurn[maxJ,maxI] = Math.Sqrt(2.0) / 2.0;
                matrixTurn[maxI,maxJ] = -Math.Sqrt(2.0) / 2.0;
            }
            else
            {
                fi = 0.5 * Math.Atan(2.0 * coefficients[maxI,maxJ] /
                                     (coefficients[maxI,maxI] - coefficients[maxJ,maxJ]));
                matrixTurn[maxI,maxI] = matrixTurn[maxJ,maxJ] = Math.Cos(fi);
                matrixTurn[maxI,maxJ] = -Math.Sin(fi);
                matrixTurn[maxJ,maxI] = Math.Sin(fi);
            }
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
                temp[i,j] = 0.0;
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
            for (k = 0; k < size; k++)
                temp[i,j] += matrixTurn[k,i] * coefficients[k,j];
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
                coefficients[i,j] = 0.0;
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
            for (k = 0; k < size; k++)
                coefficients[i,j] += temp[i,k] * matrixTurn[k,j];
            fault = 0.0;
            for (i = 0; i < size; i++)
            for (j = i + 1; j < size; j++)
                fault += coefficients[i,j] * coefficients[i,j];
            fault = Math.Sqrt(2 * fault);
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
                temp[i,j] = 0.0;
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
            for (k = 0; k < size; k++)
                temp[i,j] += solution[i,k] * matrixTurn[k,j];
            for (i = 0; i < size; i++)
            for (j = 0; j < size; j++)
                solution[i,j] = temp[i,j];
            result++;
        }
        Console.WriteLine("Решение");
        var a = new double[size];
        double Sqrt;
        for (i = 0; i < a.Length; i++)
        {
            Sqrt = 0;
            for (j = 0; j < a.Length; j++)
                Sqrt += solution[j,i] * solution[j,i];
            a[i] = Math.Sqrt(Sqrt);
        }
        for (i = 0; i < size; i++)
        {
            Console.WriteLine("Собственный вектор k" + (i + 1) + ":");
            for (j = 0; j < size; j++)
            {
                Console.WriteLine(solution[j,i] / a[i] + " ");
            }
        }
        Console.WriteLine("Собственные значения:");
        for (i = 0; i < size; i++)
        {
            Console.WriteLine(coefficients[i,i] + " ");
        }
        Console.WriteLine("Количество шагов: ");
        Console.WriteLine(result);
    }

    public static void Main(String[] args)
    {
        int i, j;
        int size;

        wrachenie();
    }
}