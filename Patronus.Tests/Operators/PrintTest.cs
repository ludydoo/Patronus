using System.Collections.Generic;
using Moq;
using Patronus.Extensions;
using Patronus.Printers;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{

    public class PrintTest : BaseTest
    {



        [Fact]
        public void TestPrint()
        {

            var matrix = new Matrix<int>(2, 2).Sequence(1);

            var printer = new Mock<IMatrixPrinter>();
            printer.Setup(matrixPrinter => matrixPrinter.Print(It.IsAny<IEnumerable<string>>()));

            matrix.Print(printer.Object);

            var expected = new List<string>()
            {
                " ++++++++ ",
                " + 1  2 + ",
                " + 3  4 + ",
                " ++++++++ "
            };

            matrix.Print(Printer);

            printer.Verify(matrixPrinter => matrixPrinter.Print(expected));

        }

        [Fact]
        public void TestPrint4d()
        {

            var matrix = new Matrix<int>(2, 2, 2, 2).Sequence(1);

            Print(matrix);

        }

        [Fact]
        public void TestPrint1s()
        {

            var matrix = new Matrix<int>(2).Sequence(1);

            Print(matrix);

        }


        [Fact]
        public void TestPrintWrapped()
        {

            var matrix = new Matrix<int>(2, 2, 2, 2).Sequence(1).Wrap();

            Print(matrix);

        }

        public PrintTest(ITestOutputHelper output) : base(output)
        {
        }
    }
}
