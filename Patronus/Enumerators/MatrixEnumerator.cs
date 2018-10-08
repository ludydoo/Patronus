using System;
using System.Collections;
using System.Collections.Generic;

namespace Patronus.Enumerators
{
    public class MatrixEnumerator<T> : IEnumerator<T>
    {
        private readonly Matrix<T> _matrix;

        private int _current = -1;

        public MatrixEnumerator(Matrix<T> matrix)
        {
            _matrix = matrix;
        }

        public bool MoveNext()
        {
            if (_matrix.Vectors.Count == 0 || _current == _matrix.VectorCount)
                return false;
            _current += 1;
            return true;
        }

        public void Reset()
        {
            _current = -1;
        }

        public T Current => _matrix.Vectors[_current];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}