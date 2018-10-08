using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Patronus.Enumerators
{
    /// <summary>
    /// Iterates through each index of a matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MatrixIndexEnumerator<T> : IEnumerator<IEnumerable<int>>
    {
        private readonly IndexEnumerator _internalEnumerator;

        public MatrixIndexEnumerator(Matrix matrix)
        {
            _internalEnumerator = new IndexEnumerator(matrix.Sizes);
        }

        public bool MoveNext()
        {
            return _internalEnumerator.MoveNext();
        }

        public void Reset()
        {
            _internalEnumerator.Reset();
        }

        [NotNull]
        public IEnumerable<int> Current => _internalEnumerator.Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}