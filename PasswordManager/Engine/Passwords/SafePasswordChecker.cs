using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager.Engine.Passwords
{
    public class SafePasswordChecker
    {
        private static List<string> passwordList = new List<string>();

        public static void LoadPasswords()        
            => passwordList.AddRange(File.ReadAllLines((Settings.PasswordListFilePath)));                   

        public static void ReleasePasswords()
        {
            passwordList.Clear();
            GC.Collect();
        }
        public static bool IsUsedPassword(string password)
             => passwordList.Contains(password);
    }
}