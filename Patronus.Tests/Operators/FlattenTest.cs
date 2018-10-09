using Patronus.Comparers;
using Patronus.Extensions;
using Patronus.Operators;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable RedundantArgumentDefaultValue

namespace Patronus.Tests.Operators
{
    public class FlattenTest : BaseTest
    {

        [Fact]
        public void TestFlatten_1_2_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);        
            var result = matrix.Flatten(0, 1, FlattenMode.Extend);
            var expected = new Matrix<int>(4, 2).Sequence(1);

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());        
        }

        [Fact]
        public void TestFlatten_1_3_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(0, 2, FlattenMode.Extend);
            var expected = new Matrix<int>(2, 4).SetData(new[] {1, 2, 5, 6, 3, 4, 7, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_2_3_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(1, 2, FlattenMode.Extend);
            var expected = new Matrix<int>(2, 4).Sequence(1);

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_2_1_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(1, 0, FlattenMode.Extend);
            var expected = new Matrix<int>(4, 2).SetData(new[] {1, 2, 5, 6, 3, 4, 7, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_3_1_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(2, 0, FlattenMode.Extend);
            var expected = new Matrix<int>(4, 2).SetData(new[] { 1, 3, 5, 7, 2, 4, 6, 8 });

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_3_2_Extend()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(2, 1, FlattenMode.Extend);
            var expected = new Matrix<int>(2, 4).SetData(new[] {1, 3, 2, 4, 5, 7, 6, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }


        [Fact]
        public void TestFlatten_1_2_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(0, 1, FlattenMode.Interpose);
            var expected = new Matrix<int>(4, 2).SetData(new []{1, 2, 5, 6, 3, 4, 7, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_1_3_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(0, 2, FlattenMode.Interpose);
            var expected = new Matrix<int>(2, 4).SetData(new[] { 1, 5, 2, 6, 3, 7, 4, 8 });

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_2_3_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(1, 2, FlattenMode.Interpose);
            var expected = new Matrix<int>(2, 4).SetData(new[] {1, 3, 2, 4, 5, 7, 6, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_2_1_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(1, 0, FlattenMode.Interpose);
            var expected = new Matrix<int>(4, 2).SetData(new[] { 1, 2, 3, 4, 5, 6, 7, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_3_1_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(2, 0, FlattenMode.Interpose);
            var expected = new Matrix<int>(4, 2).SetData(new[] { 1, 3, 2, 4, 5, 7, 6, 8 });

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        [Fact]
        public void TestFlatten_3_2_Interpose()
        {
            var matrix = new Matrix<int>(2, 2, 2).Sequence(1);
            var result = matrix.Flatten(2, 1, FlattenMode.Interpose);
            var expected = new Matrix<int>(2, 4).SetData(new[] { 1, 2, 3, 4, 5, 6, 7, 8});

            Print(matrix, result, expected);

            Assert.Equal(expected, result, new MatrixEqualityComparer<int>());
        }

        public FlattenTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
