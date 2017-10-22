using System;

namespace Assignment1
{
    class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _index;   
        private bool emptyArray = true;

        public IntegerList()
        {
            _internalStorage=new int[4];
        }

        public IntegerList(int initialSize)
        {
            if (initialSize < 0)
            {
                initialSize = 4;
            }
            _internalStorage=new int[initialSize];
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

        public void Add(int item)
        {
            if (_index+1 >= _internalStorage.Length)
            {
                int[] tmpField = new int[Count * 2];
                for(int i=0; i<_internalStorage.Length;i++)
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
            _internalStorage=new int[4];
        }

        public bool Contains(int item)
        {
            for (int i = 0; i <= _index; i++)
            {
                if (_internalStorage[i]==item)
                {
                    return true;
                }
                
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index > _index || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i=0; i<=_index;i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
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
            int[] tmpField=new int[_internalStorage.Length];
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
    }
}
