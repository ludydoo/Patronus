using Patronus.Comparers;
using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class PaddingTest : BaseTest
    {

        [Fact]
        public void TestPadding()
        {
            var matrix = new Matrix<int>(2, 2).Sequence(1);
            var result = matrix.Pad(0);
            var expected = new Matrix<int>(4, 4).SetData(new []{0,0,0,0,0,1,2,0,0,3,4,0,0,0,0,0});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestPaddingOneDimension()
        {
            var matrix = new Matrix<int>(1, 1).Sequence(1);
            var result = matrix.Pad(0);
            var expected = new Matrix<int>(3, 3).SetData(new[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 });

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestPaddingZeroDimension()
        {
            var matrix = new Matrix<int>(0);
            var result = matrix.Pad(0);
            var expected = new Matrix<int>(0);

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        public PaddingTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
