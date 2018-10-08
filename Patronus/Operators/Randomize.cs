using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Numeric;

namespace Patronus.Operators
{

    /// <summary>
    /// Randomizes the values of a matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Randomize<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        private T Min { get; set; }
        private T Max { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        public Randomize(T min, T max)
        {
            Min = min;
            Max = max;
        }

        protected override void DoInference()
        {
            var matrix = Param;

            var numeric = new Numeric.Numeric() as INumeric<T>;
            if (numeric == null) throw new ArgumentNullException(nameof(numeric));

            var vectorCount = matrix.VectorCount;
            for (var i = 0; i < vectorCount; i++)
                matrix.Vectors[i] = numeric.Random(Min, Max);

            Output = matrix;
        }
    }
}
