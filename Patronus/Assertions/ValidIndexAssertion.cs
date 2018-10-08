using System;
using System.Collections.Generic;
using System.Linq;

namespace Patronus.Assertions
{
    /// <summary>
    /// Validates that a given dimensional index is valid for a matrix. 
    /// </summary>
    public static class ValidIndexAssertion
    {

        public static void Assert(IEnumerable<int> indexes, Matrix matrix)
        {

            var indexList = indexes.ToList();

            if (indexList.Count() != matrix.DimensionCount)
                throw new ArgumentException("Invalid number of indexes");

            if (indexList.Any(i => i < 0)) throw new ArgumentException("Cannot have a negative index", nameof(indexes));

            for (var i = 0; i < indexList.Count; i++)
                if (indexList[i] >= matrix.Sizes.ElementAt(i))
                    throw new ArgumentException(
                        $"Cannot have an index at position {i} larger than {matrix.Sizes.ElementAt(i)}");

        }

    }
}
