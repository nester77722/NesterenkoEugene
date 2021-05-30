using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    return default(T);
                }

                Node<T> head = _head;

                for (int i = 0; i < index; i++)
                {
                    head = head.Next;
                }

                return head.Value;
            }

            set
            {
                if (index > Count || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                if (index == Count)
                {
                    AddLast(value);
                }
                else if (index == 0)
                {
                    AddFirst(value);
                }
                else
                {
                    MyLinkedList<T> newList = CloneList();
                    Clear();

                    Node<T> head = newList._head;
                    int i = 0;

                    while (head != null)
                    {
                        if (i == index)
                        {
                            AddLast(value);
                        }

                        AddLast(head.Value);
                        head = head.Next;
                        i++;
                    }
                }
            }
        }

        public void AddFirst(T value)
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

        public void AddLast(T value)
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

        public void Clear()
        {
            Node<T> head = _head;

            while (head != null)
            {
                Node<T> node2 = head;
                head = head.Next;
                node2.Invalidate();
            }

            _head = null;
            Count = 0;
        }

        public MyLinkedList<T> CloneList()
        {
            MyLinkedList<T> newList = new MyLinkedList<T>();

            if (_head == null)
            {
                return newList;
            }

            Node<T> head = _head;

            while (head != null)
            {
                newList.AddLast(head.Value);
                head = head.Next;
            }

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

        public bool Remove(T value)
        {
            Node<T> node = _head;

            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    RemoveNode(node);
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public bool RemoveByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            Node<T> node = _head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            RemoveNode(node);

            return true;
        }

        public bool RemoveEveryEqual(T item)
        {
            bool isSuccesfull = false;

            while (Remove(item))
            {
                isSuccesfull = true;
            }

            return isSuccesfull;
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
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void RemoveNode(Node<T> node)
        {
            Node<T> previous = null;
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head.Next;

                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }

                    Count--;
                }

                previous = current;
                current = current.Next;
            }
        }
    }
}
