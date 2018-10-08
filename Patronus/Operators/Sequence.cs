using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Numeric;

namespace Patronus.Operators
{
    public class Sequence<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        public Sequence(T start)
        {
            Start = start;
        }

        public T Start { get; set; }

        protected override void DoInference()
        {
            var matrix = Param;
            var i = 0;
            INumeric<T> numeric = new Numeric.Numeric() as INumeric<T>;
            if (numeric == null) throw new InvalidOperationException();

            while (i < matrix.VectorCount)
            {
                matrix.Vectors[i] = Start;
                Start = numeric.Add(Start, numeric.One);
                i += 1;
            }

            Output = matrix;
        }
    }
}
