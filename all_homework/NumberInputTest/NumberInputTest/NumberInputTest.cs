using Xunit;
using System;
using task_7_1; // Добавляем ссылку на пространство имен вашего проекта

namespace NumberInputTest // Исправлено на соответствие папке
{
    public class NumberInputTests
    {
        [Fact]
        public void ReadNumber_ValidNumber_ReturnsNumber()
        {
            // Arrange
            int min = int.MinValue;
            int max = int.MaxValue;

            // Act
            int result = NumberInput.ReadNumber(min, max);

            // Assert
            Assert.True(result >= min && result <= max);
        }

        [Fact]
        public void ReadNumber_TooLarge_ThrowsException()
        {
            // Arrange
            int min = 1;
            int max = 10;

            // Act and Assert
            var exception = Assert.Throws<NumberOutOfRangeException>(() =>
            {
                // Симулировать ввод слишком большого числа
                Console.SetIn(new System.IO.StringReader("10000000000"));
                NumberInput.ReadNumber(min, max);
            });
            Assert.Equal("Введенное число (10000000000) выходит за пределы допустимого диапазона [1; 10].", exception.Message);
        }

        [Fact]
        public void ReadNumber_TooSmall_ThrowsException()
        {
            // Arrange
            int min = 1;
            int max = 10;

            // Act and Assert
            var exception = Assert.Throws<NumberOutOfRangeException>(() =>
            {
                // Симулировать ввод слишком маленького числа
                Console.SetIn(new System.IO.StringReader("-100"));
                NumberInput.ReadNumber(min, max);
            });
            Assert.Equal("Введенное число (-100) выходит за пределы допустимого диапазона [1; 10].", exception.Message);
        }

        [Fact]
        public void ReadNumber_NonNumericInput_ThrowsException()
        {
            // Arrange
            int min = 1;
            int max = 10;

            // Act and Assert
            var exception = Assert.Throws<FormatException>(() =>
            {
                // Симулировать ввод нечислового значения
                Console.SetIn(new System.IO.StringReader("abc"));
                NumberInput.ReadNumber(min, max);
            });
            Assert.Equal("Неверный ввод. Попробуйте еще раз.", exception.Message);
        }
    }
}
