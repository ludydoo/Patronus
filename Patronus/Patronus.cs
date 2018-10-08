using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Patronus.Extensions;
using Patronus.Operators;
using Patronus.Printers;

namespace Patronus
{
    public static class Patronus
    {


        public static Matrix<T> From<T>(params T[] data)
        {
            return new Matrix<T>(new []{data.Length}, data);
        }

        public static Matrix<T> Matrix<T>(IEnumerable<int> shape,  IEnumerable<T> data = null)
        {
            return new Matrix<T>(shape, data);
        }

        public static Matrix<T> Matrix<T>(int axis1, IEnumerable<T> data = null)
        {
            return new Matrix<T>(axis1).SetData(data);
        }

        public static Matrix<T> Matrix<T>(int axis1, int axis2, IEnumerable<T> data = null)
        {
            return new Matrix<T>(axis1, axis2).SetData(data);
        }

        public static Matrix<T> Matrix<T>(int axis1, int axis2, int axis3, IEnumerable<T> data = null)
        {
            return new Matrix<T>(axis1, axis2, axis3).SetData(data);
        }

        public static Matrix<T> Matrix<T>(int axis1, int axis2, int axis3, int axis4, IEnumerable<T> data = null)
        {
            return new Matrix<T>(axis1, axis2, axis3, axis4).SetData(data);
        }

        public static Matrix<T> Matrix<T>(int axis1, int axis2, int axis3, int axis4, int axis5, IEnumerable<T> data = null)
        {
            return new Matrix<T>(axis1, axis2, axis3, axis4, axis5).SetData(data);
        }

        public static Matrix<T> Matrix<T>(IEnumerable<T> data = null, params int[] sizes)
        {
            return new Matrix<T>(sizes, data);
        }

        public static Matrix<T> Matrix<T>(params int[] sizes)
        {
            return new Matrix<T>(sizes);
        }

        public static Matrix<T> Concat<T>(int axis, params Matrix<T>[] matrices)
        {

            if (matrices.Length == 0) return null;
            if (matrices.Length == 1) return matrices[0];

            var current = matrices[0];
            var i = 1;
            while (i < matrices.Length)
            {
                current = current.Concat(matrices[i], axis);
                i++;
            }
            return current;
        }

        public static Matrix<T> Flatten<T>(Matrix<T> matrix, int dimensionFrom, int dimensionTo, FlattenMode mode = Operators.Flatten<T>.DefaultMode)
        {
            return matrix.Flatten(dimensionFrom, dimensionTo, mode);
        }

        public static Matrix<TType> Map<T, TType>(Matrix<T> matrix, Func<T, TType> map)
        {
            return matrix.Map(map);
        }

        public static Matrix<T> Pad<T>(Matrix<T> matrix, T value)
        {
            return matrix.Pad(value);
        }

        public static Matrix<T> Print<T>(Matrix<T> matrix, IMatrixPrinter printer = null)
        {
            return matrix.Print(printer);
        }

        public static Matrix<T> Randomize<T>(Matrix<T> matrix, T min, T max)
        {
            return matrix.Randomize(min, max);
        }

        public static Matrix<T> Random<T>(T min, T max, params int[] sizes)
        {
            return new Matrix<T>(sizes).Randomize(min, max);
        }

        public static Matrix<T> Sequence<T>(Matrix<T> matrix, T start)
        {
            return matrix.Sequence(start);
        }

        public static Matrix<T> Sequence<T>(T start, int count)
        {
            return new Matrix<T>(count).Sequence(start);
        }

        public static Matrix<T> Sequence<T>(T start, params int[] sizes)
        {
            return new Matrix<T>(sizes).Sequence(start);
        }

        public static Matrix<T> Unwrap<T>(Matrix<Matrix<T>> matrix, UnwrapMode mode = Operators.Unwrap<T>.DefaultMode)
        {
            return matrix.Unwrap(mode);
        }

        public static Matrix<Matrix<T>> Wrap<T>(Matrix<T> matrix, int dimensions = Operators.Wrap<T>.DefaultDimensions)
        {
            return matrix.Wrap(dimensions);
        }

        public static Matrix<T> Reshape<T>(Matrix<T> matrix, IEnumerable<int> sizes)
        {
            return matrix.Reshape(sizes);
        }

        public static Matrix<T> Reshape<T>(Matrix<T> matrix, params int[] sizes)
        {
            return matrix.Reshape(sizes);
        }

        public static Matrix<T> Squeeze<T>(Matrix<T> matrix)
        {
            return matrix.Squeeze();
        }

    }
}
