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

            // Get all vector string representations
            // as a list of strings        
            var strVectors = matrix.Vectors.Select(v =>
            {
                var str = v.ToString();
                var lines = str.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None
                );

                var maxCount = lines.Max(s => s.Length);

                for (var i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].PadRight(maxCount);
                }

                return lines.ToList();

            }).ToList();

            // This is the max number of lines for any vector
            var maxLineCount = strVectors.Max(strings => strings.Count);

            // This is the max number of chars in any line for any vector
            var maxCharCount = strVectors.Max(strings => strings.Max(s => s.Length));

            // This is an empty line (will be used to pad)
            var emptyLine = string.Join("", Enumerable.Repeat(" ", maxCharCount));

            // Coerce all lines of all vectors to have the same length
            // Coerce all vectors to have the same number of lines
            foreach (var vector in strVectors)
            {
                while (vector.Count < maxLineCount)
                    vector.Add(emptyLine);
                for (var i = 0; i < vector.Count; i++)
                    vector[i] = " " + vector[i].PadLeft(maxCharCount) + " " ;
            }

            maxCharCount += 2;


            var strMatrices = strVectors.Select(strings =>
            {
                // Create a matrix for each vector
                var sMatrix = new Matrix<string>(new[] {maxLineCount, maxCharCount});

                var chars = new List<string>();
                foreach (var line in strings)
                {
                    foreach (var c in line)
                    {
                        chars.Add(c.ToString());
                    }
                }

                sMatrix.SetData(chars);
                return sMatrix;

            }).ToList();

            // Contains all matrices of all vectors
            var strMatrix = new Matrix<Matrix<string>>(matrix.Sizes).SetData(strMatrices).Unwrap(UnwrapMode.Expand);

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

                var dimensionTo = odd ? current.DimensionCount - 1 : current.DimensionCount - 2;

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
