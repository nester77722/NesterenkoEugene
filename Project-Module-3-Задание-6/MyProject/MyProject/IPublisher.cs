using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public interface IPublisher
    {
        public event EventHandler<MyEventArgs> Handler;

        public void Publish(MyEventArgs e);
    }
}
