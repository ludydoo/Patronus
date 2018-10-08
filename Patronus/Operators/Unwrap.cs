using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Patronus.Enumerators;

namespace Patronus.Operators
{


    public enum UnwrapMode
    {
        Discrete,
        Expand
    }

    public class Unwrap<T> : UnaryOperator<Matrix<Matrix<T>>, Matrix<T>>
    {
        internal const UnwrapMode DefaultMode = UnwrapMode.Discrete;

        public UnwrapMode Mode { get; set; }

        public Unwrap(UnwrapMode mode = DefaultMode)
        {
            Mode = mode;
        }

        protected override void DoInference()
        {
            var matrix = Param;

            var sizes1 = matrix.Sizes.ToList();
            var sizes2 = matrix.Vectors[0].Sizes.ToList();

            List<int> size;

            var c = 0;

            switch (Mode)
            {
                case UnwrapMode.Discrete:

                    size = sizes1.ToList();
                    size.AddRange(sizes2);

                    break;

                case UnwrapMode.Expand:

                    size = sizes1.ToList();

                    var i = 0;
                    while (i < sizes2.Count)
                    {
                        size[sizes1.Count - sizes2.Count - 1 + i] =
                            size[sizes1.Count - sizes2.Count - 1 + i] * sizes2[i];
                        i++;
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);

            }


            var result = new Matrix<T>(size);

            var enumerator = new IndexEnumerator(size);

            while (enumerator.MoveNext())
            {
                var subMatrix = matrix[enumerator.Current.Take(matrix.DimensionCount)];
                var vector = subMatrix[enumerator.Current.Skip(matrix.DimensionCount)];
                result.Vectors[c] = vector;
                c++;
            }


            Output = result;
        }
    }
}
