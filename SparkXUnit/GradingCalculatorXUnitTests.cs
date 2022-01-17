using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class GradingCalculatorXUnitTests
    {
        private readonly GradingCalculator gradingCalculator;
        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Fact]
        public void GradingCalculator_InputScore95AndAttendance90_ReturnGradeA()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("A", result);
        }

        [Fact]
        public void GradingCalculator_InputScore85AndAttendance90_ReturnGradeB()
        {
            gradingCalculator.Score = 85;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Fact]
        public void GradingCalculator_InputScore65AndAttendance90_ReturnGradeC()
        {
            gradingCalculator.Score = 65;
            gradingCalculator.AttendancePercentage = 90;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("C", result);
        }

        [Fact]
        public void GradingCalculator_InputScore95AndAttendance65_ReturnGradeC()
        {
            gradingCalculator.Score = 95;
            gradingCalculator.AttendancePercentage = 65;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]
        public void GradingCalculator_InputScoreOrAttendanceLowerThan60_ReturnGradeF(int score, int attendance)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            string result = gradingCalculator.GetGrade();

            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 90, "A")]
        [InlineData(85, 90, "B")]
        [InlineData(65, 90, "C")]
        [InlineData(95, 55, "F")]
        [InlineData(65, 55, "F")]
        [InlineData(50, 90, "F")]
        public void GradingCalculator_InputScoreAndAttendance_ReturnExpectedGrade(int score, int attendance, string expectedResult)
        {
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendance;

            var result = gradingCalculator.GetGrade();

            Assert.Equal(expectedResult, result);
        }
    }
}
