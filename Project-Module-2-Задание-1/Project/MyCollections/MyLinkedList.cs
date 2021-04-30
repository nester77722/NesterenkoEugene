using System;

namespace MyCollections
{
    public class MyLinkedList : IMyLinkedList
    {
        private MyLinkedListNode _head;
        private MyLinkedListNode _tail;

        public int Count { get; private set; }
    }
}
