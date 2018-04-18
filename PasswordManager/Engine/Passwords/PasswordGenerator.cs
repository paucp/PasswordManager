using System;
using System.IO;
using System.Text;

namespace PasswordManager.Engine.Passwords
{
    public class PasswordGenerator
    {
        private static char[] Charmap = new char[] { };
        private static Random RNG = new Random();

        public static string GeneratePassword(int length = 32)
        {
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                sb.Append(GetRandomChar());
            return sb.ToString();
        }

        private static char GetRandomChar()
        {
            if (Charmap.Length == 0) LoadChars();
            return Charmap[RNG.Next(0, Charmap.Length)];
        }

        private static void LoadChars()
            => Charmap = File.ReadAllText(Settings.Charmap).ToCharArray();
    }
}