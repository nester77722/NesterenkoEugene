using System;
using System.IO;
using Writers;
using Newtonsoft.Json;

namespace Logger
{
    public class Logger
    {
        private static Logger _uniqueInstance;

        private DateTime _dateTime;

        private IWriter _writer;

        private LoggerConfig _loggerConfig;

        private Logger()
        {
            ReadConfig();
            _writer = new FileWriter(_loggerConfig.DirectoryPath);
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

        public void AddLog(string message)
        {
            _dateTime = DateTime.Now;

            string logMessage = $"{_dateTime.ToShortDateString()} {_dateTime.ToLongTimeString()} ---> {message}";
            _writer.Write(logMessage);
        }

        public string GetLogs()
        {
            return _writer.GetBuffer();
        }

        private void ReadConfig()
        {
            string path = @"D:\LogProgram\Configs\LoggerConfig.json";

            var configPath = File.ReadAllText(path);
            _loggerConfig = JsonConvert.DeserializeObject<LoggerConfig>(configPath);
        }
    }
}
