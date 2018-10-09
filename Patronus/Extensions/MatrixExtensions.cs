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
        /// <see cref="Operators.Flatten{T}"/>
        public static Matrix<T> Flatten<T>(this Matrix<T> matrix, int dimensionFrom, int dimensionTo, FlattenMode mode = FlattenMode.Extend)
        {
            return new Flatten<T>(dimensionFrom, dimensionTo, mode)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Concatenation{T}"/>
        public static Matrix<T> Concat<T>(this Matrix<T> matrix, Matrix<T> other, int dimensionIndex)
        {
            return new Concatenation<T>(dimensionIndex)
            {
                Left = matrix,
                Right = other
            };
        }

        /// <see cref="Operators.Pad{T}"/>
        public static Matrix<T> Pad<T>(this Matrix<T> matrix, T value)
        {
            return new Pad<T>(value)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Map{T, TType}"/>
        public static Matrix<TType> Map<T, TType>(this Matrix<T> matrix, Func<T, TType> mapFunc)
        {
            return new Map<T, TType>(mapFunc)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Randomize{T}"/>
        public static Matrix<T> Randomize<T>(this Matrix<T> matrix, T min, T max)
        {
            return new Randomize<T>(min, max)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Sequence{T}"/>
        public static Matrix<T> Sequence<T>(this Matrix<T> matrix, T from)
        {
            return new Sequence<T>(@from)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Wrap{T}"/>
        public static Matrix<Matrix<T>> Wrap<T>(this Matrix<T> matrix, int dimensions = 2)
        {
            return new Wrap<T>(dimensions)
            {
                Param = matrix
            };
        }


        /// <see cref="Operators.Print{T}"/>
        public static Matrix<T> Print<T>(this Matrix<T> matrix, IMatrixPrinter printer = null)
        {
            return new Print<T>(printer)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Unwrap{T}"/>
        public static Matrix<T> Unwrap<T>(this Matrix<Matrix<T>> matrix, UnwrapMode mode = UnwrapMode.Discrete)
        {
            return new Unwrap<T>(mode)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Reshape{T}"/>
        public static Matrix<T> Reshape<T>(this Matrix<T> matrix, IEnumerable<int> sizes)
        {
            return new Reshape<T>(sizes)
            {
                Param = matrix
            };
        }

        /// <see cref="Operators.Reshape{T}"/>
        public static Matrix<T> Reshape<T>(this Matrix<T> matrix, params int[] sizes)
        {
            return Reshape(matrix, sizes as IEnumerable<int>);
        }

        /// <see cref="Operators.Squeeze{T}"/>
        public static Matrix<T> Squeeze<T>(this Matrix<T> matrix, params int[] dimensions)
        {
            return new Squeeze<T>(dimensions)
            {
                Param = matrix
            };
        }


    }
}
