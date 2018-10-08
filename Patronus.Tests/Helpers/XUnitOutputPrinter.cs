using System.Collections.Generic;
using Patronus.Extensions;
using Patronus.Printers;
using Xunit.Abstractions;

namespace Patronus.Tests.Helpers
{
    public class XUnitOutputPrinter : IMatrixPrinter
    {

        private readonly ITestOutputHelper output;

        public XUnitOutputPrinter(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Print(IEnumerable<string> matrixStr)
        {
            foreach (var s in matrixStr)
            {
                output.WriteLine(s);
            }
        }
    }
}
