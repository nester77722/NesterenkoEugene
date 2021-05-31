using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCollections
{
    public class MyLinkedList<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public MyLinkedList(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public int Count { get; private set; }

        public T this[int index]
        {
             get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> head = _head;

                for (int i = 0; i < index; i++)
                {
                    head = head.Next;
                }

                Node<T> result = head.Clone();
                return result.Value;
            }
        }

        public MyLinkedList<T> CloneList()
        {
            MyLinkedList<T> newList = new MyLinkedList<T>(ToArray());

            return newList;
        }

        public int IndexOf(T value)
        {
            Node<T> current = _head;
            int i = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return i;
                }

                current = current.Next;
                i++;
            }

            return -1;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            Node<T> node = _head;

            int i = 0;

            while (node != null)
            {
                array[i] = node.Value;
                i++;
                node = node.Next;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;

            while (current != null)
            {
                var copy = current.Clone();
                yield return copy.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            node.Next = _head;
            _head = node;

            if (Count == 0)
            {
                _tail = _head;
            }

            Count++;
        }

        private void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }
    }
}
