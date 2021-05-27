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

            // true
            // false
            // false
            foreach (var item in queue)
            {
                Console.WriteLine(item);
                dataStore.Add(item);
            }

            Stack<bool> stack = new Stack<bool>();
            stack.Push(true);
            stack.Push(false);
            stack.Push(false);

            // false
            // false
            // true
            foreach (var item in stack)
            {
                Console.WriteLine(item);
                dataStore.Add(item);
            }

            // true
            // false
            // false
            // false
            // false
            // true
            foreach (var item in dataStore)
            {
                Console.WriteLine(item);
            }

            Week week = new Week();

            // Выводится дважды, Reset() работает
            for (int i = 0; i < 2; i++)
            {
                foreach (var day in week)
                {
                    Console.WriteLine(day);
                }
            }
        }
    }
}
