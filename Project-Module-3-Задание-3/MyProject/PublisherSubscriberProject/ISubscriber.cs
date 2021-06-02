using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriberProject
{
    public interface ISubscriber
    {
        public IPublisher Publisher { get; init; }

        public void HandleEvent(object sender, MyEventArgs e);
    }
}
