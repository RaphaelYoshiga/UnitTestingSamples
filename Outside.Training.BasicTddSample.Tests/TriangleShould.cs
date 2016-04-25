using NUnit.Framework;
using Shouldly;
using System;

namespace Outside.Training.BasicTddSample.Tests
{
    [TestFixture]
    public class TriangleShould
    {
        [TestCase(52, 31)]
        [TestCase(401, 501)]
        public void Set_Constructor_Arguments(int width, int height)
        {
            var triangle = new Triangle(width, height);

            triangle.Width.ShouldBe(width);
            triangle.Height.ShouldBe(height);
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Throw_When_Negative_Height(int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, height));
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void Throw_When_Negative_Width(int width)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(width, 1));
        }

        [TestCase(2, 1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 0.5)]
        [TestCase(60, 90, ExpectedResult = 2700)]
        public double Have_Area_Based_On_Height_And_Width(int width, int height)
        {
            var triangle = new Triangle(width, height);

            return triangle.CalculateArea();            
        }
    }
}
