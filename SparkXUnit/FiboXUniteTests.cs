using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sparky
{
    public class FiboXUniteTests
    {
        private Fibo fibo;

        public FiboXUniteTests()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void GenerateFiboSeries_Range1_GetListWithOneMember0()
        {
            fibo.Range = 1;
            List<int> expectedFiboSeries = new() { 0 };

            List<int> result = fibo.GetFiboSeries();

            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(x => x), result);
            Assert.Equal(expectedFiboSeries, result);
            //or
            Assert.True(result.SequenceEqual(expectedFiboSeries));
        }

        [Fact]
        public void GenerateFiboSeries_Range6_Get6NumbersSeries()
        {
            fibo.Range = 6;
            List<int> expectedFiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            List<int> result = fibo.GetFiboSeries();

            Assert.Contains(3, result);
            Assert.DoesNotContain(4, result);
            Assert.Equal(6, result.Count);
            Assert.Equal(expectedFiboSeries, result);
        }
    }
}
