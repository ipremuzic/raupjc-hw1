using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> _list;
        private int _currentIndex;
        private T _currentBox;

        public GenericListEnumerator(GenericList<T> list)
        {
            _list = list;
            _currentIndex = -1;

        }

        public void Dispose() {}

        public bool MoveNext()
        {
            if (++_currentIndex >= _list.Count)
            {
                return false;
            }

            _currentBox = _list.GetElement(_currentIndex);
            return true;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public T Current
        {
            get {return _currentBox;}
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
