using PasswordManager.Engine.Crypto;
using System;
using System.IO;

namespace PasswordManager
{
    public static class UserDataIOManager
    {
        public static bool LoginDataExists => File.Exists(Settings.CryptoRNGPath) && File.Exists(Settings.HashPath);

        public static void DeleteAllUserData()
        {
            File.Delete(Settings.ArchivePath);
            File.Delete(Settings.CryptoRNGPath);
            File.Delete(Settings.HashPath);
            Environment.Exit(0);
        }

        public static void GenerateNewCryptoRNGAndSave()
        {
            CurrentSession.SetCryptoRNGData(LoginDataManager.GenerateCryptoRNGLoginData());
            SaveCryptoRNGData();
        }

        public static void GenerateNewSessionAndSave(string MasterKey)
        {
            GenerateNewCryptoRNGAndSave();
            SaveSession(MasterKey);
        }

        public static bool IsPasswordCorrect(string MasterKey)
            => LoginDataManager.CheckPassword(MasterKey, File.ReadAllBytes(Settings.HashPath));

        public static void LoadCryptoRNGData()
        {
            byte[] FileBuffer = File.ReadAllBytes(Settings.CryptoRNGPath);
            CurrentSession.SetCryptoRNGData(LoginDataManager.DecodeCryptoRNGData(FileBuffer));
        }
        public static void SaveSession(string MasterKey)
        {
            SetSessionKey(MasterKey);
            SaveHash();
        }

        public static void SetSessionKey(string MasterKey)
                   => CurrentSession.SetMasterKey(MasterKey);
        private static void SaveCryptoRNGData()
            => File.WriteAllBytes(Settings.CryptoRNGPath, LoginDataManager.EncodeCryptoRNGData(CurrentSession.SessionLoginData));

        private static void SaveHash()
            => File.WriteAllBytes(Settings.HashPath, CurrentSession.MasterKeyHash);
    }
}