﻿using Penguin.FileStreams.Interfaces;
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

        public ZipWriter(string fullFileName)
        {
            this.Archive = new ZipArchive(new FileStream(fullFileName + ".zip", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite), ZipArchiveMode.Create, false);

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

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~LogZipWriter()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
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
                if (disposing)
                {
                    this.StreamWriter.Flush();
                    this.Archive.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                this.disposedValue = true;
            }
        }
    }
}