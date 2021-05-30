using System;

namespace MyCollections
{
    internal class Node<T>
    {
        internal Node(T value)
        {
            Value = value;
        }

        internal T Value { get; set; }

        internal Node<T> Next { get; set; }

        internal void Invalidate()
        {
            Next = null;
            Value = default(T);
        }
    }
}
