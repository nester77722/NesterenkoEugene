﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    public class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public Queue()
        {
            _head = _tail = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            if (_tail == null)
            {
                _head = _tail = new Node<T>(value, null);
            }
            else
            {
                _tail.Next = new Node<T>(value, null);
                _tail = _tail.Next;
            }

            Count++;
        }

        public T Dequeue()
        {
            if (_head == null)
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
