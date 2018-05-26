using System.IO;

namespace PasswordManager.Engine.Archive
{
    public class ArchiveReader
    {
        private int entryCount;
        public int EntryCount => entryCount;
        private EncodingStream InputStream;

        public ArchiveReader(Stream _inputStream)
        {
            InputStream = new EncodingStream(_inputStream);
            entryCount = InputStream.ReadHeader();
        }

        public EntryData ParseEntry()
        {
            EntryData ReadEntry = new EntryData();
            ReadEntry.Name = InputStream.ReadNextString();
            ReadEntry.Username = InputStream.ReadNextString();
            ReadEntry.Comment = InputStream.ReadNextString();
            ReadEntry.Url = InputStream.ReadNextString();
            ReadEntry.Password = InputStream.ReadNextString();
            return ReadEntry;
        }

        public bool TryClose() => InputStream.TryClose();
    }
}