using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;

namespace Patronus.Operators
{

    /// <summary>
    /// Operator that wraps the number of dimensions in a sub matrix
    /// </summary>
    /// <typeparam name="T">Data type of the matrix</typeparam>
    public class Wrap<T> : UnaryOperator<Matrix<T>, Matrix<Matrix<T>>>
    {

        public const int DefaultDimensions = 2;

        private int Dimensions { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dimensions">The number of dimensions to wrap</param>
        public Wrap(int dimensions = DefaultDimensions)
        {
            Dimensions = dimensions;
        }


        protected override void DoInference()
        {
            var matrix = Param;
        
            var windowSize = Enumerable.Repeat(1, matrix.DimensionCount - Dimensions).ToList();
            var resultSize = matrix.Sizes.Take(matrix.DimensionCount - Dimensions);
            var wrapSize = new List<int>();

            if (Dimensions == 0)
                wrapSize.Add(1);
            else
                for (var i = 0; i < Dimensions; i++)
                {
                    var dimensionSize = matrix.Sizes.ElementAt(matrix.DimensionCount - Dimensions + i);
                    windowSize.Add(dimensionSize);
                    wrapSize.Add(dimensionSize);
                }


            var enumerator = new MatrixWindowEnumerator<T>(matrix, windowSize);

            var slices = new List<Matrix<T>>();

            while (enumerator.MoveNext())
            {
                var m = new Matrix<T>(wrapSize, enumerator.Current.Matrix.Vectors);
                slices.Add(m);
            }

            Output = new Matrix<Matrix<T>>(resultSize, slices);
        }
    }
}
