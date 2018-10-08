using System.Collections.Generic;

namespace Patronus.Printers
{
    public interface IMatrixPrinter
    {
        void Print(IEnumerable<string> matrixStr);
    }
}