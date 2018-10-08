using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patronus.Operators
{
    /// <summary>
    /// This maps a matrix to another matrix using a mapping function
    /// </summary>
    /// <typeparam name="T">The type of the input matrix</typeparam>
    /// <typeparam name="TType">The type of the output matrix</typeparam>
    public class Map<T, TType> : UnaryOperator<Matrix<T>, Matrix<TType>>
    {

        public Map(Func<T, TType> mapFunc)
        {
            MapFunc = mapFunc;
        }

        public Func<T, TType> MapFunc { get; set; }

        protected override void DoInference()
        {
            Output = new Matrix<TType>(Param.Sizes, Param.Select(MapFunc));
        }

    }
}
