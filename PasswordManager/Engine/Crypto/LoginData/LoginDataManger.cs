using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Engine.Crypto
{   
    public class LoginDataManager
    {
        public static LoginData GenerateNewLoginData()
        {
            RNGCryptoServiceProvider CSP = new  RNGCryptoServiceProvider();          
            byte[] Salt = new byte[Settings.SaltSize];
            byte[] IV = new byte[Settings.IVSize];            
            CSP.GetBytes(Salt);
            CSP.GetBytes(IV);
            return new LoginData(null, null, null, Salt, IV);
        }            
        public static void SetSessionMasterKey(string MasterKeyString)
        {
            byte[] MasterKey = Encoding.UTF8.GetBytes(MasterKeyString);
            byte[] DerivedKey = DeriveMasterKey(MasterKeyString);
            byte[] Hash = SHA3512(MasterKey);
            CurrentSession.SessionLoginData.SetKeys(MasterKey, Hash, DerivedKey);
        }
        public static byte[] DeriveMasterKey(string MasterKey)
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(MasterKey, CurrentSession.SessionLoginData.Salt, Settings.AESPBKDF2Iterations);
            return pdb.GetBytes(Settings.DerivationSize);
        }
        /// <summary>
        /// Compare if the passwords match
        /// </summary>   
        public static bool CheckPassword(string MasterKeyCandidate) 
            =>  SlowEquals(SHA3512(Encoding.UTF8.GetBytes(MasterKeyCandidate)), CurrentSession.SessionLoginData.MasterHash);        
                
        /// <summary>
        /// Return the decoded login data
        /// </summary>      
        public static LoginData DecodeLoginData(byte[] buffer)
        {            
            Stream MemStream = new MemoryStream(buffer);
            int HashLength = ReadNextHeader(MemStream);
            int SaltLenght = ReadNextHeader(MemStream);
            int IVLength = ReadNextHeader(MemStream);
            byte[] MasterKeyHash = ReadNextValue(HashLength, MemStream);
            byte[] Salt = ReadNextValue(SaltLenght, MemStream);
            byte[] IV = ReadNextValue(IVLength, MemStream);
            return new LoginData(MasterKeyHash, Salt, IV);
        }
        /// <summary>
        /// Return the encoded login data
        /// </summary>    
        public static byte[] EncodeLoginData(LoginData Data)
        {
            int length = 12 + Data.MasterHash.Length + Data.Salt.Length + Data.IV.Length;
            byte[] EncodedData = new byte[length];
            MemoryStream MemStream = new MemoryStream(EncodedData);
            WriteHeader(Data.MasterHash.Length, MemStream);
            WriteHeader(Data.Salt.Length, MemStream);
            WriteHeader(Data.IV.Length, MemStream);

            WriteData(Data.MasterHash, MemStream);
            WriteData(Data.Salt, MemStream);            
            WriteData(Data.IV, MemStream);
            MemStream.Close();
            return MemStream.ToArray();
        }

        private static int ReadNextHeader(Stream Stream)
        {
            byte[] Header = new byte[4];
            Stream.Read(Header, 0, 4);
            return BitConverter.ToInt32(Header, 0);
        }

        private static byte[] ReadNextValue(int Length, Stream Stream)
        {
            byte[] Value = new byte[Length];
            Stream.Read(Value, 0, Length);
            return Value;
        }
        private static void WriteHeader(int Value, Stream Stream)
          => WriteData(BitConverter.GetBytes(Value), Stream);

        private static void WriteData(byte[] Value, Stream Stream)
            => Stream.Write(Value, 0, Value.Length);

        private static byte[] SHA3512(byte[] Buffer) => SHA3.Create().ComputeHash(Buffer);

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}