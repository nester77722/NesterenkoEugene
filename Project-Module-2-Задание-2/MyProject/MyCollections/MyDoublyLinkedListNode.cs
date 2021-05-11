using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollections
{
    internal class MyDoublyLinkedListNode : MyLinkedListNode
    {
        internal MyDoublyLinkedListNode()
            : base()
        {
        }

        internal MyDoublyLinkedListNode(object value)
            : base(value)
        {
        }

        internal MyLinkedListNode Previous { get; set; }

        internal override void Invalidate()
        {
            base.Invalidate();
        }
    }
}
