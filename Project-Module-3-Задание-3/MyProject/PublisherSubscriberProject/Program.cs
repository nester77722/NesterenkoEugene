using System;

namespace PublisherSubscriberProject
{
    public class Program
    {
        public static void Main()
        {
            var pub = new Publisher();
            var sub1 = new ConsoleSubscriber(pub);
            var sub2 = new LoggerSubscriber(pub);

            pub.DoSomething();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
