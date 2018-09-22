using System;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.IteratorUtility
{
    public class Iterator<T>
    {
        public IEnumerable<T> Elements { get; }
        private int _currentElementIndex;

        public Iterator(IEnumerable<T> elements)
        {
            Elements = elements;
        }

        public void Start()
        {
            _currentElementIndex = 0;
        }

        public T CurrentElement()
        {
            if (_currentElementIndex < Elements.Count())
            {
                return Elements.ElementAt(_currentElementIndex);
            }

            return default(T);
            
        }

        internal void MoveToNexElement()
        {
            _currentElementIndex++;
        }        
    }
}