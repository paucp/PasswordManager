using PasswordManager.Engine.Crypto;
using System;
using System.IO;

namespace PasswordManager
{
    public static class UserDataIOManager
    {
        public static bool LoginDataFileExists => File.Exists(Settings.LoginDataPath);

        public static void DeleteAllUserData()
        {          
            File.Delete(Settings.ArchivePath);
            File.Delete(Settings.LoginDataPath);
            Environment.Exit(0);
        }

        public static void GenerateNewSessionAndSave(string MasterKey)
        {
            CurrentSession.SetLoginData(LoginDataManager.GenerateNewLoginData());
            SetSessionKey(MasterKey);
            SaveCurrentSessionLoginData();
        }

        public static void SetSessionKey(string MasterKey)
           => LoginDataManager.SetSessionMasterKey(MasterKey);

        public static void LoadLoginData()
        {
            byte[] FileBuffer = File.ReadAllBytes(Settings.LoginDataPath);
            CurrentSession.SetLoginData(LoginDataManager.DecodeLoginData(FileBuffer));
        }

        public static bool IsPasswordCorrect(string MasterKey)
            => LoginDataManager.CheckPassword(MasterKey);

        private static void SaveCurrentSessionLoginData()
            => File.WriteAllBytes(Settings.LoginDataPath, LoginDataManager.EncodeLoginData(CurrentSession.SessionLoginData));
    }
}