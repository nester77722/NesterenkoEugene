using System;

namespace MyCollections
{
    public class MyLinkedList : IMyLinkedList
    {
        private MyLinkedListNode _head;
        private MyLinkedListNode _tail;

        public int Count { get; private set; }

        public object this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    return null;
                }

                MyLinkedListNode head = _head;

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
                else
                {
                    MyLinkedList newList = CloneList();
                    Clear();

                    MyLinkedListNode head = newList._head;
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

        public void Clear()
        {
            MyLinkedListNode head = _head;

            while (head != null)
            {
                MyLinkedListNode node2 = head;
                head = head.Next;
                node2.Invalidate();
            }

            _head = null;
            Count = 0;
        }

        public MyLinkedList CloneList()
        {
            MyLinkedList newList = new MyLinkedList();

            if (_head == null)
            {
                return newList;
            }

            MyLinkedListNode head = _head;

            while (head != null)
            {
                newList.AddLast(head.Value);
                head = head.Next;
            }

            return newList;
        }
    }
}
