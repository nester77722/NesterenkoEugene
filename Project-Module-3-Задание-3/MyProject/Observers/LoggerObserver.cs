using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observers
{
    public class LoggerObserver
    {
        private Logger.Logger _logger = Logger.Logger.Instance;

        public void LogNotyfies(string message)
        {
            _logger.AddLog(message);
        }
    }
}
