using System;

public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    // Сложение
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    // Умножение
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(
            a.Real * b.Real - a.Imaginary * b.Imaginary,
            a.Real * b.Imaginary + a.Imaginary * b.Real
        );
    }

    // Деление
    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
        return new ComplexNumber(
            (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator,
            (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator
        );
    }

    // Возведение в степень
    public ComplexNumber Power(int exponent)
    {
        ComplexNumber result = new ComplexNumber(1, 0);
        for (int i = 0; i < exponent; i++)
        {
            result *= this;
        }
        return result;
    }

    // Извлечение корня
    public ComplexNumber SquareRoot()
    {
        double modulus = Modulus();
        double angle = Angle();
        double rootModulus = Math.Sqrt(modulus);
        double rootAngle = angle / 2;

        return new ComplexNumber(rootModulus * Math.Cos(rootAngle), rootModulus * Math.Sin(rootAngle));
    }

    // Нахождение модуля
    public double Modulus()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    // Вычисление угла
    public double Angle()
    {
        return Math.Atan2(Imaginary, Real);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
