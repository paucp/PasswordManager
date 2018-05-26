using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager
{
    public static class Settings
    {
        public const string CurrentVersion = "0.8";

        public static Color ColorAccent = Color.FromArgb(255, 63, 81, 181);
        public static Color SearchBoxFocusColor = Color.FromArgb(200, 96, 125, 170);

        public const string SearchIconText = "";
        public const int MinPasswordLength = 10;
        public const int CMessageBoxMaxLineLength = 50;
        public const int AESPBKDF2Iterations = 9182;

        public const int AESKeySize = 256;
        public const int AESBlockSize = 128;
        public const int DerivedSize = 32;
        public const int IVSize = 16;
        public const int SaltSize = 256;

        public static string DataFolderPath = Application.StartupPath + @"\Data\";
        public static string UserDataFolderPath = Application.StartupPath + @"\UserData\";

        public static string LoginDataPath = UserDataFolderPath + "login.pm";
        public static string ArchivePath = UserDataFolderPath + "archive.pm";
        public static string PasswordListFilePath = DataFolderPath + "list.spm";
        public static string Charmap = DataFolderPath + "charmap.src";
    }
}