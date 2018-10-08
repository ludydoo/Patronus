using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Enumerators;

namespace Patronus.Operators
{


    public enum FlattenMode
    {
        /// <summary>
        /// Determines the final ordering of the flatten operation.
        /// This mode will result in a flattening where the "from" dimension will
        /// be successively interposed between the values of the "to" dimension.
        /// Analogous to combining two piles of sheets of paper one sheet at the time,
        /// instead of the whole left pile than the whole right pile.
        /// </summary>
        Interpose,
        /// <summary>
        /// Determines the final ordering of the flatten operation.
        /// This mode will result in a flattening where the "from" dimension will
        /// be placed after the "to" dimension.
        /// Analogous to combining two piles of sheets of paper one pile at the time,
        /// instead of taking successive sheets of each pile.
        /// </summary>
        Extend
    };

    

    /// <summary>
    /// This will flatten a dimension into another dimension
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="matrix">The matrix to flatten</param>
    /// <param name="dimensionFrom">The dimension that will be flattened</param>
    /// <param name="dimensionTo">The dimension in which it will be flattened</param>
    /// <param name="mode">The flattening mode</param>
    /// <returns></returns>
    public class Flatten<T> : UnaryOperator<Matrix<T>, Matrix<T>>
    {

        public const FlattenMode DefaultMode = FlattenMode.Extend;

        public int DimensionFrom { get; set; }
        public int DimensionTo { get; set; }
        public FlattenMode Mode { get; set; }

        public Flatten(int dimensionFrom, int dimensionTo, FlattenMode mode = DefaultMode)
        {
            DimensionFrom = dimensionFrom;
            DimensionTo = dimensionTo;
            Mode = mode;
        }

        protected override void DoInference()
        {

            var matrix = Param;

            // The size of the "from" dimension
            var sizeFrom = matrix.Sizes.ElementAt(DimensionFrom - 1);

            // The size of the "to" dimension
            var sizeTo = matrix.Sizes.ElementAt(DimensionTo - 1);

            // The final size of the "to" dimension, after flattening
            var finalSizeTo = sizeTo * sizeFrom;

            // The final size of the resulting matrix
            var finalSizes = new List<int>(matrix.Sizes) { [DimensionTo - 1] = finalSizeTo };
            finalSizes.RemoveAt(DimensionFrom - 1);

            // The strategy here is quite simple.
            //
            // Our goal is to provide a new matrix that corresponds to the given
            // matrix with the "from" dimension flattened into the "two" dimension.
            //
            // Examples of flattening on a 3x3x3 matrix (read cube)
            // We can flatten the 3rd dimension into the 1st (lose width, gain depth)
            // We can flatten the 3rd dimension into the 2nd (lose width, gain height)
            // We can flatten the 2nd dimension into the 1st (lose height, gain depth)
            // We can flatten the 2nd dimension into the 3rd (lose height, gain width)
            // We can flatten the 1st dimension into the 1st (lose depth, gain width)
            // We can flatten the 1st dimension into the 3rd (lose depth, gain height)
            // 
            // So we will have to do some kind of loop through our vectors. But in what order?
            //
            // Normally, when we iterate through a matrix, we do it 
            // from the innermost dimension, towards the outermost dimension.
            // Eg. 000 -> 001 -> 010 -> 011 ...
            // 
            // We will use the same strategy, but we will reorder the dimensions first.
            // Then we will iterate in the same way, but with our reordered dimensions.
            // So our initial dimensions are 0,1,2,3, ...
            //
            // If we want to flatten the 3rd dimension into the 1st dimension, our
            // ordering will be like so : 0,1,2,3 => 2,0,1,3 (or 0,2,1,3 depending on the flattening mode)
            //
            // We will create an iterator that will iterate through those indices like
            // they were normal indices, but we will then use a map between our reordered index
            // and our actual index to access the vectors in the desired order.

            // This will contain the reordered indexes
            var reorderedIndexes = new List<int>();
            for (var i = 0; i < matrix.DimensionCount; i++) reorderedIndexes.Add(i);
            reorderedIndexes.RemoveAt(DimensionFrom - 1);

            // This contains the index of the "to" dimension in our reordered index list
            var toOrderIndex = reorderedIndexes.IndexOf(DimensionTo - 1);

            // Double dispatch, depending on mode
            switch (Mode)
            {
                case FlattenMode.Interpose:
                    reorderedIndexes.Insert(toOrderIndex + 1, DimensionFrom - 1);
                    break;
                case FlattenMode.Extend:
                    reorderedIndexes.Insert(toOrderIndex, DimensionFrom - 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(Mode), Mode, null);
            }

            // This contains the sizes of the dimension, in respect to our reordered indices
            var reorderedSizes = reorderedIndexes.Select(i => matrix.Sizes.ElementAt(i)).ToList();

            // The enumartor that will iterate through these reordered indices
            var reorderedIndexEnumerator = new IndexEnumerator(reorderedSizes);

            // The resulting matrix
            var result = new Matrix<T>(finalSizes);

            // A counter, will help update the result matrix
            var c = 0;

            while (reorderedIndexEnumerator.MoveNext())
            {

                // We select both the index of the reordered dimension, as well as 
                // it's current step within that dimension
                var normalized = reorderedIndexEnumerator.Current.ToList()
                    .Select((element, index) => new { element, index })
                    .ToList();

                // We sort in respect to the initial order of the dimensions
                normalized.Sort((left, right) => Comparer<int>.Default.Compare(reorderedIndexes[left.index], reorderedIndexes[right.index]));

                // We set the resulting matrix vector to this current vector
                result.Vectors[c] = matrix[normalized.Select(arg => arg.element)];

                c++;

            }

            Output = result;

        }
    }
}
