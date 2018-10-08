using System.Collections.Generic;
using Patronus.Assertions;

namespace Patronus.Extensions
{
    public static class AssertionsExtension
    {

        public static void AssertValidIndex(this Matrix matrix, IEnumerable<int> indexes)
        {
            ValidIndexAssertion.Assert(indexes, matrix);
        }

    }
}
