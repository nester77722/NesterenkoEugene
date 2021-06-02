using System;
using System.Collections.Generic;
using System.Linq;
using Logger;
using System.Threading.Tasks;

namespace PublisherSubscriberProject
{
    public class LoggerSubscriber : ISubscriber
    {
        Logger.Logger _logger = Logger.Logger.Instance;

        public LoggerSubscriber(Publisher pub)
        {
            Publisher = pub;
            pub.PublisherEvent += HandleEvent;
        }

        public IPublisher Publisher { get; init; }

        public void HandleEvent(object sender, MyEventArgs e)
        {
            _logger.AddLog(e.Message);
        }
    }
}
