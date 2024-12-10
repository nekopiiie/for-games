using System;

class Program
{
    static void Main()
    {
        // Запрашиваем у пользователя ввод коэффициентов a, b и c
        double a = GetCoefficient("Введите коэффициент a: ");
        double b = GetCoefficient("Введите коэффициент b: ");
        double c = GetCoefficient("Введите коэффициент c: ");

        // Вызываем метод для решения уравнения
        SolveEquation(a, b, c);
    }

    static double GetCoefficient(string message)
    {
        Console.Write(message);
        return Convert.ToDouble(Console.ReadLine());
    }

    static void SolveEquation(double a, double b, double c)
    {
        if (a != 0)
        {
            // Вычисляем дискриминант
            double discriminant = CalculateDiscriminant(a, b, c);
            HandleQuadraticEquation(discriminant, a, b);
        }
        else if (b != 0)
        {
            // Линейное уравнение
            double x = -c / b;
            Console.WriteLine($"Уравнение имеет одно решение: x = {x}");
        }
        else
        {
            // Уравнение не содержит переменных
            HandleConstantEquation(c);
        }
    }

    static double CalculateDiscriminant(double a, double b, double c)
    {
        return b * b - 4 * a * c;
    }

    static void HandleQuadraticEquation(double discriminant, double a, double b)
    {
        if (discriminant > 0)
        {
            // Два различных корня
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Уравнение имеет два решения: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            // Один корень (кратный)
            double x = -b / (2 * a);
            Console.WriteLine($"Уравнение имеет одно решение: x = {x}");
        }
        else
        {
            // Нет действительных решений
            Console.WriteLine("Уравнение не имеет действительных решений.");
        }
    }

    static void HandleConstantEquation(double c)
    {
        if (c == 0)
        {
            Console.WriteLine("Уравнение имеет бесконечно много решений.");
        }
        else
        {
            Console.WriteLine("Уравнение не имеет решений.");
        }
    }
}
