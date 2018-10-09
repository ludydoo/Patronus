using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;
using Patronus.Extensions;
using Patronus.Printers;

namespace Patronus.Operators
{
    /// <summary>
    /// Prints a matrix
    /// </summary>
    /// <typeparam name="T">Data type of the matrix</typeparam>
    public class Print<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {
        private IMatrixPrinter Printer { get; set; }

        public Print(IMatrixPrinter printer)
        {
            Printer = printer;
        }

        protected override void DoInference()
        {
            // Default printer
            if (Printer == null)
                Printer = new LogPrinter();

            var matrix = Param;

            // Print an empty matrix
            if (matrix.VectorCount == 0)
            {
                Printer.Print(new List<string>() { "+++", "+ +", "+++" });
                return;
            }

            // Convert to string
            var strMatrix = matrix.Map(arg => arg.ToString());

            // Maximum str length
            var maxLen = strMatrix.Max(s => s.Length);

            // Convert to char matrix
            strMatrix = strMatrix.Map(s =>
                {
                    s = " " + s.PadLeft(maxLen) + " ";
                    return new Matrix<string>(1, s.Length).SetData(s.AsEnumerable().Select(c => c.ToString()));
                })
                .Unwrap();

            // Remove size 1 dimension
            strMatrix = strMatrix.Squeeze(strMatrix.DimensionCount - 2);

            strMatrix = strMatrix
                 .Flatten(strMatrix.DimensionCount - 1, strMatrix.DimensionCount - 2, FlattenMode.Interpose);

            // strMatrix = strMatrix
            //    .Flatten(strMatrix.DimensionCount - 3, strMatrix.DimensionCount - 2, FlattenMode.Extend);

            strMatrix = strMatrix.Wrap().Map(matrix1 =>
            {
                var m = matrix1.Pad("+");
                var padding = new Matrix<string>(m.Sizes.ElementAt(0), 1).Fill(" ");
                m = padding.Concat(m, 1).Concat(padding, 1);
                return m;
            }).Unwrap();

            var current = strMatrix;

            var odd = true;

            while (current.DimensionCount > 2)
            {

                var dimensionTo = odd ? current.DimensionCount - 2 : current.DimensionCount - 1;                                

                current = current.Flatten(current.DimensionCount - 3, dimensionTo, FlattenMode.Extend);
                current = current.Wrap().Map(matrix1 =>
                {
                    var paddingChar = odd ? "x" : "+";
                    var m = matrix1.Pad(paddingChar);
                    var paddingWidth = 1;
                    var paddingHeight = m.Sizes.ElementAt(0);
                    var paddingDimension = 1;
                    var padding = new Matrix<string>(paddingHeight, paddingWidth).Fill(" ");

                    return padding.Concat(m, 1).Concat(padding, 1);

                }).Unwrap();

                odd = !odd;

            }

            var enumerator = new MatrixWindowEnumerator<string>(current, new[] { 1, current.Sizes.ElementAt(1) });
            var res = new List<string>();
            while (enumerator.MoveNext())
            {
                res.Add(string.Join("", enumerator.Current.Matrix.Vectors));
            }

            Printer.Print(res);

            Output = matrix;

        }
    }
}
