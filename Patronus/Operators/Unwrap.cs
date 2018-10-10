using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Patronus.Enumerators;
using Patronus.Extensions;

namespace Patronus.Operators
{

    /// <summary>
    /// Unwrapping mode
    /// </summary>
    public enum UnwrapMode
    {
        /// <summary>
        /// Will add dimensions to fit the inner matrices
        /// </summary>
        Discrete,
        /// <summary>
        /// Will unwrap the matrices without adding dimensions
        /// </summary>
        Expand
    }

    /// <summary>
    /// Unwraps inner matrices
    /// </summary>
    /// <typeparam name="T">Data type of the matrix</typeparam>
    public class Unwrap<T> : UnaryOperator<Matrix<Matrix<T>>, Matrix<T>>
    {
        internal const UnwrapMode DefaultMode = UnwrapMode.Discrete;

        public UnwrapMode Mode { get; set; }

        public Unwrap(UnwrapMode mode = DefaultMode)
        {
            Mode = mode;
        }

        protected override void DoInference()
        {
            var matrix = Param;

            var sizes1 = matrix.Sizes.ToList();
            var sizes2 = matrix.Vectors[0].Sizes.ToList();

            var c = 0;
            List<int> enumSize;
            IndexEnumerator enumerator;
            Matrix<T> result;

            switch (Mode)
            {
                case UnwrapMode.Discrete:

                    enumSize = sizes1.ToList();
                    enumSize.AddRange(sizes2);

                    result = new Matrix<T>(enumSize);
                    enumerator = new IndexEnumerator(enumSize);

                    while (enumerator.MoveNext())
                    {
                        var subMatrix = matrix[enumerator.Current.Take(matrix.DimensionCount)];
                        var vector = subMatrix[enumerator.Current.Skip(matrix.DimensionCount)];
                        result.Vectors[c] = vector;
                        c++;
                    }

                    Output = result;

                    break;
                case UnwrapMode.Expand:

                    enumSize = sizes1.ToList();
                    var finalSizes = sizes1.ToList();

                    while (finalSizes.Count < sizes2.Count)
                    {
                        finalSizes.Add(1);
                    }

                    for (var i = 0; i < sizes2.Count; i++)
                    {
                        finalSizes[finalSizes.Count - sizes2.Count + i] *= sizes2[i];
                    }

                    result = new Matrix<T>(finalSizes);

                    for (var i = 0; i < sizes2.Count; i++)
                    {
                        var size1Index = Math.Max(0, enumSize.Count - sizes2.Count) + i;                        
                        enumSize.Insert(size1Index + 1, sizes2[i]);                        
                    }

                    enumerator = new IndexEnumerator(enumSize);

                    while (enumerator.MoveNext())
                    {

                        List<int> topIndex;
                        List<int> subIndex;

                        if (sizes1.Count > sizes2.Count)
                        {
                            topIndex = enumerator.Current.Take(sizes1.Count - sizes2.Count).ToList();

                            topIndex.AddRange(enumerator.Current.Skip(sizes1.Count - sizes2.Count)
                                .Where((element, index) => index % 2 == 0));

                            subIndex = enumerator.Current.Skip(sizes1.Count - sizes2.Count)
                                .Where((element, index) => index % 2 == 1).ToList();
                        }
                        else
                        {
                            topIndex = enumerator.Current.Where((element, index) => index % 2 == 0).Take(sizes1.Count).ToList();
                            subIndex = enumerator.Current.Where((element, index) => index % 2 == 1).ToList();

                            subIndex.AddRange(enumerator.Current.Skip(sizes1.Count * 2));

                        }

                        


                        var subMatrix = matrix[topIndex];
                        var vector = subMatrix[subIndex];
                        result.Vectors[c] = vector;
                        c++;
                    }

                    Output = result;


                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            

            
        }
    }
}
