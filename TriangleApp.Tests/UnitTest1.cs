using System;
using Xunit;
using TriangleApp;

namespace TriangleApp.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(3, 4, 5, TriangleType.Right)]
        [InlineData(5, 5, 5, TriangleType.Acute)]
        [InlineData(2, 2, 3, TriangleType.Acute)]
        [InlineData(7, 24, 25, TriangleType.Right)]
        [InlineData(5, 12, 13, TriangleType.Right)]
        [InlineData(3, 4, 6, TriangleType.Obtuse)]
        public void DetermineTriangleType_ReturnsCorrectType(double a, double b, double c, TriangleType expected)
        {
            var result = Triangle.DetermineTriangleType(a, b, c);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(1, 2, 3, false)]  // Не треугольник, сумма двух сторон равна третьей
        [InlineData(0, 4, 5, false)]  // Не треугольник, одна сторона равна 0
        [InlineData(-3, 4, 5, false)] // Не треугольник, отрицательная сторона
        public void IsValidTriangle_ReturnsCorrectValidation(double a, double b, double c, bool expected)
        {
            var result = Triangle.IsValidTriangle(a, b, c);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(5, 5, 5, 10.825317547305486)]
        [InlineData(7, 24, 25, 84)]
        public void CalculateArea_ReturnsCorrectArea(double a, double b, double c, double expected)
        {
            var result = Triangle.CalculateArea(a, b, c);
            Assert.Equal(expected, result, 5); // точность до 5 знаков
        }

        [Fact]
        public void CalculateArea_WithInvalidTriangle_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Triangle.CalculateArea(1, 2, 3));
        }
    }
}
