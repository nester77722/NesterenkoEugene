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

        public static Logger Instance
        {
            get
            {
                if (_uniqueInstance == null)
                {
                    _uniqueInstance = new Logger();
                }

                return _uniqueInstance;
            }
        }

        public void AddLog(LogType logType, string message)
        {
            _dateTime = DateTime.Now;

            if (!string.IsNullOrWhiteSpace(message))
            {
                _output.Append($"{_dateTime.ToLongTimeString()}: {logType}: Action failed by a reason: {message}\n");
            }
            else
            {
                _output.Append($"{_dateTime.ToLongTimeString()}: {logType}\n");
            }
        }

        public string GetLogs()
        {
            return _output.ToString();
        }
    }
}
