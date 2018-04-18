using System;
using System.IO;
using System.Text;

namespace PasswordManager.Engine.Archive
{
    public class ArchiveWriter
    {
        private Stream OutputStream;

        public ArchiveWriter(Stream outputStream, int elements)
        {
            OutputStream = outputStream;
            WriteHeader(elements);
        }

        public void WriteEntry(EntryData Entry)
        {
            WriteString(Entry.Name);
            WriteString(Entry.Username);
            WriteString(Entry.Comment);
            WriteString(Entry.Url);
            WriteString(Entry.Password);
        }

        private void WriteString(string str)
        {
            if (str == null) WriteHeader(0);
            else
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                WriteHeader(buffer.Length);
                WriteBuffer(buffer);
            }
        }

        private void WriteHeader(int value)
         => WriteBuffer(BitConverter.GetBytes(value));

        private void WriteBuffer(byte[] buffer)
            => OutputStream.Write(buffer, 0, buffer.Length);

        public void Close() => OutputStream.Close();
    }
}