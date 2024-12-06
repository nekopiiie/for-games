class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое комплексное число (в формате a + bi):");
        ComplexNumber c1 = ReadComplexNumber();

        Console.WriteLine("Введите второе комплексное число (в формате a + bi):");
        ComplexNumber c2 = ReadComplexNumber();

        ComplexNumber sum = c1 + c2;
        ComplexNumber product = c1 * c2;
        ComplexNumber quotient = c1 / c2;
        ComplexNumber power = c1.Power(2); // c1 в квадрате
        ComplexNumber sqrt = c1.SquareRoot(); // корень из c1

        Console.WriteLine($"Сложение: {sum}");
        Console.WriteLine($"Умножение: {product}");
        Console.WriteLine($"Деление: {quotient}");
        Console.WriteLine($"Возведение в степень: {power}");
        Console.WriteLine($"Извлечение корня: {sqrt}");
        Console.WriteLine($"Модуль: {c1.Modulus()}");
        Console.WriteLine($"Угол: {c1.Angle()}");
    }

    static ComplexNumber ReadComplexNumber()
    {
        string input = Console.ReadLine();
        var parts = input.Split(new[] { ' ', '+' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2)
        {
            double real = double.Parse(parts[0]);
            double imaginary = double.Parse(parts[1].Replace("i", "").Trim());
            return new ComplexNumber(real, imaginary);
        }
        else
        {
            throw new FormatException("Неправильный формат комплексного числа. Используйте формат 'a + bi'.");
        }
    }
}
