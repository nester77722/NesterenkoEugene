using System;

namespace MyCollections
{
    public class MyLinkedList : IMyLinkedList
    {
        internal MyLinkedListNode _head;
        internal MyLinkedListNode _tail;

        public int Count { get; protected set; }

        public virtual object this[int index]
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
                else if (index == 0)
                {
                    AddFirst(value);
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

        public virtual void AddFirst(object value)
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

        public virtual void AddLast(object value)
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

        public int IndexOf(object value)
        {
            MyLinkedListNode current = _head;
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

        public bool Remove(object value)
        {
            MyLinkedListNode node = _head;

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

            MyLinkedListNode node = _head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            RemoveNode(node);

            return true;
        }

        public bool RemoveEveryEqual(object item)
        {
            bool isSuccesfull = false;

            while (Remove(item))
            {
                isSuccesfull = true;
            }

            return isSuccesfull;
        }

        public object[] ToArray()
        {
            object[] array = new object[Count];

            MyLinkedListNode node = _head;

            int i = 0;

            while (node != null)
            {
                array[i] = node.Value;
                i++;
                node = node.Next;
            }

            return array;
        }

        private void RemoveNode(MyLinkedListNode node)
        {
            MyLinkedListNode previous = null;
            MyLinkedListNode current = _head;

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
