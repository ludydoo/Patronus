using System.Collections.Generic;
using System.Linq;

namespace Patronus.Comparers
{
    /// <inheritdoc />
    /// <summary>
    /// Compares the equality between two matrices
    /// </summary>
    /// <typeparam name="T">The matrix data type</typeparam>
    public class MatrixEqualityComparer<T> : IEqualityComparer<Matrix<T>>
    {
        /// <inheritdoc />
        public bool Equals(Matrix<T> left, Matrix<T> right)
        {

            if (left == null ^ right == null) return false;
            if (left == null) return true;

            if (left.DimensionCount != right.DimensionCount) return false;
            if (!left.Sizes.SequenceEqual(right.Sizes)) return false;

            return !left.Vectors.Where((t, i) => !t.Equals(right.Vectors[i])).Any();
        }

        public int GetHashCode(Matrix<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}