using System;
using MyCollections;

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();

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

            // -1
            Console.WriteLine(list.IndexOf("Bob"));

            // 0
            Console.WriteLine(list.IndexOf("Hi"));

            // 1
            Console.WriteLine(list.IndexOf("world"));

            list[1] = "beautiful";
            array = list.ToArray();

            // Hi
            // beautiful
            // world
            foreach (var @object in array)
            {
                Console.WriteLine(@object);
            }
        }
    }
}
