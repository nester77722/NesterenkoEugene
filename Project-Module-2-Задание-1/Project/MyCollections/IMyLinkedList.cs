namespace MyCollections
{
    public interface IMyLinkedList
    {
        public int Count { get; }

        public object this[int index] { get; set; }

        public void AddFirst(object value);

        public void AddLast(object value);

        public bool Remove(object value);

        public bool RemoveEveryEqual(object item);

        public bool RemoveByIndex(int index);

        public int IndexOf(object value);

        public object[] ToArray();
    }
}
