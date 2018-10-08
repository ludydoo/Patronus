using System;
using System.Collections.Generic;
using System.Text;
using log4net;

namespace Patronus.Printers
{
    public class LogPrinter : IMatrixPrinter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(LogPrinter));

        public void Print(IEnumerable<string> matrixStr)
        {
            foreach (var s in matrixStr)
            {
                Logger.Info(s);
            }
        }
    }
}
