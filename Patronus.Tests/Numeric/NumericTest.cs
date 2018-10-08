using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Numeric;
using Xunit;

namespace Patronus.Tests.Numeric
{
    public class NumericTest
    {

        private readonly INumeric<int> _intNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<float> _floatNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<double> _doubleNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<long> _longNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<short> _shortNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<decimal> _decimalNumeric = new global::Patronus.Numeric.Numeric();
        private readonly INumeric<byte> _byteNumeric = new global::Patronus.Numeric.Numeric();

        [Fact]
        public void TestIntNumeric()
        {
            var n = _intNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(int.MaxValue, n.MaxValue);
            Assert.Equal(int.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            Assert.Equal(1, n.Compare(5, 1));
            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestFloat()
        {
            var n = _floatNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(float.MaxValue, n.MaxValue);
            Assert.Equal(float.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            Assert.Equal(1, n.Compare(5, 1));
            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestDouble()
        {
            var n = _doubleNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(double.MaxValue, n.MaxValue);
            Assert.Equal(double.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            Assert.Equal(1, n.Compare(5, 1));
            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestLong()
        {
            var n = _longNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(long.MaxValue, n.MaxValue);
            Assert.Equal(long.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            Assert.Equal(1, n.Compare(5, 1));
            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestShort()
        {
            var n = _shortNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(short.MaxValue, n.MaxValue);
            Assert.Equal(short.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            
            // Returns 4 ?!
            Assert.True(n.Compare(5, 1) > 0);

            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestDecimal()
        {
            var n = _decimalNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(decimal.MaxValue, n.MaxValue);
            Assert.Equal(decimal.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));
            Assert.Equal(-1, n.Compare(1, 2));
            Assert.Equal(0, n.Compare(5, 5));
            Assert.Equal(1, n.Compare(5, 1));
            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

        [Fact]
        public void TestByte()
        {
            var n = _byteNumeric;
            Assert.Equal(0, n.Zero);
            Assert.Equal(1, n.One);
            Assert.Equal(byte.MaxValue, n.MaxValue);
            Assert.Equal(byte.MinValue, n.MinValue);
            Assert.Equal(2, n.Add(1, 1));
            Assert.Equal(0, n.Subtract(1, 1));
            Assert.Equal(10, n.Mult(2, 5));
            Assert.Equal(5, n.Div(10, 2));

            Assert.True(n.Compare(1, 4) < 0);

            Assert.Equal(0, n.Compare(5, 5));

            Assert.True(n.Compare(5, 1) > 0);

            Assert.Equal(Math.Sqrt(5), n.Sqrt(5));
            Assert.Equal(Math.Sin(5), n.Sin(5));
            Assert.Equal(Math.Cos(5), n.Cos(5));
            Assert.Equal(Math.Tan(5), n.Tan(5));
            Assert.Equal(Math.Sinh(5), n.Sinh(5));
            Assert.Equal(Math.Cosh(5), n.Cosh(5));
            Assert.Equal(Math.Tanh(5), n.Tanh(5));
            Assert.Equal(Math.Pow(2, 3), n.Pow(2, 3));
            Assert.Equal(Math.Exp(2), n.Exp(2));
        }

    }
}
