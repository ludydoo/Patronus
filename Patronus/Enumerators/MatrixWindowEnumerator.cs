using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Patronus.Extensions;

namespace Patronus.Enumerators
{
    public struct MatrixWindowEnumeratorStride<T>
    {
        public MatrixWindowEnumeratorStride(IEnumerable<int> strideIndex, Matrix<T> matrix)
        {
            StrideIndex = strideIndex;
            Matrix = matrix;
        }

        public IEnumerable<int> StrideIndex { get; }
        public Matrix<T> Matrix { get; }
    }

    /// <summary>
    /// Iterates through each sub window of a matrix
    /// </summary>
    /// <typeparam name="T">The data type of the matrix</typeparam>
    public class MatrixWindowEnumerator<T> : IEnumerator<MatrixWindowEnumeratorStride<T>>
    {
        private readonly Matrix<T> _matrix;
        private readonly IList<int> _maxStepsPerDimension;
        private readonly IEnumerable<int> _strides;
        private readonly IEnumerable<int> _windowSize;
        private IList<int> _currentIndexes;
        private IList<int> _currentStepPerDimension;
        private bool _isFirst = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="matrix">The matrix to iterate into</param>
        /// <param name="windowSize">The dimensional sizes of the window</param>
        /// <param name="strides">The dimensional strides (or jumps) to iterate</param>
        public MatrixWindowEnumerator(Matrix<T> matrix, IEnumerable<int> windowSize, IEnumerable<int> strides = null)
        {
            _matrix = matrix;
            _windowSize = windowSize.ToList();
            if (strides == null)
                strides = Indexes.Initialize(matrix.DimensionCount, 1);
            _strides = strides;
            _currentIndexes = Indexes.Initialize(matrix.DimensionCount);
            _currentStepPerDimension = Indexes.Initialize(matrix.DimensionCount);

            if (_windowSize.Count() != _matrix.DimensionCount)
                throw new ArgumentOutOfRangeException(nameof(windowSize));

            if (_windowSize.Count() != _matrix.DimensionCount)
                throw new ArgumentOutOfRangeException(nameof(strides));

            _maxStepsPerDimension = matrix.GetStepsCount(_windowSize, _strides);
        }

        public MatrixWindowEnumerator(Matrix<T> matrix, int size1, IEnumerable<int> strides = null) : this(matrix,
            new[] {size1}, strides)
        {
        }

        public MatrixWindowEnumerator(Matrix<T> matrix, int size1, int size2, IEnumerable<int> strides = null) : this(
            matrix, new[] {size1, size2}, strides)
        {
        }

        public MatrixWindowEnumerator(Matrix<T> matrix, int size1, int size2, int size3,
            IEnumerable<int> strides = null) : this(matrix, new[] {size1, size2, size3}, strides)
        {
        }

        public bool MoveNext()
        {
            if (!_isFirst)
            {
                if (_currentStepPerDimension.IsLastIndex(_maxStepsPerDimension)) return false;
                _currentStepPerDimension = _currentStepPerDimension.IncrementIndex(_maxStepsPerDimension);
            }
            else
            {
                _isFirst = false;
            }

            return true;
        }

        public void Reset()
        {
            _currentStepPerDimension = Enumerable.Repeat(0, _matrix.DimensionCount).ToList();
            _isFirst = true;
        }

        public MatrixWindowEnumeratorStride<T> Current
        {
            get
            {
                var resultMatrix = new Matrix<T>(_windowSize);

                _currentIndexes = _currentStepPerDimension.Select((item, index) => item * _strides.ElementAt(index))
                    .ToList();

                IList<int> offsets = Enumerable.Repeat(0, _matrix.DimensionCount).ToList();
                var calculated = _currentIndexes.AddIndexes(offsets);
                resultMatrix[offsets] = _matrix[calculated];
                while (!offsets.IsLastIndex(_windowSize))
                {
                    offsets = offsets.IncrementIndex(_windowSize);
                    calculated = _currentIndexes.AddIndexes(offsets);
                    resultMatrix[offsets] = _matrix[calculated];
                }

                var stride = new MatrixWindowEnumeratorStride<T>(_currentStepPerDimension, resultMatrix);

                return stride;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public IEnumerable<int> Strides()
        {
            return _maxStepsPerDimension.Select(a => a);
        }
    }
}