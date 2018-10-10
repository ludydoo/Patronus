using System.Collections.Generic;
using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class UnwrapTests : BaseTest
    {

        [Fact]
        public void TestWrap()
        {

            var source = new Matrix<int>(2, 2, 2).Sequence(1);
            var matrix = source.Wrap();
            var result = matrix.Unwrap();

            var expected = source;

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));

        }
        

        public UnwrapTests(ITestOutputHelper output) : base(output)
        {
        }
    }
}
