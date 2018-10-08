using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Patronus.Extensions;

namespace Patronus.Enumerators
{
    public class IndexEnumerator : IEnumerator<IEnumerable<int>>
    {
        private readonly IEnumerable<int> _sizes;

        private IList<int> _current;
        private bool _isReset = true;

        public IndexEnumerator(IEnumerable<int> sizes)
        {
            _sizes = sizes.Select(i => i).ToList();
            _current = Enumerable.Repeat(0, _sizes.Count()).ToList();
        }
        
        public bool MoveNext()
        {
            if (_current.IsLastIndex(_sizes)) return false;
            if (_isReset)
                _isReset = false;
            else
                _current = _current.IncrementIndex(_sizes);
            return true;
        }

        public void Reset()
        {
            _current = Enumerable.Repeat(0, _sizes.Count()).ToList();
            _isReset = true;
        }

        [NotNull]
        public IEnumerable<int> Current => _current.Select(i => i);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}