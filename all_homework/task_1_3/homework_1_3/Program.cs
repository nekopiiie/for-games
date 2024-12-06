using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите коэффициенты a, b и c (a не равно 0): ");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("Коэффициент a не может быть равен 0 для квадратного уравнения.");
            return;
        }

        SolveQuadraticEquation(a, b, c);
    }

    static void SolveQuadraticEquation(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Уравнение имеет два решения: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Уравнение имеет одно решение: x = {x}");
        }
        else
        {
            Console.WriteLine("Уравнение не имеет действительных решений.");
        }
    }
}
