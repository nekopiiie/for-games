using System;

namespace task_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int min = int.MinValue; // -2,147,483,648
                int max = int.MaxValue; // 2,147,483,647
                int number = NumberInput.ReadNumber(min, max);
                Console.WriteLine($"Вы ввели число: {number}");
            }
            catch (NumberOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
