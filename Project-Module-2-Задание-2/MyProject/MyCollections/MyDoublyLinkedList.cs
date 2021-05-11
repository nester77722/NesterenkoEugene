using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class MyDoublyLinkedList : MyLinkedList
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
            if (Count == 0)
            {
                _head = new MyDoublyLinkedListNode();
                _tail = new MyDoublyLinkedListNode();
            }

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
            if (Count == 0)
            {
                _head = new MyDoublyLinkedListNode();
                _tail = new MyDoublyLinkedListNode();
            }

            MyDoublyLinkedListNode node = new MyDoublyLinkedListNode(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }

            Count++;
        }
    }
}
