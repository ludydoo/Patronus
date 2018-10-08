using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Patronus.Comparers;
using Patronus.Enumerators;
using Patronus.Extensions;
using Patronus.Numeric;

namespace Patronus
{


    public class Matrix : IEnumerable
    {
        /// <summary>
        ///     Contains the sizes of the dimensions
        /// </summary>
        internal IList<int> _sizes;
        
        private IList _vectors;

        /// <summary>
        ///     Gets the total number of vectors in this matrix
        /// </summary>
        public int VectorCount { get; private set; }


        /// <summary>
        ///     Gets the number of vectors contained in a dimension
        /// </summary>
        public List<int> DimensionVectorCount { get; private set; } = new List<int>();


        /// <summary>
        ///     Gets the number of dimensions in the matrix
        /// </summary>
        public int DimensionCount { get; internal set; }


        /// <summary>
        ///     A list containing the sizes of the dimensions
        /// </summary>
        public IEnumerable<int> Sizes
        {
            get { return _sizes.Select(i => i).ToList(); }
            set
            {
                if (Equals(value, Sizes)) return;
                SetSize(value);
            }
        }

        /// <summary>
        ///     All the vectors in the matrix
        /// </summary>
        public IList Vectors => GetVectors();

        /// <summary>
        /// IEnumerable implementation
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _vectors.GetEnumerator();
        }

        /// <summary>
        ///     Fills all the dimensions with empty vectors
        /// </summary>
        public virtual Matrix Fill(object val = default)
        {
            Vectors.Clear();
            var i = 0;
            while (i < VectorCount)
            {
                Vectors.Add(val);
                i += 1;
            }
            return this;
        }


        /// <summary>
        ///     Initializes the VectorCount list
        /// </summary>
        private void InitializeVectorCount()
        {
            VectorCount = Sizes.Aggregate(1, (a, b) => a * b);
        }


        /// <summary>
        ///     Sets the sizes of the matrix
        /// </summary>
        /// <param name="sizes"></param>
        /// <param name="fill"></param>
        internal void SetSize(IEnumerable<int> sizes, bool fill = true, bool clear = true)
        {
            _sizes = sizes.ToList();

            if (clear)
                Vectors.Clear();

            DimensionCount = Sizes.Count();

            InitializeVectorCount();
            InitializeDimensionVectorCounts();

            if (fill ^ clear)
                Vectors.Clear();
            

            if (fill)
                Fill();
            
        }


        /// <summary>
        ///     Initializes the DimensionVectorCount property
        /// </summary>
        private void InitializeDimensionVectorCounts() => DimensionVectorCount = IndexExtensions.GetDimensionVectorCounts(Sizes).ToList();


        /// <summary>
        /// Initializes the list of vectors
        /// </summary>
        /// <returns></returns>
        protected virtual IList CreateVectorList() => new ArrayList();


        /// <summary>
        /// Getter for the Vectors property
        /// </summary>
        /// <returns></returns>
        private IList GetVectors() => _vectors ?? (_vectors = CreateVectorList());



