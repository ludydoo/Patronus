using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patronus.Operators
{
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
