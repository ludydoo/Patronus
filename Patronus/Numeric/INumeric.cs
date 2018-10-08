using System;

namespace Patronus.Numeric
{
    public interface INumeric<T>
    {
        T Zero { get; }
        T One { get; }
        T MaxValue { get; }
        T MinValue { get; }
        T Add(T a, T b);
        T Subtract(T a, T b);
        T Mult(T a, T b);
        T Div(T a, T b);
        double Sqrt(T a);
        double Sin(T a);
        double Cos(T a);
        double Tan(T a);
        double Sinh(T a);
        double Tanh(T a);
        double Cosh(T a);
        double Pow(T a, T b);
        double Exp(T a);
        T Random(T min, T max);
        int Compare(T a, T b);
        string ToString(T a, string format = null, IFormatProvider formatProvider = null);
    }
}