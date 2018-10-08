using System;
using System.Collections.Generic;

namespace Patronus.Numeric
{
    public struct Numeric :
        INumeric<int>,
        INumeric<double>,
        INumeric<float>,
        INumeric<decimal>,
        INumeric<byte>,
        INumeric<long>,
        INumeric<short>
    {
        private static readonly Random Random = new Random();

        int INumeric<int>.Zero => 0;
        int INumeric<int>.One => 1;
        int INumeric<int>.MaxValue => int.MaxValue;
        int INumeric<int>.MinValue => int.MinValue;

        int INumeric<int>.Add(int a, int b) => a + b;

        int INumeric<int>.Subtract(int a, int b) => a - b;

        int INumeric<int>.Mult(int a, int b) => a * b;

        int INumeric<int>.Div(int a, int b)
        {
            return a / b;
        }

        double INumeric<int>.Sqrt(int a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<int>.Sin(int a)
        {
            return Math.Sin(a);
        }

        double INumeric<int>.Cos(int a)
        {
            return Math.Cos(a);
        }

        double INumeric<int>.Tan(int a)
        {
            return Math.Tan(a);
        }

        double INumeric<int>.Sinh(int a)
        {
            return Math.Sinh(a);
        }

        double INumeric<int>.Tanh(int a)
        {
            return Math.Tanh(a);
        }

        double INumeric<int>.Cosh(int a)
        {
            return Math.Cosh(a);
        }

        double INumeric<int>.Pow(int a, int b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<int>.Exp(int a)
        {
            return Math.Exp(a);
        }

        int INumeric<int>.Random(int min, int max)
        {
            return Random.Next(min, max);
        }

        int INumeric<int>.Compare(int a, int b)
        {
            return Comparer<int>.Default.Compare(a, b);
        }

        string INumeric<int>.ToString(int a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        double INumeric<double>.Zero => 0;
        double INumeric<double>.One => 1;
        double INumeric<double>.MaxValue => double.MaxValue;
        double INumeric<double>.MinValue => double.MinValue;

        double INumeric<double>.Add(double a, double b)
        {
            return a + b;
        }

        double INumeric<double>.Subtract(double a, double b)
        {
            return a - b;
        }

        double INumeric<double>.Mult(double a, double b)
        {
            return a * b;
        }

        double INumeric<double>.Div(double a, double b)
        {
            return a / b;
        }

        double INumeric<double>.Sqrt(double a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<double>.Sin(double a)
        {
            return Math.Sin(a);
        }

        double INumeric<double>.Cos(double a)
        {
            return Math.Cos(a);
        }

        double INumeric<double>.Tan(double a)
        {
            return Math.Tan(a);
        }

        double INumeric<double>.Sinh(double a)
        {
            return Math.Sinh(a);
        }

        double INumeric<double>.Tanh(double a)
        {
            return Math.Tanh(a);
        }

        double INumeric<double>.Cosh(double a)
        {
            return Math.Cosh(a);
        }

        double INumeric<double>.Pow(double a, double b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<double>.Exp(double a)
        {
            return Math.Exp(a);
        }

        double INumeric<double>.Random(double min, double max)
        {
            return (max - min) * Random.NextDouble() - min;
        }

        int INumeric<double>.Compare(double a, double b)
        {
            return Comparer<double>.Default.Compare(a, b);
        }

        string INumeric<double>.ToString(double a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        float INumeric<float>.Zero => 0;
        float INumeric<float>.One => 1;
        float INumeric<float>.MaxValue => float.MaxValue;
        float INumeric<float>.MinValue => float.MinValue;

        float INumeric<float>.Add(float a, float b)
        {
            return a + b;
        }

        float INumeric<float>.Subtract(float a, float b)
        {
            return a - b;
        }

        float INumeric<float>.Mult(float a, float b)
        {
            return a * b;
        }

        float INumeric<float>.Div(float a, float b)
        {
            return a / b;
        }

        double INumeric<float>.Sqrt(float a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<float>.Sin(float a)
        {
            return Math.Sin(a);
        }

        double INumeric<float>.Cos(float a)
        {
            return Math.Cos(a);
        }

        double INumeric<float>.Tan(float a)
        {
            return Math.Tan(a);
        }

        double INumeric<float>.Sinh(float a)
        {
            return Math.Sinh(a);
        }

        double INumeric<float>.Tanh(float a)
        {
            return Math.Tanh(a);
        }

        double INumeric<float>.Cosh(float a)
        {
            return Math.Cosh(a);
        }

        double INumeric<float>.Pow(float a, float b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<float>.Exp(float a)
        {
            return Math.Exp(a);
        }

        float INumeric<float>.Random(float min, float max)
        {
            return (float) ((max - min) * Random.NextDouble() - min);
        }

        int INumeric<float>.Compare(float a, float b)
        {
            return Comparer<float>.Default.Compare(a, b);
        }

        string INumeric<float>.ToString(float a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        decimal INumeric<decimal>.Zero => 0;
        decimal INumeric<decimal>.One => 1;
        decimal INumeric<decimal>.MaxValue => decimal.MaxValue;
        decimal INumeric<decimal>.MinValue => decimal.MinValue;

        decimal INumeric<decimal>.Add(decimal a, decimal b)
        {
            return a + b;
        }

        decimal INumeric<decimal>.Subtract(decimal a, decimal b)
        {
            return a - b;
        }

        decimal INumeric<decimal>.Mult(decimal a, decimal b)
        {
            return a * b;
        }

        decimal INumeric<decimal>.Div(decimal a, decimal b)
        {
            return a / b;
        }

        double INumeric<decimal>.Sqrt(decimal a)
        {
            return Math.Sqrt((double) a);
        }

        double INumeric<decimal>.Sin(decimal a)
        {
            return Math.Sin((double) a);
        }

        double INumeric<decimal>.Cos(decimal a)
        {
            return Math.Cos((double) a);
        }

        double INumeric<decimal>.Tan(decimal a)
        {
            return Math.Tan((double) a);
        }

        double INumeric<decimal>.Sinh(decimal a)
        {
            return Math.Sinh((double) a);
        }

        double INumeric<decimal>.Tanh(decimal a)
        {
            return Math.Tanh((double) a);
        }

        double INumeric<decimal>.Cosh(decimal a)
        {
            return Math.Cosh((double) a);
        }

        double INumeric<decimal>.Pow(decimal a, decimal b)
        {
            return Math.Pow((double) a, (double) b);
        }

        double INumeric<decimal>.Exp(decimal a)
        {
            return Math.Exp((double) a);
        }

        decimal INumeric<decimal>.Random(decimal min, decimal max)
        {
            return (max - min) * (decimal) Random.NextDouble() - min;
        }

        int INumeric<decimal>.Compare(decimal a, decimal b)
        {
            return Comparer<decimal>.Default.Compare(a, b);
        }

        string INumeric<decimal>.ToString(decimal a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        byte INumeric<byte>.Zero => 0;
        byte INumeric<byte>.One => 1;
        byte INumeric<byte>.MaxValue => byte.MaxValue;
        byte INumeric<byte>.MinValue => byte.MinValue;

        byte INumeric<byte>.Add(byte a, byte b)
        {
            return (byte) (a + b);
        }

        byte INumeric<byte>.Subtract(byte a, byte b)
        {
            return (byte) (a - b);
        }

        byte INumeric<byte>.Mult(byte a, byte b)
        {
            return (byte) (a * b);
        }

        byte INumeric<byte>.Div(byte a, byte b)
        {
            return (byte) (a / b);
        }

        double INumeric<byte>.Sqrt(byte a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<byte>.Sin(byte a)
        {
            return Math.Sin(a);
        }

        double INumeric<byte>.Cos(byte a)
        {
            return Math.Cos(a);
        }

        double INumeric<byte>.Tan(byte a)
        {
            return Math.Tan(a);
        }

        double INumeric<byte>.Sinh(byte a)
        {
            return Math.Sinh(a);
        }

        double INumeric<byte>.Tanh(byte a)
        {
            return Math.Tanh(a);
        }

        double INumeric<byte>.Cosh(byte a)
        {
            return Math.Cosh(a);
        }

        double INumeric<byte>.Pow(byte a, byte b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<byte>.Exp(byte a)
        {
            return Math.Exp(a);
        }

        byte INumeric<byte>.Random(byte min, byte max)
        {
            return (byte) ((max - min) * (byte) Random.NextDouble() - min);
        }

        int INumeric<byte>.Compare(byte a, byte b)
        {
            return Comparer<byte>.Default.Compare(a, b);
        }

        string INumeric<byte>.ToString(byte a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        long INumeric<long>.Zero => 0;
        long INumeric<long>.One => 1;
        long INumeric<long>.MaxValue => long.MaxValue;
        long INumeric<long>.MinValue => long.MinValue;

        long INumeric<long>.Add(long a, long b)
        {
            return a + b;
        }

        long INumeric<long>.Subtract(long a, long b)
        {
            return a - b;
        }

        long INumeric<long>.Mult(long a, long b)
        {
            return a * b;
        }

        long INumeric<long>.Div(long a, long b)
        {
            return a / b;
        }

        double INumeric<long>.Sqrt(long a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<long>.Sin(long a)
        {
            return Math.Sin(a);
        }

        double INumeric<long>.Cos(long a)
        {
            return Math.Cos(a);
        }

        double INumeric<long>.Tan(long a)
        {
            return Math.Tan(a);
        }

        double INumeric<long>.Sinh(long a)
        {
            return Math.Sinh(a);
        }

        double INumeric<long>.Tanh(long a)
        {
            return Math.Tanh(a);
        }

        double INumeric<long>.Cosh(long a)
        {
            return Math.Cosh(a);
        }

        double INumeric<long>.Pow(long a, long b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<long>.Exp(long a)
        {
            return Math.Exp(a);
        }

        long INumeric<long>.Random(long min, long max)
        {
            return (max - min) * (long) Random.NextDouble() - min;
        }

        int INumeric<long>.Compare(long a, long b)
        {
            return Comparer<long>.Default.Compare(a, b);
        }

        string INumeric<long>.ToString(long a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }

        short INumeric<short>.Zero => 0;
        short INumeric<short>.One => 1;
        short INumeric<short>.MaxValue => short.MaxValue;
        short INumeric<short>.MinValue => short.MinValue;

        short INumeric<short>.Add(short a, short b)
        {
            return (short) (a + b);
        }

        short INumeric<short>.Subtract(short a, short b)
        {
            return (short) (a - b);
        }

        short INumeric<short>.Mult(short a, short b)
        {
            return (short) (a * b);
        }

        short INumeric<short>.Div(short a, short b)
        {
            return (short) (a / b);
        }

        double INumeric<short>.Sqrt(short a)
        {
            return Math.Sqrt(a);
        }

        double INumeric<short>.Sin(short a)
        {
            return Math.Sin(a);
        }

        double INumeric<short>.Cos(short a)
        {
            return Math.Cos(a);
        }

        double INumeric<short>.Tan(short a)
        {
            return Math.Tan(a);
        }

        double INumeric<short>.Sinh(short a)
        {
            return Math.Sinh(a);
        }

        double INumeric<short>.Tanh(short a)
        {
            return Math.Tanh(a);
        }

        double INumeric<short>.Cosh(short a)
        {
            return Math.Cosh(a);
        }

        double INumeric<short>.Pow(short a, short b)
        {
            return Math.Pow(a, b);
        }

        double INumeric<short>.Exp(short a)
        {
            return Math.Exp(a);
        }

        short INumeric<short>.Random(short min, short max)
        {
            return (short) ((max - min) * (short) Random.NextDouble() - min);
        }

        int INumeric<short>.Compare(short a, short b)
        {
            return Comparer<short>.Default.Compare(a, b);
        }

        string INumeric<short>.ToString(short a, string format, IFormatProvider formatProvider)
        {
            return a.ToString(format, formatProvider);
        }
    }
}