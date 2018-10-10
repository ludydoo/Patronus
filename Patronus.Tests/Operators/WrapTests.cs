using System.Collections.Generic;
using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class WrapTests : BaseTest
    {

        [Fact]
        public void TestWrap()
        {

            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);

            var result = matrix.Wrap();

            var expected = new Matrix<Matrix<int>>(2).SetData(new List<Matrix<int>>()
            {
                new Matrix<int>(2, 2).SetData(new []{1, 2, 3, 4}),
                new Matrix<int>(2, 2).SetData(new []{5, 6, 7, 8})
            });

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));
            Assert.True(matrix.Equals(result.Unwrap()));

        }

        [Fact]
        public void TestWrapOneDimension()
        {

            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);

            var result = matrix.Wrap(1);

            var expected = new Matrix<Matrix<int>>(2, 2).SetData(new List<Matrix<int>>()
            {
                new Matrix<int>(2).SetData(new []{1, 2}),
                new Matrix<int>(2).SetData(new []{3, 4}),
                new Matrix<int>(2).SetData(new []{5, 6}),
                new Matrix<int>(2).SetData(new []{7, 8}),
            });

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));
            Assert.True(matrix.Equals(result.Unwrap()));

        }

        [Fact]
        public void TestWrapZeroDimension()
        {

            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);

            var result = matrix.Wrap(0);

            var expected = new Matrix<int>(2, 2, 2).Sequence(1).Map(i => new Matrix<int>(1).SetData(new []{i}));

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));
        }

        [Fact]
        public void TestWrap4d()
        {

            var matrix = new Matrix<int>(2, 2, 2, 2).Sequence(1);

            var result = matrix.Wrap();

            var expected = new Matrix<Matrix<int>>(2, 2).SetData(new List<Matrix<int>>()
            {
                new Matrix<int>(2, 2).SetData(new []{1, 2, 3, 4}),
                new Matrix<int>(2, 2).SetData(new []{5, 6, 7, 8}),
                new Matrix<int>(2, 2).SetData(new []{9, 10, 11, 12}),
                new Matrix<int>(2, 2).SetData(new []{13, 14, 15, 16})
            });

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));
            Assert.True(matrix.Equals(result.Unwrap()));

        }


        public WrapTests(ITestOutputHelper output) : base(output)
        {
        }
    }
}
