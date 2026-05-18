using System;
using System.IO;

namespace Disposable_Demo
{
    class FileManager : IDisposable
    {
        private FileStream _file;
        private bool _disposed = false;

        public FileManager(string path)
        {
            _file = new FileStream(path, FileMode.OpenOrCreate);
            Console.WriteLine("File opened");
        }

        public void Write(string text)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            _file.Write(data, 0, data.Length);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _file?.Close();
                    _file?.Dispose();
                    Console.WriteLine("File cleaned");
                }

                _disposed = true;
            }
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }

    class Program
    {
        static void Main()
        {
            using (FileManager fm = new FileManager("test.txt"))
            {
                fm.Write("Hello GC + Dispose");
            }

            Console.WriteLine("Program finished");
        }
    }
}