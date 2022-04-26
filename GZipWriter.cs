using Penguin.FileStreams.Interfaces;
using System;
using System.IO;
using System.IO.Compression;

namespace Penguin.FileStreams
{
    public class GZipWriter : IFileWriter
    {
        private bool disposedValue;
        private readonly StreamWriter StreamWriter;
        public GZipStream Compress { get; }
        public FileStream OutFile { get; private set; }
        public string FullName { get; private set; }
        public GZipWriter(string fullFileName)
        {
            this.FullName = new FileInfo(fullFileName + ".gz").FullName;
            this.OutFile = File.Create(this.FullName);
            this.Compress = new GZipStream(this.OutFile, CompressionLevel.Optimal);
            this.StreamWriter = new StreamWriter(this.Compress);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LogGzipWriter()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
        public void Flush()
        {
            this.StreamWriter.Flush();
            this.Compress.Flush();
        }

        public void Write(string s) => this.StreamWriter.Write(s);

        public void WriteLine(string s) => this.StreamWriter.WriteLine(s);

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.StreamWriter.Flush();
                    this.StreamWriter.Close();
                    this.StreamWriter.Dispose();
                    this.Compress.Dispose();
                    this.OutFile.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                this.disposedValue = true;
            }
        }
    }
}