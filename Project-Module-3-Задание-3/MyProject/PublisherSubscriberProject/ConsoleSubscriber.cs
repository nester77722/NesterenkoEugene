using System;

namespace PublisherSubscriberProject
{
    public class ConsoleSubscriber : ISubscriber
    {
        public ConsoleSubscriber(IPublisher pub)
        {
            Publisher = pub;
            Publisher.PublisherEvent += HandleEvent;
        }

        public IPublisher Publisher { get; init; }

        public void HandleEvent(object sender, MyEventArgs e)
        {
            Console.WriteLine($"{GetType().Name} received this message: {e.Message}");
        }
    }
}
