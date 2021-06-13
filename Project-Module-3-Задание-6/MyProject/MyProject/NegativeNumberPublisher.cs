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
        public event EventHandler<MyEventArgs> Handler;

        public void Publish(MyEventArgs e)
        {
            Handler?.Invoke(this, e);
        }

        public void GenerateValue()
        {
            for (int i = 0; i < 10; i++)
            {
                int value = new Random().Next(1000);

                value *= -1;

                Publish(new MyEventArgs(value));
            }
        }

        public async void GenerateValeAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            await Task.Run(() => GenerateValue());
        }
    }
}
