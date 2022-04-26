using Penguin.FileStreams.Interfaces;
using System;
using System.IO;

namespace Penguin.FileStreams
{
    public class FileWriter : IFileWriter
    {
        private bool disposedValue;
        private readonly StreamWriter StreamWriter;
        public string FullName { get; private set; }
        public FileWriter(string fullFilePath)
        {
            this.FullName = new FileInfo(fullFilePath).FullName;
            this.StreamWriter = new StreamWriter(new FileStream(this.FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Flush() => this.StreamWriter.Flush();

        public void Write(string s) => this.StreamWriter.Write(s);

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LogStreamWriter()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
        public void WriteLine(string s) => this.StreamWriter.WriteLine(s);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.StreamWriter.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                this.disposedValue = true;
            }
        }
    }
}