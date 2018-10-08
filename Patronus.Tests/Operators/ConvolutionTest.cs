using System;
using System.Collections.Generic;
using System.Text;
using Patronus.Extensions;
using Patronus.Operators;
using Xunit;
using Xunit.Abstractions;

namespace Patronus.Tests.Operators
{
    public class ConvolutionTest : BaseTest
    {
        public ConvolutionTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestConvolution()
        {
            // 1  2  3  4
            // 5  6  7  8
            // 9  10 11 12
            // 13 14 15 16

            // 1 2
            // 3 4

            var matrix = Patronus.Sequence(1, 4, 4);
            var kernel = new List<int>() {1, 2, 3, 4};
            var windowSize = new List<int>() {2, 2};
            var strides = new List<int>() {1, 1};
            var padding = 0;

            Matrix<int> result = new Convolution<int>(windowSize, kernel, strides, padding)
            {
                Param = matrix
            };

            var expected = Patronus.From<int>(
                1*1 + 2*2 + 5*3 + 6*4,
                2*1 + 3*2 + 6*3 + 7*4,
                3*1 + 4*2 + 7*3 + 8*4,
                5*1 + 6*2 + 9*3 + 10*4,
                6*1 + 7*2 + 10*3 + 11*4,
                7*1 + 8*2 + 11*3 + 12*4,
                9*1 + 10*2 + 13*3 + 14*4,
                10*1 + 11*2 + 14*3 + 15*4,
                11*1 + 12*2 + 15*3 + 16*4
                ).Reshape(3, 3);

            Print(matrix, result, expected);

            Assert.True(expected.Equals(result));


        }


        [Fact]
        public void TestBigConvolution()
        {
            // 1  2  3  4
            // 5  6  7  8
            // 9  10 11 12
            // 13 14 15 16

            // 1 2
            // 3 4

            var matrix = Patronus.Random(-10, 10, 30, 30);
            var kernel = Patronus.Random(-5, 10, 9, 9);
            var windowSize = kernel.Sizes;
            var strides = new List<int>() { 3, 3 };
            var padding = 3;

            Matrix<int> result = new Convolution<int>(windowSize, kernel, strides, padding)
            {
                Param = matrix
            };


            Print(matrix);
            Print(kernel);
            Print(result);



        }

    }
}
