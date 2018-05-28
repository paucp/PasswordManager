using System.Text;

namespace PasswordManager.Engine.Crypto
{
    public static class CurrentSession
    {
        public static byte[] MasterKey { get; private set; }
        public static byte[] MasterKeyHash => CryptoFunctions.SHA3512(MasterKey);
        public static byte[] DerivedMasterKey => CryptoFunctions.DeriveKey(MasterKey, SessionLoginData.Salt, Settings.DerivedSize);

        public static CryptoRNGData SessionLoginData { get; private set; }

        public static void SetCryptoRNGData(CryptoRNGData data)
            => SessionLoginData = data;

        public static void SetMasterKey(string keystr) => MasterKey = Encoding.UTF8.GetBytes(keystr);
    }
}