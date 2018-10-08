using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;
using Patronus.Extensions;
using Patronus.Numeric;

namespace Patronus.Operators
{
    public class Convolution<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        private readonly INumeric<T> _numeric = new Numeric.Numeric() as INumeric<T>;

        public IEnumerable<int> WindowSize { get; set; }

        public IEnumerable<int> Strides { get; set; }

        public IEnumerable<T> Kernel { get; set; }

        public int Padding { get; set; }

        public Convolution(IEnumerable<int> windowSize, IEnumerable<T> kernel, IEnumerable<int> strides, int padding)
        {
            WindowSize = windowSize;
            Kernel = kernel;
            Strides = strides;
            Padding = padding;
        }

        protected override void DoInference()
        {

            var matrix = Param;
            var padding = Padding;

            while (padding > 0)
            {
                matrix = matrix.Pad(_numeric.Zero);
                padding--;
            }

            var enumerator = new MatrixWindowEnumerator<T>(matrix, WindowSize, Strides);

            var result = new Matrix<T>(enumerator.Strides());

            var c = 0;

            while (enumerator.MoveNext())
            {
                var accumulator = _numeric.Zero;
                enumerator.Current.Matrix.ForEach((indexes, index, vector) =>
                    {
                        accumulator = _numeric.Add(accumulator, _numeric.Mult(Kernel.ElementAt(index), vector));
                    });
                result.Vectors[c] = accumulator;
                c++;
            }

            Output = result;
        }
    }
}
