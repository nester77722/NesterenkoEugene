using System;

namespace PublisherSubscriberProject
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
