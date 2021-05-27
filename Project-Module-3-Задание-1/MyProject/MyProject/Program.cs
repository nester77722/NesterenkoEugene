using System;

// using System.Collections.Generic;
using MyCollections;
using MyCollections.DaysOfWeek;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataStore<bool> dataStore = new DataStore<bool>();

            Queue<bool> queue = new Queue<bool>();
            queue.Enqueue(true);
            queue.Enqueue(false);
            queue.Enqueue(false);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
                dataStore.Add(item);
            }

            Stack<bool> stack = new Stack<bool>();
            stack.Push(true);
            stack.Push(false);
            stack.Push(false);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
                dataStore.Add(item);
            }

            foreach (var item in dataStore)
            {
                Console.WriteLine(item);
            }
        }
    }
}
