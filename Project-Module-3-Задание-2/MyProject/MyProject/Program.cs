using System;
using System.Collections.Generic;
using MyCollections;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, 4, 5, 23, 42, 12, 3 };

            MyLinkedList<int> list = new MyLinkedList<int>(array);
            IReadOnlyCollection<int> readOnly = list;

            foreach (var item in readOnly)
            {
                Console.WriteLine(item);
            }

            MyHashTable<int, string> hashTable = new MyHashTable<int, string>();

            hashTable.Add(151312, "Ivan");
            hashTable.Add(1512312, "Eugene");

            foreach (var item in hashTable.GetValues())
            {
                Console.WriteLine(item);
            }
        }
    }
}
