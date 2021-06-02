using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public class BusinessClassObserver : IObserver
    {
        private Logger.Logger _logger = Logger.Logger.Instance;

        public void Update(string message)
        {
            _logger.AddLog(message);
        }
    }
}
