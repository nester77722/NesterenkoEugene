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
        private ConcurrentQueue<int> _values = new ConcurrentQueue<int>();
        private object _syncRoot = new object();

        private bool _isEmpty = true;
        public Subscriber()
        {
        }

        public void AddPublisher(IPublisher publisher)
        {
            publisher.Handler += Receive;
        }

        public void DequeueValues()
        {
            while (true)
            {
                if (_isEmpty)
                {
                    continue;
                }

                int value;

                if (_values.TryDequeue(out value))
                {
                    Console.WriteLine(value);
                }
            }
        }

        public async void DequeueValuesAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            await Task.Run(() => DequeueValues());
        }

        private void Receive(object sender, MyEventArgs e)
        {
            lock (_syncRoot)
            {
                _values.Enqueue(e.Value);
                _isEmpty = false;
            }
        }
    }
}
