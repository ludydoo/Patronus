using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class ReshapeTest : BaseTest
    {
        public ReshapeTest(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void TestReshape()
        {

            var matrix = Patronus.Sequence(1, 2, 2);
            var result = matrix.Reshape(1, 4);
            var expected = Patronus.Sequence(1, 1, 4);

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestReshape3d()
        {

            var matrix = Patronus.Sequence(1, 2, 2, 2);
            var result = matrix.Reshape(1, 4, 2);
            var expected = Patronus.Sequence(1, 1, 4, 2);

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestReshapeNegativeIndex()
        {

            var matrix = Patronus.Sequence(1, 2, 2, 2);
            var result = matrix.Reshape(1, 4, -1);
            var expected = Patronus.Sequence(1, 1, 4, 2);

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestReshapeNegativeIndex2()
        {

            var matrix = Patronus.Sequence(1, 2, 2, 2);
            var result = matrix.Reshape(1, -1, 2);
            var expected = Patronus.Sequence(1, 1, 4, 2);

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));

        }


        [Fact]
        public void TestReshapeTwoNegativeIndex()
        {

            var matrix = Patronus.Sequence(1, 2, 2, 2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                matrix.Reshape(1, -1, -1);
            });

        }

        [Fact]
        public void TestReshapeTwoNegativeIndexInvalidFactor()
        {

            var matrix = Patronus.Sequence(1, 2, 2, 2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                matrix.Reshape(1, 3, -1);
            });

        }

    }
}
