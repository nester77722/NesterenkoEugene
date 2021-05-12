using System;
using MyCollections;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyDoublyLinkedList list = new MyDoublyLinkedList();

            list.AddFirst("Hello");

            list.AddLast("world");

            list.AddLast("!");
            list.AddLast("!");
            list.AddLast("!");
            list.AddLast("!");

            list.RemoveByIndex(0);

            list.AddFirst("Hi");

            // check = true
            var check = list.RemoveEveryEqual("!");

            var array = list.ToArray();

            // Hi
            // world
            foreach (var @object in array)
            {
                Console.WriteLine(@object);
            }

            list.AddFirst("Bob");
            list.AddFirst("Eugene");
            list[0] = "Zero";

            list.RemoveByIndex(1);
            list.RemoveFirst();

            array = list.ToArray();

            // Bob
            // Hi
            // world
            foreach (var @object in array)
            {
                Console.WriteLine(@object);
            }

            list.Clear();
        }
    }
}
