using System;
using System.IO;
using System.Text;

namespace MyProject
{
    public class FileService : IWriter
    {
        private StreamWriter _streamWriter;
        private StringBuilder _buffer;
        private DateTime _dateTime;

        public FileService(string path = @"D:\LogProgram\")
        {
            _buffer = new StringBuilder();
            _dateTime = DateTime.Now;

            DirePath = path;
            CreateDirectory();
            DeleteOldFiles();

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
                throw new Exception("Не удалось создать файл!", ex);
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
            DirectoryInfo dirInfo = new DirectoryInfo(DirePath);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }

        private void DeleteOldFiles()
        {
            string[] files = Directory.GetFiles(DirePath);

            var filesCount = files.Length;

            while (filesCount > 2)
            {
                FileInfo oldestFile = new FileInfo(files[0]);

                foreach (var file in files)
                {
                    var temp = new FileInfo(file);

                    if (temp.CreationTime < oldestFile.CreationTime)
                    {
                        oldestFile = temp;
                    }
                }

                oldestFile.Delete();
                filesCount--;
            }
        }
    }
}
