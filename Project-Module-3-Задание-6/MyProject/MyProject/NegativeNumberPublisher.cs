using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject
{
    public class NegativeNumberPublisher : IPublisher
    {
        private Queue<int> _values;
        private object _obj = new object();

        public NegativeNumberPublisher(Queue<int> values)
        {
            _values = values;
        }

        public void Publish()
        {
        }

        public async void PublishAsync()
        {
            await Task.Run(
                () =>
                {
                    Random random = new Random();
                    for (int i = 0; i < 10; i++)
                    {
                        lock (_values)
                        {
                            _values.Enqueue(random.Next(100) * -1);
                        }

                        Thread.Sleep(100);
                    }
                });
        }

        private int GenerateValue()
        {
            Random random = new Random();

            return random.Next(100) * -1;
        }
    }
}
