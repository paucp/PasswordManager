using System;
using System.IO;

namespace PasswordManager.Engine.Crypto
{
    public class EncodingStream
    {
        private MemoryStream Stream;

        public EncodingStream(byte[] data)
        {
            Stream = new MemoryStream(data);
        }

        public EncodingStream()
        {
            Stream = new MemoryStream();
        }

        public void Close() => Stream.Close();

        public byte[] GetData() => Stream.ToArray();

        public byte[] ReadNextEntry()
        {
            int Length = ReadHeader();
            return ReadValue(Length);
        }

        public void WriteEntry(byte[] Value)
        {
            WriteHeader(Value.Length);
            Write(Value);
        }

        private int ReadHeader()
        {
            byte[] Header = new byte[4];
            Stream.Read(Header, 0, 4);
            return BitConverter.ToInt32(Header, 0);
        }

        private byte[] ReadValue(int Length)
        {
            byte[] Value = new byte[Length];
            Stream.Read(Value, 0, Length);
            return Value;
        }

        private void WriteHeader(int Value)
          => Write(BitConverter.GetBytes(Value));

        private void Write(byte[] Value)
            => Stream.Write(Value, 0, Value.Length);
    }
}