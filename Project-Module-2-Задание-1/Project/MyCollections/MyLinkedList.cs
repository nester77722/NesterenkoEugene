using System;

namespace MyCollections
{
    public class MyLinkedList : IMyLinkedList
    {
        private MyLinkedListNode _head;
        private MyLinkedListNode _tail;

        public int Count { get; private set; }
        public void AddFirst(object value)
        {
            MyLinkedListNode node = new MyLinkedListNode(value);
            node.Next = _head;
            _head = node;

            if (Count == 0)
            {
                _tail = _head;
            }

            Count++;
        }

        public void AddLast(object value)
        {
            MyLinkedListNode node = new MyLinkedListNode(value);

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
