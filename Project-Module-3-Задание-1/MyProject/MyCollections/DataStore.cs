using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class DataStore<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] _data;
        private int _position = -1;

        public DataStore()
          : this(4)
        {
        }

        public DataStore(int size)
        {
            _data = new T[size];
            Count = 0;
        }

        public int Count { get; private set; }

        object IEnumerator.Current
        {
            get
            {
                return _data[_position];
            }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return _data[_position];
            }
        }

        public T this[int index]
        {
            get
            {
                return GetByIndex(index);
            }
            set
            {
                Insert(value, index);
            }
        }

        public void Add(T value)
        {
            if (IsFull())
            {
                Resize();
            }

            _data[Count++] = value;
        }

        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(T value, int index)
        {
            if (index > Count)
            {
                throw new IndexOutOfRangeException("Index is bigger than Count");
            }

            if (IsFull())
            {
                Resize();
            }

            Array.Copy(_data, index, _data, index + 1, Count - index);
            _data[index] = value;

            Count++;
        }

        public bool IsFull()
        {
            return Count == _data.Length;
        }

        public T GetByIndex(int index)
        {
            if (index > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            return _data[index];
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            Array.Copy(_data, array, Count);

            return array;
        }

        public void RemoveAt(int index)
        {
            int start = index + 1;

            if (start < Count)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _data[i] = _data[i + 1];
                }
            }

            Count--;
            _data[Count] = default(T);
        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        bool IEnumerator.MoveNext()
        {
            if (_position < Count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        void IEnumerator.Reset()
        {
            _position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        private void Resize()
        {
            int capacity = _data.Length == 0 ? 4 : _data.Length * 2;
            T[] newArray = new T[capacity];

            _data.CopyTo(newArray, 0);

            _data = newArray;
        }
    }
}