        /// <summary>
        ///     Converts a list of indexes to the index of a vector in the vector list
        /// </summary>
        /// <param name="indexes"></param>
        /// <returns></returns>
        protected int ConvertIndexListToVectorIndex(IList<int> indexes)
        {
            var current = 0;

            for (var i = 0; i < indexes.Count; i++) current = current + DimensionVectorCount[i] * indexes[i];

            return current;
        }
    }

    public class Matrix<T> : Matrix, IEnumerable<T>
    {

        // ReSharper disable once StaticMemberInGenericType
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        ///     Creates a Matrix
        /// </summary>
        public Matrix()
        {
        }


        /// <summary>
        ///     Creates a matrix of a given size
        /// </summary>
        /// <param name="sizes">The sizes of the dimensions</param>
        /// <param name="data"></param>
        public Matrix(IEnumerable<int> sizes, IEnumerable<T> data = null)
        {
            SetSize(sizes, data == null);
            if (data != null) SetData(data);
        }


        /// <summary>
        /// Creates a matrix of dimension n
        /// </summary>
        /// <param name="size1">Size of dimension 1</param>
        public Matrix(params int[] sizes) : this(sizes, null)
        {
        }

        /// <summary>
        /// Creates a matrix of dimension n
        /// </summary>
        /// <param name="size1">Size of dimension 1</param>
        public Matrix(IEnumerable<T> data, params int[] sizes) : this(sizes, data)
        {
        }


        /// <summary>
        /// Overrides the Matrix.Vectors property. Gives access to
        /// a typed list.
        /// </summary>
        public new IList<T> Vectors { get; } = new List<T>();


        /// <summary>
        ///     Gets a vector by index
        /// </summary>
        /// <param name="index">The dimensional indexes of the vector</param>
        /// <returns></returns>
        public T this[IEnumerable<int> index]
        {
            get
            {
                var indexList = index.ToList();
                this.AssertValidIndex(indexList);
                var vectorIndex = ConvertIndexListToVectorIndex(new List<int>(indexList));
                return Vectors[vectorIndex];
            }
            set
            {
                var indexList = index.ToList();
                this.AssertValidIndex(indexList);
                var vectorIndex = ConvertIndexListToVectorIndex(new List<int>(indexList));
                Vectors[vectorIndex] = value;
            }
        }


        /// <summary>
        ///     Gets a vector by index for matrices of dimensionality 1
        /// </summary>
        /// <param name="index1">Index of vector in dimension 1</param>
        /// <returns></returns>
        public T this[int index1] => this[new[] {index1}];


        /// <summary>
        ///     Gets a vector by index for matrices of dimensionality 2
        /// </summary>
        /// <param name="index1">Index of vector in dimension 1</param>
        /// <param name="index2">Index of vector in dimension 2</param>
        /// <returns></returns>
        public T this[int index1, int index2] => this[new[] {index1, index2}];


        /// <summary>
        ///     Gets a vector by index for matrices of dimensionality 3
        /// </summary>
        /// <param name="index1">Index of vector in dimension 1</param>
        /// <param name="index2">Index of vector in dimension 2</param>
        /// <param name="index3">Index of vector in dimension 3</param>
        /// <returns></returns>
        public T this[int index1, int index2, int index3] => this[new[] {index1, index2, index3}];


        /// <summary>
        ///     Gets a vector by index for matrices of dimensionality 4
        /// </summary>
        /// <param name="index1">Index of vector in dimension 1</param>
        /// <param name="index2">Index of vector in dimension 2</param>
        /// <param name="index3">Index of vector in dimension 3</param>
        /// <param name="index4">Index of vector in dimension 4</param>
        /// <returns></returns>
        public T this[int index1, int index2, int index3, int index4] =>
            this[new[] {index1, index2, index3, index4}];


        /// <summary>
        ///     Gets a vector by index for matrices of dimensionality 5
        /// </summary>
        /// <param name="index1">Index of vector in dimension 1</param>
        /// <param name="index2">Index of vector in dimension 2</param>
        /// <param name="index3">Index of vector in dimension 3</param>
        /// <param name="index4">Index of vector in dimension 4</param>
        /// <param name="index5">Index of vector in dimension 5</param>
        /// <returns></returns>
        public T this[int index1, int index2, int index3, int index4, int index5] =>
            this[new[] {index1, index2, index3, index4, index5}];


        /// <summary>
        ///     Implementation of IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return Vectors.GetEnumerator();
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes the vector list
        /// </summary>
        /// <returns></returns>
        protected override IList CreateVectorList() => Vectors as IList;


        /// <inheritdoc />
        /// <summary>
        /// Fills the matrix with the given value
        /// </summary>
        /// <param name="val">The value to fill the matrix with</param>
        /// <returns>The matrix itself</returns>
        public override Matrix Fill(object val = default) => base.Fill(default(T));


        /// <summary>
        /// Fills the matrix with the given value.
        /// </summary>
        /// <param name="val">The value to fill the matrix with</param>
        /// <returns>The matrix itself</returns>
        public Matrix<T> Fill(T val = default)
        {
            base.Fill(val);
            return this;
        }


        /// <summary>
        ///     Sets the matrix data. Data should be sorted dimensionnally, from the innermost
        ///     dimension to the outermost.
        /// </summary>
        /// <param name="data"></param>
        public Matrix<T> SetData(IEnumerable<T> data)
        {
            if (data == null)
            {
                Vectors.Clear();
            }
            else
            {

                if (data.Count() != VectorCount)
                    throw new InvalidOperationException(
                        $"Invalid number of entries. Got {data.Count()} and should've been {VectorCount}");

                Vectors.Clear();

                foreach (var item in data)
                    Vectors.Add(item);
            }
            return this;
        }

        /// <summary>
        ///     Sets the matrix data. Data should be sorted dimensionnally, from the innermost
        ///     dimension to the outermost.
        /// </summary>
        /// <param name="data"></param>
        public Matrix<T> SetData(params T[] data)
        {
            if (data == null)
            {
                Vectors.Clear();
            }
            else
            {

                if (data.Count() != VectorCount)
                    throw new InvalidOperationException(
                        $"Invalid number of entries. Got {data.Count()} and should've been {VectorCount}");

                Vectors.Clear();

                foreach (var item in data)
                    Vectors.Add(item);
            }
            return this;
        }


        /// <summary>
        ///     Clones the Matrix
        /// </summary>
        /// <returns></returns>
        public Matrix<T> Clone()
        {
            return new Matrix<T>(Sizes, Vectors);
        }


        /// <summary>
        ///     Converts a vector index (in a list) to a multi-dimensional index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private IList<int> ConvertToDimensionalIndex(int index) => IndexExtensions.ConvertToDimensionalIndex(this, index);


        /// <inheritdoc />
        public override bool Equals(object obj) => (obj is Matrix<T> m) && new MatrixEqualityComparer<T>().Equals(this, m);


        /// <inheritdoc />
        public override int GetHashCode()
        {
            var sizes = string.Join("-", Sizes.Select(i => i.ToString()));
            return sizes.GetHashCode();
        }


        public void ForEach(Action<IEnumerable<int>, int, T> predicate)
        {

            var i = 0;
            var indexes = Indexes.Initialize(DimensionCount, 0);

            while (i < VectorCount)
            {
                predicate(indexes, i, Vectors[i]);
                i++;
                indexes.IncrementIndex(Sizes);
            }

        }

    }
}