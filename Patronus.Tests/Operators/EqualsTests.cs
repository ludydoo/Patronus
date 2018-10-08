using Patronus.Comparers;
using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class EqualsTests : BaseTest
    {

        private static MatrixEqualityComparer<T> Comp<T>() => new MatrixEqualityComparer<T>();

        [Fact]
        public void EqualMatrices()
        {
            var left = new Matrix<int>(2, 2).Sequence(1);
            var right = new Matrix<int>(2, 2).Sequence(1);
            var result = left.Equals(right);
            var expected = true;
            Print(left, right, result, expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DifferentValues()
        {
            var left = new Matrix<int>(2, 2).Sequence(1);
            var right = new Matrix<int>(2, 2).Sequence(2);
            var result = left.Equals(right);
            var expected = false;
            Print(left, right, result, expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ZeroDimensionalMatrix()
        {
            var left = new Matrix<int>(0);
            var right = new Matrix<int>(0);
            var result = left.Equals(right);
            var expected = true;
            Print(left, right, result, expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DifferentSizeMatrixWithSameData()
        {
            var left = new Matrix<int>(3, 2).Sequence(1);
            var right = new Matrix<int>(2, 3).Sequence(1);
            var result = left.Equals(right);
            var expected = false;
            Print(left, right, result, expected);
            Assert.Equal(expected, result);
        }

        public  EqualsTests(ITestOutputHelper output) : base(output)
        {
        }
    }
}
