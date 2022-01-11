using NUnit.Framework;
using System.Collections.Generic;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddChecker_InputEvenNumber_ReturnFalse()
        {
            //Arrange

            //Act
            bool isOdd = calc.IsOddNumber(10);

            //Assert
            Assert.That(isOdd, Is.EqualTo(false));
            //Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange

            //Act
            bool isOdd = calc.IsOddNumber(a);

            //Assert
            //Assert.That(isOdd, Is.EqualTo(true));
            //Assert.That(isOdd, Is.True);
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.96
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calc = new();
            double result = calc.AddNumbersDouble(a, b);
            Assert.AreEqual(15.9, result, .2); // if difference between result is <0.2 (delta), test pass
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            //Arrange
            List<int> expectedOddRange = new() { 5, 7, 9 };

            //Act
            List<int> result = calc.GetOddRange(5, 10);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            //Assert.AreEqual(expectedOddRange, result);


            //Helper methods:

            Assert.That(result, Does.Contain(7));
            //Assert.Contains(7, result);

            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result, Has.No.Member(6));

            Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Ordered.Descending);

            Assert.That(result, Is.Unique); //checks if all values in list are unique








        }

    }
}
