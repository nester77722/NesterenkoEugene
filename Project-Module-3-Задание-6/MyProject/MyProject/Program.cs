using System;
using System.Collections.Generic;
using System.Threading;

namespace MyProject
{
    public class Program
    {
        private Queue<int> _values = new Queue<int>();

        public static void SaveValueToQueue(object sender, MyEventArgs e)
        {
        }

        public static void Main(string[] args)
        {
            PositiveNumberPublisher publisher1 = new PositiveNumberPublisher();
            NegativeNumberPublisher publisher2 = new NegativeNumberPublisher();

            Subscriber subscriber = new Subscriber();
            subscriber.AddPublisher(publisher1);
            subscriber.AddPublisher(publisher2);

            Thread thread1 = new Thread(publisher1.GenerateValue);
            Thread thread2 = new Thread(publisher2.GenerateValue);

            thread1.Start();
            thread2.Start();
        }
    }
}
