using System.Text;

namespace PasswordManager.Engine.Crypto
{
    public static class CurrentSession
    {
        public static byte[] MasterKey { get; private set; }
        public static byte[] MasterHash => CryptoFunctions.SHA3512(MasterKey);
        public static byte[] DerivedMasterKey => CryptoFunctions.DeriveKey(MasterKey, SessionLoginData.Salt, Settings.DerivedSize);
        public static LoginData SessionLoginData { get; private set; }   

        public static void SetLoginData(LoginData data)
            => SessionLoginData = data;

        public static void SetMasterKey(string keystr) => MasterKey = Encoding.UTF8.GetBytes(keystr);
    }
}