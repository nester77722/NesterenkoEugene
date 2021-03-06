using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class Stack<T> : IEnumerable<T>
    {
        private Node<T> _head;

        public Stack()
        {
            _head = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T value)
        {
            _head = new Node<T>(value, _head);

            Count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            T value = _head.Value;

            _head = _head.Next;
            Count--;

            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool IsEmpty()
        {
            if (_head == null)
            {
                return true;
            }

            return false;
        }
    }
}
