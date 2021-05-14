using System;

namespace MyProject
{
    public class Logger
    {
        private static Logger _uniqueInstance;

        private DateTime _dateTime;

        private FileService _fileService;

        private Logger()
        {
            _fileService = new FileService();

            _dateTime = DateTime.Now;
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

        public void AddLog(LogTypes logType, string message)
        {
            _dateTime = DateTime.Now;

            string logMessage = $"{_dateTime.ToShortDateString()} {_dateTime.ToLongTimeString()} ---> {message}";
            _fileService.Write(logMessage);
        }

        public string GetLogs()
        {
            return _fileService.GetBuffer();
        }
    }
}
