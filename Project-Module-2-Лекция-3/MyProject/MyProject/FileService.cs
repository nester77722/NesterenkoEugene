using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class FileService
    {
        private StreamWriter _streamWriter;
        private StringBuilder _buffer;
        private DateTime _dateTime;

        public FileService()
        {
            _buffer = new StringBuilder();
            _dateTime = DateTime.Now;

            CreateDirectory();
            DirePath = @"D:\LogProgram\Logs\";

            FilePath = $"{DirePath}{_dateTime.Hour}.{_dateTime.Minute}.{_dateTime.Second}.{_dateTime.ToShortDateString()}.txt";

            try
            {
                using (_streamWriter = new StreamWriter(FilePath, false))
                {
                    _streamWriter.Write(string.Empty);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Неверный путь файла!", ex);
            }
        }

        public string FilePath { get; }

        public string DirePath { get; }

        public void Write(string message)
        {
            _buffer.Append($"{message}\n");

            using (_streamWriter = new StreamWriter(FilePath, true))
            {
                _streamWriter.WriteLine(message);
            }
        }

        public string GetBuffer()
        {
            return _buffer.ToString();
        }

        private void CreateDirectory()
        {
            string path = @"D:\LogProgram\";

            string subPath = @"Logs";

            DirectoryInfo dirInfo = new DirectoryInfo(path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            dirInfo.CreateSubdirectory(subPath);
        }

        private void DeleteOldFiles()
        {
        }
    }
}
