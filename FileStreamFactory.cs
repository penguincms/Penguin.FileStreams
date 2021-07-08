using Penguin.FileStreams.Interfaces;
using System;

namespace Penguin.FileStreams
{
    public static class FileWriterFactory
    {
        public static IFileWriter GetFileWriter(string filePath, FileStreamCompression compression)
        {
            switch (compression)
            {
                case FileStreamCompression.None:
                    return new FileWriter(filePath);
                case FileStreamCompression.Gzip:
                    return new GZipWriter(filePath);
                case FileStreamCompression.Zip:
                    return new ZipWriter(filePath);
                default:
                    throw new Exception($"Unhandled FileStreamCompression '{compression}'");
            }
        }
    }
}
