using System.Text;

namespace PasswordManager.Engine.Crypto
{
    public class LoginDataManager
    {
        /// <summary>
        /// Compare if the passwords match
        /// </summary>
        public static bool CheckPassword(string MasterKeyCandidate, byte[] MasterKeyHash)
            => CryptoFunctions.SlowEquals(CryptoFunctions.SHA3512(Encoding.UTF8.GetBytes(MasterKeyCandidate)), MasterKeyHash);

        /// <summary>
        /// Return the decoded login data
        /// </summary>
        public static CryptoRNGData DecodeCryptoRNGData(byte[] buffer)
        {
            EncodingStream ec = new EncodingStream(buffer);
            byte[] Salt = ec.ReadNextEntry();
            byte[] IV = ec.ReadNextEntry();
            return new CryptoRNGData(Salt, IV);
        }

        /// <summary>
        /// Return the encoded login data
        /// </summary>
        public static byte[] EncodeCryptoRNGData(CryptoRNGData Data)
        {
            EncodingStream ec = new EncodingStream();
            ec.WriteEntry(Data.Salt);
            ec.WriteEntry(Data.IV);
            ec.Close();
            return ec.GetData();
        }

        public static CryptoRNGData GenerateCryptoRNGLoginData()
        {
            byte[] Salt = CryptoFunctions.GenerateCryptoSecureKey(Settings.SaltSize);
            byte[] IV = CryptoFunctions.GenerateCryptoSecureKey(Settings.IVSize);
            return new CryptoRNGData(Salt, IV);
        }
    }
}