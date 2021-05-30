using System;
using System.IO;
using MyCollections;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();

            list.AddFirst(4);
            list.AddFirst(3);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
