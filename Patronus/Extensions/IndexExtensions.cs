using System;
using System.Collections.Generic;
using System.Linq;

namespace Patronus.Extensions
{
    public static class IndexExtensions
    {
        /// <summary>
        /// Increments the given dimensional index by 1
        /// </summary>
        /// <param name="indexes">The dimensional index</param>
        /// <param name="sizes">The sizes of the dimensions</param>
        /// <param name="amount">The increment</param>
        /// <returns>The incremented dimensional index</returns>
        public static IList<int> IncrementIndex(this IList<int> indexes, IEnumerable<int> sizes, int amount = 1)
        {

            // We iterate over every dimension, starting by the last one
            var currentIndexIndex = indexes.Count() - 1;

            // Flag indicating that the previous dimension was filled.
            // That the increment has to be ported to the higher dimension
            var remainder = true;

            // Get list of indexes. Suppresses IDE warning
            indexes = indexes.Select(a => a).ToList();

            // The sizes of the dimensions in which to increase the index
            var sizeList = sizes.ToList();

            // We will iterate until we don't have anything to add
            while (amount > 0)
            {
                
                // Continue until no remainder left
                while (remainder && currentIndexIndex != -1)
                {

                    // The current index at the given index (index of index)
                    var currentValue = indexes.ElementAt(currentIndexIndex);

                    if (currentValue == sizeList.ElementAt(currentIndexIndex) - 1)
                    {
                        // If the increment would fill the dimension,
                        // Port the increment to the next dimension
                        indexes[currentIndexIndex] = 0;
                        currentIndexIndex -= 1;
                    }
                    else
                    {
                        // Otherwise, increase the index
                        indexes[currentIndexIndex] = currentValue + 1;
                        remainder = false;
                    }
                }

                amount--;
            }

           
            return indexes;
        }


        /// <summary>
        /// Checks if the given index is the last index in the given
        /// dimensions sizes
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public static bool IsLastIndex(this IEnumerable<int> indexes, IEnumerable<int> sizes) => indexes.Select(i => i + 1).SequenceEqual(sizes);


        /// <summary>
        /// Adds two dimensional indexes. Warning, this does not checks that the given index is valid
        /// in a dimensional space. It just adds the indexes positionnally.
        /// </summary>
        /// <param name="indexes"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IList<int> AddIndexes(this IList<int> indexes, IList<int> b) => indexes.Select((element, index) => element + b[index]).ToList();


        /// <summary>
        /// Gets the number of strides a given window
        /// will have to scroll to iterate over the
        /// whole matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="windowSize">The window sizes in each dimension</param>
        /// <param name="strides">The number of steps taken in each dimension</param>
        /// <returns>The number of required steps in each dimension</returns>
        public static IList<int> GetStepsCount(this Matrix matrix, IEnumerable<int> windowSize,
            IEnumerable<int> strides)
        {

            // TODO: We don't check that the windowSize for a specific dimension divides the matrix size for that dimension.
            // For example, a matrix of size 5x2 and a window of size 4x2 and a stride of 2x1
            // We would miss some of the data in the first dimension.
            // Step 1 : Window is at 0,0 (size 4x2)
            // Step 2 : Window would be at 2,0 (size 4x2) would not be valid (2,0 + 4,2 = 6,2). Doesn't exist. 

            // The result
            var result = Indexes.Initialize(matrix.DimensionCount);

            // Possible multiple iteration over IEnumerable
            var windowSizeList = windowSize.ToList();
            var strideList = strides.ToList();

            // We iterate through every dimension
            for (var i = 0; i < matrix.DimensionCount; i++)
            {

                // We get the size of the current dimension
                var dimensionSize = matrix.Sizes.ElementAt(i);

                // We get the size of the window for that dimension                
                var dimensionWindowSize = windowSizeList.ElementAt(i);

                // If the window is bigger than the dimension,
                // we've got a problem
                if (dimensionWindowSize > dimensionSize)
                    throw new InvalidOperationException(
                        $"Window size for dimension {i} cannot be bigger than {dimensionSize}, but is {dimensionWindowSize}");

                // If the dimension of the window is negative,
                // It doesn't make any sense
                if (dimensionWindowSize < 1)
                    throw new InvalidOperationException($"Window size for dimension {i} cannot be smaller than 1");

                // We calculate the number of steps.
                result[i] = 1 + (int) Math.Floor((double) (dimensionSize - dimensionWindowSize) / strideList[i]);
            }

            return result;
        }


        /// <summary>
        /// Converts a vector index (in a list) to a multi-dimensional index
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <param name="index">The index to convert</param>
        /// <returns></returns>
        public static IList<int> ConvertToDimensionalIndex(this Matrix matrix, int index)
        {
            // The result
            var result = new List<int>();

            for (var i = 0; i < matrix.DimensionCount; i++)
            {
                var dimensionIndex = (int)Math.Round((decimal)index / matrix.DimensionVectorCount[i]);
                result.Add(dimensionIndex);
                index = index - dimensionIndex * matrix.DimensionVectorCount[i];
            }

            return result;
        }


        /// <summary>
        ///     Initializes the DimensionVectorCount property
        /// </summary>
        public static IList<int> GetDimensionVectorCounts(IEnumerable<int> sizes)
        {

            sizes = sizes.ToList();

            var dimensionCount = sizes.Count();

            var result = Enumerable.Repeat(0, dimensionCount).ToList();

            if (!sizes.Any()) return result;

            var current = 1;

            for (var i = dimensionCount - 1; i >= 0; i--)
            {
                result[i] = current;
                current = sizes.ElementAt(i) * current;
            }

            return result;
        }


    }

    public static class Indexes
    {
        public static IList<int> Initialize(int count, int value)
        {
            return Enumerable.Repeat(value, count).ToList();
        }

        public static IList<int> Initialize(int count)
        {
            return Enumerable.Repeat(0, count).ToList();
        }
    }
}