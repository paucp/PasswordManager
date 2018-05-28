namespace PasswordManager.Engine.Crypto
{
    public class CryptoRNGData
    {
        public byte[] Salt { get; }
        public byte[] IV { get; }

        public CryptoRNGData(byte[] saltbytes, byte[] ivbytes)
        {
            Salt = saltbytes;
            IV = ivbytes;
        }
    }
}