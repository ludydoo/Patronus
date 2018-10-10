using System.Collections.Generic;

namespace Patronus.Printers
{
    public interface IMatrixPrinter
    {
        void Print(IEnumerable<string> matrixStr);
    }

    public class StringListPrinter : IMatrixPrinter
    {
        public IEnumerable<string> Output;

        public void Print(IEnumerable<string> matrixStr)
        {
            Output = matrixStr;
        }
    }

}