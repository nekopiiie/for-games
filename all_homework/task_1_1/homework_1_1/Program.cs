using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"Простые числа, не превосходящие {n}:");
        for (int i = 2; i <= n; i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
