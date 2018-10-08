using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;

namespace Patronus.Operators
{
    public class Pad<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        public T PaddingValue { get; set; }

        public Pad(T paddingValue)
        {
            PaddingValue = paddingValue;
        }

        protected override void DoInference()
        {
            var matrix = Param;
            var value = PaddingValue;

            if (matrix.VectorCount == 0)
            {
                Output = new Matrix<T>(0);
                return;
            }

            var resultSize = matrix.Sizes.Select(i => i + 2);
            var result = new Matrix<T>(resultSize);
            result.Fill(value);

            var enumerator = new MatrixIndexEnumerator<T>(result);
            var dimensions = matrix.DimensionCount;

            while (enumerator.MoveNext())
            {
                var i = 0;
                var firstElementFlag = false;
                while (i < dimensions)
                {
                    firstElementFlag = enumerator.Current.ElementAt(i) == 0 ||
                                       enumerator.Current.ElementAt(i) == matrix.Sizes.ElementAt(i) + 1;
                    if (firstElementFlag)
                        break;
                    i++;
                }

                if (!firstElementFlag)
                    result[enumerator.Current] = matrix[enumerator.Current.Select(i1 => i1 - 1)];
            }

            Output = result;
        }
    }
}
