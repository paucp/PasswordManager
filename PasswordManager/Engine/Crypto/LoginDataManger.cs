using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Engine.Crypto
{
    public class LoginDataManager
    {
        /// <summary>
        /// Compare if the passwords match
        /// </summary>
        public static bool CheckPassword(string MasterKeyCandidate)
            => Compare(SHA3512(Encoding.UTF8.GetBytes(MasterKeyCandidate)), CurrentSession.SessionLoginData.MasterHash);

        /// <summary>
        /// Return the decoded login data
        /// </summary>
        public static LoginData DecodeLoginData(byte[] buffer)
        {
            EncodingStream ec = new EncodingStream(buffer);
            byte[] MasterKeyHash = ec.ReadNextEntry();
            byte[] Salt = ec.ReadNextEntry();
            byte[] IV = ec.ReadNextEntry();
            return new LoginData(MasterKeyHash, Salt, IV);
        }

        /// <summary>
        /// Return the encoded login data
        /// </summary>
        public static byte[] EncodeLoginData(LoginData Data)
        {
            EncodingStream ec = new EncodingStream();
            ec.WriteEntry(CurrentSession.MasterHash);
            ec.WriteEntry(Data.Salt);
            ec.WriteEntry(Data.IV);
            ec.Close();
            return ec.GetData();
        }

        public static LoginData GenerateCryptoRNGLoginData()
        {
            byte[] Salt = CryptoFunctions.GenerateCryptoSecureKey(Settings.SaltSize);
            byte[] IV = CryptoFunctions.GenerateCryptoSecureKey(Settings.IVSize);
            return new LoginData(Salt, IV);
        }

        public static void SetSessionMasterKey(string MasterKeyString)
        {
            byte[] MasterKey = Encoding.UTF8.GetBytes(MasterKeyString);
           
            byte[] Hash = SHA3512(MasterKey);
            CurrentSession.SessionLoginData.SetKeys(MasterKey, Hash, DerivedKey);
        }     

        private static bool Compare(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        private static byte[] SHA3512(byte[] Buffer) => SHA3.Create().ComputeHash(Buffer);
    }
}