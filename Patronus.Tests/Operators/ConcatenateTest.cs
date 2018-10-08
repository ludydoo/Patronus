using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;
using Pat = Patronus.Patronus;

namespace Patronus.Tests.Operators
{
    public class ConcatenateTest : BaseTest
    {



        [Fact]
        public void TestConcatenationFirstAxis()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 2, 2, 2);

            var result = matrix1.Concat(matrix2, 0);
            var expected = Pat.Sequence(1, 4, 2, 2);

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcatenationSecondAxis()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 2, 2, 2);

            var result = matrix1.Concat(matrix2, 1);
            var expected = Pat.From(1, 2, 3, 4, 9, 10, 11, 12, 5, 6, 7, 8, 13, 14, 15, 16).Reshape(2, 4, 2);           

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcatenationThirdAxis()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 2, 2, 2);

            var result = matrix1.Concat(matrix2, 2);

            var expected = Pat.From(1, 2, 9, 10, 3, 4, 11, 12, 5, 6, 13, 14, 7, 8, 15, 16).Reshape(2, 2, 4);

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcatenationNegativeAxis()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 2, 2, 2);

            var result = matrix1.Concat(matrix2, -2);
            var expected = Pat.Sequence(1, 2, 1, 2, 2, 2);

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcatenationDifferentSize()
        {

            var matrix1 = Pat.Sequence(1, 4, 2, 2);
            var matrix2 = Pat.Sequence(17, 2, 2, 2);

            var result = matrix1.Concat(matrix2, 0);
            var expected = Pat.Sequence(1, 6, 2, 2);

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcatenationZeroSize()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 0, 2, 2);

            var result = matrix1.Concat(matrix2, 0);
            var expected = Pat.Sequence(1, 2, 2, 2);

            Print(matrix1, matrix2, result, expected);

            Assert.True(expected.Equals(result));

        }

        [Fact]
        public void TestConcat()
        {

            var matrix1 = Pat.Sequence(1, 2, 2, 2);
            var matrix2 = Pat.Sequence(9, 2, 2, 2);
            var concat1 = matrix1.Concat(matrix2, 2);

            var matrix3 = Pat.Sequence(17, 2, 2, 2);
            var concat2 = concat1.Concat(matrix3, 2);

            concat2.Print(Printer);
        }


        public ConcatenateTest(ITestOutputHelper output) : base(output)
        {


        }


    }
}
