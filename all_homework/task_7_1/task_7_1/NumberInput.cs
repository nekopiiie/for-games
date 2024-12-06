using System;

namespace task_7_1
{
    public static class NumberInput
    {
        public static int ReadNumber(int min, int max)
        {
            while (true)
            {
                Console.Write("Введите число в диапазоне от " + min + " до " + max + ": ");
                string? input = Console.ReadLine(); // Добавлено ? для указания, что переменная может быть null

                if (input == null || !int.TryParse(input, out int number))
                {
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    continue;
                }

                if (number < min || number > max)
                {
                    throw new NumberOutOfRangeException($"Введенное число ({number}) выходит за пределы допустимого диапазона [{min}; {max}].");
                }

                return number;
            }
        }
    }
}
