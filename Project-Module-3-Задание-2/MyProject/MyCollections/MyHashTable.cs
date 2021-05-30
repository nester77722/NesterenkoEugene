using System;
using System.Collections.Generic;

namespace MyCollections
{
    public class MyHashTable<TK, T>
        where TK : IComparable<TK>
        where T : IComparable<T>
    {
        private const int DefaultCapacity = 100;
        private const double DefaultLoadFactor = 0.75;

        private readonly double _loadFactor;

        private int _threshold;
        private int _count;
        private HashNode<TK, T>[] _buckets;

        public MyHashTable()
            : this(DefaultCapacity, DefaultLoadFactor)
        {
        }

        public MyHashTable(int capacity)
            : this(capacity, DefaultLoadFactor)
        {
        }

        public MyHashTable(int capacity, double loadFactor)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity can't be less than 0.");
            }

            if (loadFactor <= 0)
            {
                throw new ArgumentException("Load can't be less than 0.");
            }

            if (capacity == 0)
            {
                capacity = 1;
            }

            _loadFactor = loadFactor;
            _buckets = new HashNode<TK, T>[capacity];

            _threshold = Convert.ToInt32(capacity * loadFactor);
        }

        public int Count => _count;

        public bool ContainsKey(TK key)
        {
            int index = Hash(key);
            var item = _buckets[index];

            if (item == null)
            {
                return false;
            }

            while (item != null)
            {
                if (item.Key.CompareTo(key) == 0)
                {
                    return true;
                }

                item = item.Next;
            }

            return false;
        }

        public bool ContainsValue(T value)
        {
            foreach (var bucket in _buckets)
            {
                if (bucket == null)
                {
                    continue;
                }

                var item = bucket;
                while (item != null)
                {
                    if (item.Value.CompareTo(value) == 0)
                    {
                        return true;
                    }

                    item = item.Next;
                }
            }

            return false;
        }

        public T Find(TK key)
        {
            var index = Hash(key);
            var item = _buckets[index];

            if (item == null)
            {
                return default;
            }

            while (item != null)
            {
                if (item.Key.CompareTo(key) == 0)
                {
                    return item.Value;
                }

                item = item.Next;
            }

            return default;
        }

        public void Add(TK key, T value)
        {
            var index = Hash(key);
            var bucket = _buckets[index];

            while (bucket != null)
            {
                if (key.CompareTo(bucket.Key) == 0)
                {
                    bucket.Value = value;
                    return;
                }

                bucket = bucket.Next;
            }

            if (_count + 1 > _threshold)
            {
                Rehash();
                index = Hash(key);
            }

            var item = new HashNode<TK, T>(key, value);
            item.Next = _buckets[index];

            _buckets[index] = item;
            _count++;
        }

        public ICollection<T> GetValues()
        {
            List<T> values = new List<T>();

            foreach (var bucket in _buckets)
            {
                if (bucket != null)
                {
                    var current = bucket;
                    while (current != null)
                    {
                        values.Add(current.Value);
                        current = current.Next;
                    }
                }
            }

            return values;
        }

        public void Remove(TK key)
        {
            var index = Hash(key);
            var bucket = _buckets[index];
            HashNode<TK, T> lastNode = null;

            while (bucket != null)
            {
                if (bucket.Key.CompareTo(key) == 0)
                {
                    _count--;
                    if (lastNode == null)
                    {
                        _buckets[index] = bucket.Next;
                    }
                    else
                    {
                        lastNode.Next = bucket.Next;
                    }
                }

                lastNode = bucket;
                bucket = bucket.Next;
            }
        }

        private int Hash(TK key)
        {
            return key == null ? 0 : Math.Abs(key.GetHashCode() % _buckets.Length);
        }

        private void Rehash()
        {
            var oldBuckets = _buckets;

            var newCapacity = (_buckets.Length * 2) + 1;
            _threshold = Convert.ToInt32(newCapacity * _loadFactor);
            _buckets = new HashNode<TK, T>[newCapacity];

            for (var i = oldBuckets.Length - 1; i > 0; i--)
            {
                var currentNode = oldBuckets[i];
                while (currentNode != null)
                {
                    var index = Hash(currentNode.Key);
                    var node = new HashNode<TK, T>(currentNode.Key, currentNode.Value)
                    {
                        Next = _buckets[index]
                    };
                    _buckets[index] = node;
                    currentNode = currentNode.Next;
                }
            }
        }
    }
}
