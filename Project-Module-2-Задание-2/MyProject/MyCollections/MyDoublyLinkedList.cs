using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class MyDoublyLinkedList : MyLinkedList, IMyLinkedList
    {
        public override object this[int index]
        {
            get
            {
                if (index < Count / 2)
                {
                    return base[index];
                }

                MyDoublyLinkedListNode tail = (MyDoublyLinkedListNode)_tail;

                for (int i = Count - 1; i > index; i--)
                {
                    tail = (MyDoublyLinkedListNode)tail.Previous;
                }

                return tail.Value;
            }
        }

        public override void AddFirst(object value)
        {
            ReInitialization();

            MyDoublyLinkedListNode node = new MyDoublyLinkedListNode(value);
            node.Next = _head;
            _head = node;

            if (Count == 0)
            {
                _tail = _head;
            }
            else
            {
                MyDoublyLinkedListNode temp = (MyDoublyLinkedListNode)_head.Next;
                temp.Previous = _head;
            }

            Count++;            
        }

        public override void AddLast(object value)
        {
            ReInitialization();

            MyDoublyLinkedListNode node = new MyDoublyLinkedListNode(value);

            if (Count == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            Count++;
        }

        public new MyDoublyLinkedList CloneList()
        {
            MyDoublyLinkedList newList = new MyDoublyLinkedList();

            if (_head == null)
            {
                return newList;
            }

            MyDoublyLinkedListNode head = _head as MyDoublyLinkedListNode;

            while (head != null)
            {
                newList.AddLast(head.Value);
                head = head.Next as MyDoublyLinkedListNode;
            }

            return newList;
        }

        public override void Clear()
        {
            base.Clear();
            _tail = null;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                _head = _head.Next;
                Count--;

                if (Count == 0)
                {
                    _tail = null;
                }
                else
                {
                    MyDoublyLinkedListNode temp = _head as MyDoublyLinkedListNode;
                    temp.Previous = null;
                }
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    MyDoublyLinkedListNode temp = _tail as MyDoublyLinkedListNode;
                    temp.Previous.Next = null;
                    _tail = temp.Previous;
                }

                Count--;
            }
            
        }

        public override bool RemoveByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            if (index < Count / 2)
            {
                return base.RemoveByIndex(index);
            }

            MyDoublyLinkedListNode node = _head as MyDoublyLinkedListNode;

            for (int i = Count - 1; i > index; i--)
            {
                node = node.Next as MyDoublyLinkedListNode;
            }

            RemoveNode(node);

            return true;
        }

        private void ReInitialization()
        {
            if (Count == 0)
            {
                _head = new MyDoublyLinkedListNode();
                _tail = new MyDoublyLinkedListNode();
            }
        }

        private protected override void RemoveNode(MyLinkedListNode node)
        {
            node = node as MyDoublyLinkedListNode;
            MyDoublyLinkedListNode previous = null;
            MyDoublyLinkedListNode current = _head as MyDoublyLinkedListNode;

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
                        else
                        {
                            MyDoublyLinkedListNode temp = current.Next as MyDoublyLinkedListNode;
                            temp.Previous = previous;
                        }

                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                }

                previous = current;
                current = current.Next as MyDoublyLinkedListNode;
            }
        }     
    }
}
