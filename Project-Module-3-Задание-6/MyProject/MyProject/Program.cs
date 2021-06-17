using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> values = new Queue<int>();

            PositiveNumberPublisher publisher1 = new PositiveNumberPublisher(values);
            NegativeNumberPublisher publisher2 = new NegativeNumberPublisher(values);
            PositiveNumberPublisher publisher3 = new PositiveNumberPublisher(values);
            NegativeNumberPublisher publisher4 = new NegativeNumberPublisher(values);
            PositiveNumberPublisher publisher5 = new PositiveNumberPublisher(values);
            NegativeNumberPublisher publisher6 = new NegativeNumberPublisher(values);
            PositiveNumberPublisher publisher7 = new PositiveNumberPublisher(values);

            Subscriber subscriber = new Subscriber(values);
            publisher1.PublishAsync();
            publisher2.PublishAsync();
            publisher3.PublishAsync();
            publisher4.PublishAsync();
            publisher5.PublishAsync();
            publisher6.PublishAsync();
            publisher7.PublishAsync();

            subscriber.Consume();
        }
    }
}
