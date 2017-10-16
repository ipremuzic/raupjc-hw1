using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment3
{
    public class GenericList <X> : IGenericList <X>
    {
        private X[] _internalStorage;
        private int _index;
        private bool emptyArray = true;

        public GenericList()
        {
            _internalStorage = new X[4];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                initialSize = 4;
            }
            _internalStorage = new X[initialSize];
        }

        public int Count
        {
            get
            {
                if (emptyArray)
                {
                    return 0;
                }
                return _index + 1;
            }
        }

        public void Add(X item)
        {
            if (_index + 1 >= _internalStorage.Length)
            {
                X[] tmpField = new X[Count * 2];
                for (int i = 0; i < _internalStorage.Length; i++)
                {
                    tmpField[i] = _internalStorage[i];
                }
                _internalStorage = tmpField;
            }
            if (emptyArray)
            {
                _internalStorage[_index] = item;
                emptyArray = false;
            }
            else
            {
                _internalStorage[++_index] = item;
            }

        }

        public void Clear()
        {
            _index = 0;
            emptyArray = true;
            _internalStorage = new X[0];
        }

        public bool Contains(X item)
        {
            for (int i = 0; i <= _index; i++)
            {
                if (_internalStorage[i] != null)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public X GetElement(int index)
        {
            if (index > _index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= _index; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
        {
            int indexOfItem = this.IndexOf(item);
            try
            {
                return this.RemoveAt(indexOfItem);
            }
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }

        }

        public bool RemoveAt(int index)
        {
            if (index > _index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int j = 0;
            X[] tmpField = new X[_internalStorage.Length];
            for (int i = 0; i <= _index; i++)
            {
                if (i != index)
                {
                    tmpField[j++] = _internalStorage[i];
                }
            }
            _internalStorage = tmpField;
            _index--;
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator <X> (this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
