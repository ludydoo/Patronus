using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patronus.Operators
{

    /// <summary>
    /// Operator that removes size-one dimensions from a matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Squeeze<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        private readonly IEnumerable<int> _dimensions;

        public Squeeze(params int[] dimensions)
        {
            _dimensions = dimensions;
        }

        protected override void DoInference()
        {
            for (var i = Param.Sizes.Count() - 1; i >= 0; i--)
            {

                if (Param.Sizes.ElementAt(i) != 1) continue;

                if (_dimensions.Any() && !_dimensions.Contains(i)) continue;

                Param.DimensionVectorCount.RemoveAt(i);
                Param.DimensionCount -= 1;
                Param._sizes.RemoveAt(i);

            }

            Param.DimensionCount = Param._sizes.Count;

            Output = Param;

        }
    }
}
