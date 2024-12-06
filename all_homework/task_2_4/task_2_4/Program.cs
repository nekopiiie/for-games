using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите элементы массива через пробел:");
        string input = Console.ReadLine();

        // Преобразуем входные данные в массив целых чисел
        int[] array = input.Split(' ')
                           .Select(int.Parse)
                           .ToArray();

        // Выполняем пузырьковую сортировку
        BubbleSort(array);

        // Выводим отсортированный массив
        Console.WriteLine("Отсортированный массив:");
        Console.WriteLine(string.Join(" ", array));
    }

    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // Меняем местами
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
}
