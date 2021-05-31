using System;
using System.Collections.Generic;
using MyCollections;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 5, 2, 8 };

            MyLinkedList<int> intList = new MyLinkedList<int>(array);

            // intList[2]++;
            // Error CS0200  Property or indexer 'MyLinkedList<int>.this[int]' cannot be assigned to --it is read only

            // intList[0] = 4;
            // Error CS0200  Property or indexer 'MyLinkedList<int>.this[int]' cannot be assigned to --it is read only
            List<int>[] arrayList = new List<int>[1];

            arrayList[0] = new List<int>();
            arrayList[0].Add(15);
            arrayList[0].Add(10);

            MyLinkedList<List<int>> list = new MyLinkedList<List<int>>(arrayList);

            // Изменения не сохраняются
            list[0].Add(35);

            foreach (var item in list)
            {
                // Изменения не сохраняются
                item.Add(100);
            }

            foreach (var item in list)
            {
                foreach (var item2 in item)
                {
                    // 15
                    // 10
                    Console.WriteLine(item2);
                }
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
