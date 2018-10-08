using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patronus.Operators
{
    public class Reshape<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        public IEnumerable<int> Sizes { get; set; }

        public Reshape(IEnumerable<int> sizes)
        {
            this.Sizes = sizes;
        }

        protected override void DoInference()
        {
            var sizeList = Sizes.ToList();

            if (sizeList.Count(i => i == -1) > 1)
                throw new InvalidOperationException();

            var negativeIndexIndex = sizeList.IndexOf(-1);

            if (negativeIndexIndex != -1)
            {
                var i = sizeList.Where((t, j) => j != negativeIndexIndex).Aggregate(1, (current, t) => current * t);
                float negativeIndexInferredSize = (float)Param.VectorCount / (float)i;

                if (negativeIndexInferredSize % 1 > 0)
                    throw new InvalidOperationException();

                sizeList[negativeIndexIndex] = (int)negativeIndexInferredSize;
            }


            Param.SetSize(sizeList, false, false);
            Output = Param;
        }
    }
}
