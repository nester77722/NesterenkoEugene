using System;

namespace PublisherSubscriberProject
{
    public class Publisher : IPublisher
    {
        public event EventHandler<MyEventArgs> PublisherEvent;

        public void DoSomething()
        {
            OnRaiseEvent(new MyEventArgs("Event triggered"));
        }

        public void OnRaiseEvent(MyEventArgs e)
        {
            e.Message += $" at {DateTime.Now}";
            PublisherEvent?.Invoke(this, e);
        }
    }
}
