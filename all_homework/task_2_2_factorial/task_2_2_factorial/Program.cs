using System;
using System.Diagnostics;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите максимальный номер для подсчета факториала: ");
        int maxN = int.Parse(Console.ReadLine());

        // Переменная для хранения порога, при котором рекурсивный метод становится медленнее
        double threshold = 1.0; // Время в миллисекундах
        int slowStartN = -1; // Номер, с которого рекурсивный метод начинает быть медленнее

        Console.WriteLine("\nИзмерение времени выполнения для различных значений n:");
        for (int i = 1; i <= maxN; i++)
        {
            Stopwatch stopwatchRecursive = Stopwatch.StartNew();
            FactorialRecursive(i);
            stopwatchRecursive.Stop();

            Stopwatch stopwatchIterative = Stopwatch.StartNew();
            FactorialIterative(i);
            stopwatchIterative.Stop();

            double recursiveTime = stopwatchRecursive.Elapsed.TotalMilliseconds;
            double iterativeTime = stopwatchIterative.Elapsed.TotalMilliseconds;

            Console.WriteLine($"n = {i}: Рекурсивное время = {recursiveTime} ms, Итеративное время = {iterativeTime} ms");

            // Проверяем, если рекурсивное время превышает итеративное время на заданный порог
            if (recursiveTime > iterativeTime + threshold && slowStartN == -1)
            {
                slowStartN = i; // Сохраняем номер, с которого рекурсивный метод становится медленнее
            }
        }

        if (slowStartN != -1)
        {
            Console.WriteLine($"\nРекурсивный метод начинает работать заметно медленнее итеративного с n = {slowStartN}.");
        }
        else
        {
            Console.WriteLine("\nРекурсивный метод не стал заметно медленнее итеративного в заданном диапазоне.");
        }
    }

    static BigInteger FactorialRecursive(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return n * FactorialRecursive(n - 1);
    }

    static BigInteger FactorialIterative(int n)
    {
        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}
