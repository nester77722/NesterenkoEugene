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
            Console.WriteLine(_dateTime.ToLongTimeString());
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
    }
}
