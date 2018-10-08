using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;
using Patronus.Extensions;
using Patronus.Printers;

namespace Patronus.Operators
{
    public class Print<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {
        public IMatrixPrinter Printer { get; set; }

        public Print(IMatrixPrinter printer)
        {
            Printer = printer;
        }

        protected override void DoInference()
        {
            if (Printer == null)
                Printer = new LogPrinter();

            var matrix = Param;

            if (matrix.VectorCount == 0)
            {
                Printer.Print(new List<string>() { "+++", "+ +", "+++" });
                return;
            }

            var strMatrix = matrix.Map(arg => arg.ToString());

            var maxLen = strMatrix.Max(s => s.Length);



            strMatrix = strMatrix.Map(s =>
                {
                    s = s.PadLeft(maxLen);
                    var characters = new List<string>();
                    characters.Add(" ");
                    characters.AddRange(s.AsEnumerable().Select(c => c.ToString()));
                    characters.Add(" ");

                return new Matrix<string>(1, characters.Count).SetData(characters);
            })
                .Unwrap();

            strMatrix = strMatrix
                 .Flatten(strMatrix.DimensionCount, strMatrix.DimensionCount - 2, FlattenMode.Interpose);

            strMatrix = strMatrix
                .Flatten(strMatrix.DimensionCount, strMatrix.DimensionCount - 1, FlattenMode.Extend);

            strMatrix = strMatrix.Wrap().Map(matrix1 =>
            {
                var m = matrix1.Pad("+");
                var padding = new Matrix<string>(m.Sizes.ElementAt(0), 1).Fill("  ");
                m = m.Concat(padding, 1);
                return m;
            }).Unwrap();

            var current = strMatrix;

            while (current.DimensionCount > 2)
            {
                current = current.Flatten(current.DimensionCount - 2, current.DimensionCount, FlattenMode.Extend);
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
