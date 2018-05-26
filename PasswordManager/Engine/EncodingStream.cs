using System;
using System.IO;
using System.Text;

namespace PasswordManager.Engine
{
    public class EncodingStream
    {
        private byte[] Buffer;
        private Stream Stream;

        public EncodingStream(byte[] data)
        {
            Stream = new MemoryStream(data);
        }

        public EncodingStream()
        {
            Stream = new MemoryStream();
        }

        public EncodingStream(Stream stream)
        {
            Stream = stream;
        }

        public void Close()
        {
            if (Stream.CanRead && Stream.CanSeek)
            {
                MemoryStream ms = new MemoryStream();
                Stream.Position = 0;
                Stream.CopyTo(ms);
                Buffer = ms.ToArray();
            }
            Stream.Close();
        }

        public byte[] GetData() => Buffer;

        public int ReadHeader()
        {
            byte[] Header = new byte[4];
            Stream.Read(Header, 0, 4);
            return BitConverter.ToInt32(Header, 0);
        }

        public byte[] ReadNextEntry()
        {
            int Length = ReadHeader();
            return ReadValue(Length);
        }

        public string ReadNextString() => Encoding.UTF8.GetString(ReadNextEntry());

        public bool TryClose()
        {
            try
            {
                Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void WriteEntry(byte[] Value)
        {
            WriteHeader(Value.Length);
            Write(Value);
        }

        public void WriteHeader(int Value)
          => Write(BitConverter.GetBytes(Value));

        public void WriteString(string str)
        {
            if (string.IsNullOrEmpty(str)) WriteHeader(0);
            else WriteEntry(Encoding.UTF8.GetBytes(str));
        }

        private byte[] ReadValue(int Length)
        {
            byte[] Value = new byte[Length];
            Stream.Read(Value, 0, Length);
            return Value;
        }

        private void Write(byte[] Value)
            => Stream.Write(Value, 0, Value.Length);
    }
}