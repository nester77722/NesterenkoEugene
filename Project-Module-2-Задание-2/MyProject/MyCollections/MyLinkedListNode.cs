namespace MyCollections
{
    internal class MyLinkedListNode
    {
        internal MyLinkedListNode()
        {
        }

        internal MyLinkedListNode(object value)
        {
            Value = value;
        }

        internal MyLinkedListNode Next { get; set; }

        internal object Value { get; set; }

        internal virtual void Invalidate()
        {
            Next = null;
            Value = null;
        }
    }
}
