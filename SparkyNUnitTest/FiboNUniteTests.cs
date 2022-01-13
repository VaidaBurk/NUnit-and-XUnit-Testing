using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class FiboNUniteTests
    {
        private Fibo _fibo;
        [SetUp]
        public void Setup()
        {
            _fibo = new Fibo();
        }

        [Test]
        public void GenerateFiboSeries_Range1_GetNotEmptyOrderedListWithOneMember0()
        {
            _fibo.Range = 1;
            List<int> expectedFiboSeries = new() { 0 };

            List<int> result = _fibo.GetFiboSeries();

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedFiboSeries));
        }

        [Test]
        public void GenerateFiboSeries_Range6_Get6NumbersSeries()
        {
            _fibo.Range = 6;
            List<int> expectedFiboSeries = new() { 0, 1, 1, 2, 3, 5 };

            List<int> result = _fibo.GetFiboSeries();

            Assert.That(result.Contains(3), Is.True);
            Assert.That(result.Count, Is.EqualTo(6));
            Assert.That(result.Contains(4), Is.False);
            Assert.That(result, Is.EquivalentTo(expectedFiboSeries));
        }
    }
}
