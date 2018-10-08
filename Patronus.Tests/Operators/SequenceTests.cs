using Patronus.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class SequenceTests : BaseTest
    {

        [Fact]
        public void SequenceTest()
        {
            var matrix = new Matrix<int>(2, 2);
            var result = matrix.Sequence(1);
            var expected = new Matrix<int>(2, 2).SetData(new []{1, 2, 3, 4});
            
            Print(matrix, result, expected);

            Assert.True(matrix.Equals(result));
        }

        public SequenceTests(ITestOutputHelper output) : base(output)
        {
        }
    }
}
