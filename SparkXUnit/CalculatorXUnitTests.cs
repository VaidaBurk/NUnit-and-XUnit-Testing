using System.Collections.Generic;
using Xunit;

namespace Sparky
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(10);

            //Assert
            Assert.False(isOdd);
            //Assert.IsFalse(isOdd);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool isOdd = calc.IsOddNumber(a);

            //Assert
            Assert.True(isOdd);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            Calculator calc = new();
            var result = calc.IsOddNumber(a);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(5.4, 10.5)] //15.9
        [InlineData(5.43, 10.53)] //15.96
        [InlineData(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calc = new();
            double result = calc.AddNumbersDouble(a, b);
            Assert.Equal(15.9, result, 0); // how many decimals (precision), test pass
        }

        [Fact]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.Equal(expectedOddRange, result);

            //Helper methods:

            Assert.Contains(7, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.DoesNotContain(6, result);
            Assert.Equal(result.OrderBy(u=>u), result);
        }
    }
}
