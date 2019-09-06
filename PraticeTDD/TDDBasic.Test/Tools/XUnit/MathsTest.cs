using Xunit;
using Zhangyi.PracticeTDD.TDDBasic.Tools.XUnit;

namespace Zhangyi.PracticeTDD.TDDBasic.Test.Tools.XUnit
{
    public class MathsTest
    {
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void Should_be_odd_numbers(int number)
        {
            Assert.True(Maths.IsOdd(number));
        }

        [Theory]
        [InlineData(5, 2, 3)]
        [InlineData(0, -5, 5)]
        [InlineData(9999, 10000, -1)]
        [InlineData(100, 100, 0)]
        public void Should_get_sum(int sum, int x, int y)
        {
            Assert.Equal(sum, Maths.Add(x, y));
        }
    }
}