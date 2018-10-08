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

        protected override void DoInference()
        {
            for (var i = Param.Sizes.Count() - 1; i >= 0; i--)
            {
                if (Param.Sizes.ElementAt(i) != 1) continue;

                Param.DimensionVectorCount.RemoveAt(i);
                Param.DimensionCount -= 1;
                Param._sizes.RemoveAt(i);
            }

            Param.DimensionCount = Param._sizes.Count;
        }
    }
}
