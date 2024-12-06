using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите число n: ");
        int n = int.Parse(Console.ReadLine());

        int steps = CollatzSteps(n);
        Console.WriteLine($"Количество замен, необходимых для достижения 1: {steps}");
    }

    static int CollatzSteps(int n)
    {
        int count = 0;

        while (n != 1)
        {
            if (n % 2 == 0) // Если n четное
            {
                n /= 2;
            }
            else // Если n нечетное
            {
                n = 3 * n + 1;
            }
            count++;
        }

        return count;
    }
}
