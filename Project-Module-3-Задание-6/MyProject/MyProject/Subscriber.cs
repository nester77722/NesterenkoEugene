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
        private Queue<int> _values = new Queue<int>();
        private object _syncRoot = new object();

        public Subscriber()
        {
        }

        public void AddPublisher(IPublisher publisher)
        {
            publisher.Handler += Receive;
        }

        public void DequeueValues()
        {
            lock (_syncRoot)
            {
                for (int i = 0; i < _values.Count; i++)
                {
                    Console.WriteLine(_values.Dequeue());
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
            }
        }
    }
}
