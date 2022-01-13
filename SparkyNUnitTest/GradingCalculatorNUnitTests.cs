using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradingCalculator_InputScore95AndAttendance90_ReturnGradeA()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void GradingCalculator_InputScore85AndAttendance90_ReturnGradeB()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        public void GradingCalculator_InputScore65AndAttendance90_ReturnGradeC()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;

            string result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        public void GradingCalculator_InputScore95AndAttendance65_ReturnGradeC()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;

            string result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradingCalculator_InputScoreOrAttendanceLowerThan60_ReturnGradeF(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;

            string result = _gradingCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradingCalculator_InputScoreAndAttendance_ReturnExpectedGrade(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;

            return _gradingCalculator.GetGrade();
        }
    }
}
