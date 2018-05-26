using System.IO;

namespace PasswordManager.Engine.Archive
{
    public class ArchiveWriter
    {
        private EncodingStream OutputStream;

        public ArchiveWriter(Stream outputStream, int entryCount)
        {
            OutputStream = new EncodingStream(outputStream);
            OutputStream.WriteHeader(entryCount);
        }

        public void WriteEntry(EntryData Entry)
        {
            OutputStream.WriteString(Entry.Name);
            OutputStream.WriteString(Entry.Username);
            OutputStream.WriteString(Entry.Comment);
            OutputStream.WriteString(Entry.Url);
            OutputStream.WriteString(Entry.Password);
        }

        public void Close() => OutputStream.Close();
    }
}