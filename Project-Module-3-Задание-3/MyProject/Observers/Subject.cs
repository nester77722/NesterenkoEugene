using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public abstract class Subject
    {
        private Observer _observers = null;

        public delegate void Observer(string message);

        public event Observer Observers
        {
            add
            {
                _observers += value;
            }

            remove
            {
                _observers -= value;
            }
        }

        public void Notify(string message)
        {
            _observers.Invoke(message);
        }
    }
}
