using System;

namespace MyCollections
{
    internal class Node<T>
    {
        internal Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

        internal T Value { get; set; }

        internal Node<T> Next { get; set; }
    }
}
