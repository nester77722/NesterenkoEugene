using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    public class Subscriber
    {
        private Queue<int> _values;

        public Subscriber(Queue<int> values)
        {
            _values = values;
        }

        public void Consume()
        {
            while (true)
            {
                if (_values.Count != 0)
                {
                    lock (_values)
                    {
                        Console.WriteLine(_values.Dequeue());
                    }
                }
            }
        }
    }
}
