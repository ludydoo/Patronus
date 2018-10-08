using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Patronus.Operators
{

    public abstract class Operator
    {

    }

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

    public abstract class UnaryOperator<TIn, TOut> : Operator<TOut>
    {
        public TIn Param { get; set; }
    }

    public abstract class BinaryOperator<TIn1, TIn2, TOut> : Operator<TOut>
    {
        public TIn1 Left { get; set; }
        public TIn2 Right { get; set; }
    }

}
