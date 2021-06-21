using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileProcessor userFile = new FileProcessor("users.txt");
            FileProcessor ordersFile = new FileProcessor("Orders.txt");

            List<Task<List<string>>> tasks = new List<Task<List<string>>>();
            tasks.Add(Task.Run(userFile.ReadTextAsync));
            tasks.Add(Task.Run(ordersFile.ReadTextAsync));

            Task.WhenAll(tasks);

            List<string> users = tasks[0].Result;
            List<string> orders = tasks[1].Result;

            DataProcessor dataProcessor = new DataProcessor(users, orders);
            dataProcessor.CreateResultAsync();

            while(true)
            {

            }
        }
    }
}
