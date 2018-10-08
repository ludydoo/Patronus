using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Patronus.Operators
{

    /// <summary>
    /// Base class for operators
    /// </summary>
    public abstract class Operator
    {

    }

    /// <summary>
    /// Base class for operators with an output type
    /// </summary>
    /// <typeparam name="TOut">Output type</typeparam>
    public abstract class Operator<TOut> : Operator
    {        
        public TOut Output { get; protected set; }
        protected abstract void DoInference();

        public static implicit operator TOut(Operator<TOut> op)
        {
           op.DoInference();
            return op.Output;
        }

    }

    /// <summary>
    /// Base class for unary operators
    /// </summary>
    /// <typeparam name="TIn">Input type</typeparam>
    /// <typeparam name="TOut">Output type</typeparam>
    public abstract class UnaryOperator<TIn, TOut> : Operator<TOut>
    {
        public TIn Param { get; set; }
    }

    /// <summary>
    /// Base class for binary operators
    /// </summary>
    /// <typeparam name="TIn1">Left input type</typeparam>
    /// <typeparam name="TIn2">Right input type</typeparam>
    /// <typeparam name="TOut">Output type</typeparam>
    public abstract class BinaryOperator<TIn1, TIn2, TOut> : Operator<TOut>
    {
        public TIn1 Left { get; set; }
        public TIn2 Right { get; set; }
    }

}
