using System;
using System.IO;
using System.Text;

namespace PasswordManager.Engine.Archive
{
    public class ArchiveReader
    {
        private int entryCount;
        public int EntryCount => entryCount;
        private Stream InputStream;

        public ArchiveReader(Stream _inputStream)
        {
            InputStream = _inputStream;
            entryCount = ReadHeader();
        }

        public EntryData ParseEntry()
        {
            EntryData ReadEntry = new EntryData();
            ReadEntry.Name = ReadString();
            ReadEntry.Username = ReadString();
            ReadEntry.Comment = ReadString();
            ReadEntry.Url = ReadString();
            ReadEntry.Password = ReadString();
            return ReadEntry;
        }

        private string ReadString()
            => Encoding.UTF8.GetString(ReadBuffer(ReadHeader()));
    
        private int ReadHeader() => BitConverter.ToInt32(ReadBuffer(4), 0);

        private byte[] ReadBuffer(int size)
        {
            byte[] buffer = new byte[size];
            InputStream.Read(buffer, 0, size);
            return buffer;
        }

        public bool TryClose()
        {
            try
            {
                InputStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}