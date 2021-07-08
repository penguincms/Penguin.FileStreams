namespace Penguin.FileStreams
{
    /// <summary>
    /// Compression method for FileStreams
    /// </summary>
    public enum FileStreamCompression
    {
        /// <summary>
        /// Files are written as plain text
        /// </summary>
        None,

        /// <summary>
        /// Files are wrapped in a Gzip stream
        /// </summary>
        Gzip,

        /// <summary>
        /// Files are written directly into a Zip stream, which is closed on dispose
        /// </summary>
        Zip
    }
}