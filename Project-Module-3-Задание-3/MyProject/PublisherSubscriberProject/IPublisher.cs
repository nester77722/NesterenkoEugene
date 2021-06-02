using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherSubscriberProject
{
    public interface IPublisher
    {
        public event EventHandler<MyEventArgs> PublisherEvent;

        public void OnRaiseEvent(MyEventArgs e);
    }
}
