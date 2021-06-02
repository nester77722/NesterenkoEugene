using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public interface IObserver
    {
        void Update(string message);
    }
}
