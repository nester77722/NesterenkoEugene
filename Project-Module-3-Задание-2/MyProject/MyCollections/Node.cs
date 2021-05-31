using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCollections
{
    [Serializable]
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

        internal Node<T> Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(stream, this);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                stream.Position = 0;

#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return formatter.Deserialize(stream) as Node<T>;
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
