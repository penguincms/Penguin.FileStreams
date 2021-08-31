using System;

namespace Penguin.FileStreams.Interfaces
{
    public interface IFileWriter : IDisposable
    {
        void Flush();

        void Write(string s);

        void WriteLine(string s);

        string FullName { get; }
    }
}