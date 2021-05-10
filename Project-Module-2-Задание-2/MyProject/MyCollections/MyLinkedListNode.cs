namespace MyCollections
{
    internal class MyLinkedListNode
    {
        internal MyLinkedListNode(object value)
        {
            Value = value;
        }

        internal MyLinkedListNode Next { get; set; }

        internal object Value { get; set; }

        internal void Invalidate()
        {
            Next = null;
            Value = null;
        }
    }
}
