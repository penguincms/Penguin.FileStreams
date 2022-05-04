using Penguin.FileStreams.Interfaces;
using System;
using System.IO;
using System.IO.Compression;

namespace Penguin.FileStreams
{
    public class ZipWriter : IFileWriter
    {
        private readonly ZipArchive Archive;
        private readonly ZipArchiveEntry FileArchive;
        private readonly Stream FileStream;
        private readonly StreamWriter StreamWriter;
        private bool disposedValue;
        public string FullName { get; private set; }

        public ZipWriter(string fullFileName)
        {
            this.FullName = new FileInfo(fullFileName + ".zip").FullName;

            this.Archive = new ZipArchive(new FileStream(this.FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite), ZipArchiveMode.Create, false);

            this.FileArchive = this.Archive.CreateEntry(Path.GetFileName(fullFileName), CompressionLevel.Optimal);

            this.FileStream = this.FileArchive.Open();

            this.StreamWriter = new StreamWriter(this.FileStream);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Flush()
        {
            this.StreamWriter.Flush();
            this.FileStream.Flush();
        }

        public void Write(string s)
        {
            this.StreamWriter.Write(s);
        }

        public void WriteLine(string s)
        {
            this.StreamWriter.WriteLine(s);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                this.disposedValue = true;

                if (disposing)
                {
                    this.StreamWriter.Flush();
                    this.Archive.Dispose();
                }
            }
        }
    }
}