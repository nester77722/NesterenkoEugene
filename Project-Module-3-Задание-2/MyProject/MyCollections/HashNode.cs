using System;

namespace MyCollections
{
    public class HashNode<TK, T>
        where TK : IComparable<TK>
        where T : IComparable<T>
    {
        private TK _key;
        private T _value;
        private HashNode<TK, T> _next;
        private bool _isDeleted;

        public HashNode(TK key, T value)
        {
            _key = key;
            _value = value;
        }

        public TK Key => _key;

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public HashNode<TK, T> Next
        {
            get => _next;
            set => _next = value;
        }
    }
}