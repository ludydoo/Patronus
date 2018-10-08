using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Numeric;

namespace Patronus.Operators
{
    public class Randomize<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        public T Min { get; set; }
        public T Max { get; set; }

        public Randomize(T min, T max)
        {
            Min = min;
            Max = max;
        }

        protected override void DoInference()
        {
            var matrix = Param;

            var numeric = new Numeric.Numeric() as INumeric<T>;
            if (!(numeric != null)) throw new ArgumentNullException(nameof(numeric));

            var vectorCount = matrix.VectorCount;
            for (var i = 0; i < vectorCount; i++)
                matrix.Vectors[i] = numeric.Random(Min, Max);

            Output = matrix;
        }
    }
}
