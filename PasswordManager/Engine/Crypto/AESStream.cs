using System.IO;
using System.Security.Cryptography;

namespace PasswordManager.Engine.Crypto
{
    public class AESStream
    {
        /// <summary>
        /// Crate a AES encryption stream based on current session data
        /// </summary>
        public static CryptoStream CtrEncryptionStreamCurrentSession(Stream BaseStream)
            => CreateEncryptionStream(BaseStream);

        /// <summary>
        /// Crate a AES decryption stream based on current session data
        /// </summary>
        public static CryptoStream CtrDecryptionStreamCurrentSession(Stream BaseStream)
             => CreateDecryptionStream(BaseStream);

        private static CryptoStream CreateEncryptionStream(Stream BaseStream)
           => new CryptoStream(BaseStream, CreateAES().CreateEncryptor(), CryptoStreamMode.Write);

        private static CryptoStream CreateDecryptionStream(Stream BaseStream)
            => new CryptoStream(BaseStream, CreateAES().CreateDecryptor(), CryptoStreamMode.Read);      

        private static RijndaelManaged CreateAES()
        {
            RijndaelManaged AES = new RijndaelManaged();
            AES.KeySize = Settings.AESKeySize;
            AES.BlockSize = Settings.AESBlockSize;
            AES.Key = CurrentSession.DerivedMasterKey;
            AES.IV = CurrentSession.SessionLoginData.IV;
            AES.Mode = CipherMode.CBC;
            return AES;
        }
       
    }
}