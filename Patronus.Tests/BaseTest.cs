using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Patronus.Extensions;
using Patronus.Tests.Helpers;
using Xunit.Abstractions;

namespace Patronus.Tests
{
    public class BaseTest
    {
        protected readonly ITestOutputHelper Output;

        private XUnitOutputPrinter _printer;
        protected XUnitOutputPrinter Printer
        {
            get
            {
                if (_printer == null)
                    _printer = new XUnitOutputPrinter(Output);
                return _printer;
            }
        }

        protected BaseTest(ITestOutputHelper output)
        {
            this.Output = output;
        }

        protected void Print<T>(Matrix<T> left, Matrix<T> right, Matrix<T> result, Matrix<T> expected, [CallerMemberName]string name = "")
        {
            Output.WriteLine(name);
            Output.WriteLine("");
            Output.WriteLine("Left");
            left.Print(Printer);
            Output.WriteLine("");
            Output.WriteLine("Right");
            right.Print(Printer);
            Output.WriteLine("");
            Output.WriteLine("Result");
            result.Print(Printer);
            Output.WriteLine("");
            Output.WriteLine("Expected");
            expected.Print(Printer);
        }

        protected void Print<T>(Matrix<T> matrix, Matrix<T> result, Matrix<T> expected, [CallerMemberName]string name = "")
        {
            Output.WriteLine(name);
            Output.WriteLine("");

            Output.WriteLine("Matrix");
            matrix.Print(Printer);
            Output.WriteLine("");
           
            Output.WriteLine("Result");
            result.Print(Printer);
            Output.WriteLine("");

            Output.WriteLine("Expected");
            expected.Print(Printer);
        }

        protected void Print<T, TResult>(Matrix<T> left, Matrix<T> right, TResult result, TResult expected, [CallerMemberName]string name = "")
        {

            Output.WriteLine(name);
            Output.WriteLine("");

            Output.WriteLine("Left");
            left.Print(Printer);
            Output.WriteLine("");

            Output.WriteLine("Right");
            right.Print(Printer);
            Output.WriteLine("");

            Output.WriteLine("Result");
            Output.WriteLine(result.ToString());
            Output.WriteLine("");

            Output.WriteLine("Expected");
            Output.WriteLine(expected.ToString());
            Output.WriteLine("");

        }

        protected void Print<T, TResult>(Matrix<T> matrix, TResult result, TResult expected, [CallerMemberName]string name = "")
        {

            Output.WriteLine(name);
            Output.WriteLine("");

            Output.WriteLine("Matrix");
            matrix.Print(Printer);
            Output.WriteLine("");

            Output.WriteLine("Result");
            Output.WriteLine(result.ToString());
            Output.WriteLine("");

            Output.WriteLine("Expected");
            Output.WriteLine(expected.ToString());
            Output.WriteLine("");

        }

        protected void Print<T>(Matrix<T> matrix)
        {

            Output.WriteLine("Matrix");
            matrix.Print(Printer);

        }

    }
}
