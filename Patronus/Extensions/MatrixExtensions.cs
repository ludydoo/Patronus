using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Comparers;
using Patronus.Enumerators;
using Patronus.Operators;
using Patronus.Printers;

namespace Patronus.Extensions
{

    public static class MatrixExtensions
    {        
        public static Matrix<T> Flatten<T>(this Matrix<T> matrix, int dimensionFrom, int dimensionTo, FlattenMode mode = FlattenMode.Extend)
        {
            return new Flatten<T>(dimensionFrom, dimensionTo, mode)
            {
                Param = matrix
            };
        }
        public static Matrix<T> Concat<T>(this Matrix<T> matrix, Matrix<T> other, int dimensionIndex)
        {
            return new Concatenation<T>(dimensionIndex)
            {
                Left = matrix,
                Right = other
            };
        }

        public static Matrix<T> Pad<T>(this Matrix<T> matrix, T value)
        {
            return new Pad<T>(value)
            {
                Param = matrix
            };
        }
        public static Matrix<TType> Map<T, TType>(this Matrix<T> matrix, Func<T, TType> mapFunc)
        {
            return new Map<T, TType>(mapFunc)
            {
                Param = matrix
            };
        }

        /// <summary>
        ///     Randomizes all values
        /// </summary>
        public static Matrix<T> Randomize<T>(this Matrix<T> matrix, T min, T max)
        {
            return new Randomize<T>(min, max)
            {
                Param = matrix
            };
        }
        /// <summary>
        ///     Fill with sequence
        /// </summary>
        public static Matrix<T> Sequence<T>(this Matrix<T> matrix, T from)
        {
            return new Sequence<T>(@from)
            {
                Param = matrix
            };
        }

        public static Matrix<Matrix<T>> Wrap<T>(this Matrix<T> matrix, int dimensions = 2)
        {
            return new Wrap<T>(dimensions)
            {
                Param = matrix
            };
        }


        /// <summary>
        ///     Prints the matrix
        /// </summary>
        public static Matrix<T> Print<T>(this Matrix<T> matrix, IMatrixPrinter printer = null)
        {
            return new Print<T>(printer)
            {
                Param = matrix
            };
        }

        public static Matrix<T> Unwrap<T>(this Matrix<Matrix<T>> matrix, UnwrapMode mode = UnwrapMode.Discrete)
        {
            return new Unwrap<T>(mode)
            {
                Param = matrix
            };
        }

        public static Matrix<T> Reshape<T>(this Matrix<T> matrix, IEnumerable<int> sizes)
        {
            return new Reshape<T>(sizes)
            {
                Param = matrix
            };
        }

        public static Matrix<T> Reshape<T>(this Matrix<T> matrix, params int[] sizes)
        {
            return Reshape(matrix, sizes as IEnumerable<int>);
        }

        public static Matrix<T> Squeeze<T>(this Matrix<T> matrix)
        {
            return new Squeeze<T>()
            {
                Param = matrix
            };
        }


    }
}
