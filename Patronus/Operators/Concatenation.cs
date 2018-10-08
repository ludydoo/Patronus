using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;

namespace Patronus.Operators
{

    /// <summary>
    /// Concatenates two matrices in the given dimension
    /// </summary>
    /// <typeparam name="T">The data type of the matrices to concatenate</typeparam>
    public class Concatenation<T> : BinaryOperator<Matrix<T>, Matrix<T>, Matrix<T>>
    {
        private int DimensionIndex { get; }

        public Concatenation(int dimensionIndex)
        {
            DimensionIndex = dimensionIndex;
        }

        protected override void DoInference()
        {

            var matrix = Left;
            var other = Right;

            // Checks that two matrices have the same number of dimensions
            if (matrix.DimensionCount != other.DimensionCount)
                throw new InvalidOperationException("The two matrixes must have the same number of dimensions");

            // Gets the sizes of the dimensions (other than the concatenated dimension)
            // And checks that they're all of the same size

            var sizeA = matrix.Sizes.Where((element, index) => index != DimensionIndex);
            var sizeB = other.Sizes.Where((element, index) => index != DimensionIndex);

            if (!sizeA.SequenceEqual(sizeB))
                throw new InvalidOperationException(
                    $"The arrays must be of same size in all other dimensions than {DimensionIndex}");

            if (matrix.DimensionCount < DimensionIndex)
                throw new InvalidOperationException(
                    $"The matrixes are of dimension {matrix.DimensionCount}, cannot concatenate on dimension {DimensionIndex}. Max possible value is {matrix.DimensionCount}");

            // The resulting matrix size
            var resultSizes = matrix.Sizes.ToList();

            // DimensionIndex < 0
            if (DimensionIndex < 0)
            {
                // In this case, we add dimensions "before" 
                var intermediarySizes = Enumerable.Repeat(1, DimensionIndex * -1 - 1).ToList();
                intermediarySizes.Insert(0, 2);

                intermediarySizes.AddRange(resultSizes);
                resultSizes = intermediarySizes;
            }

            else
            // Otherwise, we add the two dimension sizes for the corresponding index
            {
                resultSizes[DimensionIndex] = resultSizes[DimensionIndex] + other.Sizes.ElementAt(DimensionIndex);
            }


            // The resulting matrix
            var result = new Matrix<T>(resultSizes);

            // We create an enumerator to iterate through our indices
            var indexEnumerator = new IndexEnumerator(resultSizes);

            if (DimensionIndex < 0)
            {
                for (var i = 0; i < matrix.VectorCount; i++)
                    result.Vectors[i] = matrix.Vectors[i];

                for (var i = matrix.VectorCount; i < matrix.VectorCount + other.VectorCount; i++)
                    result.Vectors[i] = other.Vectors[i - matrix.VectorCount];

                Output = result;
                return;
            }

            while (indexEnumerator.MoveNext())
            {

                var currentIndexes = indexEnumerator.Current.ToList();
                var fromMatrixIndex = currentIndexes.ToList();

                Matrix<T> fromMatrix;

                if (DimensionIndex == -1)
                {
                    switch (currentIndexes[0])
                    {
                        case 0:
                            fromMatrix = matrix;
                            fromMatrixIndex.RemoveAt(0);
                            break;
                        case 1:
                            fromMatrix = other;
                            fromMatrixIndex.RemoveAt(0);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (currentIndexes.ElementAt(DimensionIndex) >= matrix.Sizes.ElementAt(DimensionIndex))
                {
                    fromMatrix = other;
                    fromMatrixIndex[DimensionIndex] =
                        currentIndexes[DimensionIndex] - matrix.Sizes.ElementAt(DimensionIndex);
                }
                else
                {
                    fromMatrix = matrix;
                }

                result[currentIndexes] = fromMatrix[fromMatrixIndex];
            }

            Output = result;
        }
    }
}
