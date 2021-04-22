using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Logger
    {
        private static Logger _uniqueInstance;

        private StringBuilder _output;

        private DateTime _dateTime;

        private Logger()
        {
            _output = new StringBuilder();
        }

        public static Logger Instance()
        {
            if (_uniqueInstance == null)
            {
                _uniqueInstance = new Logger();
            }

            return _uniqueInstance;
        }
    }
}
