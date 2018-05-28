using System;
using System.Windows.Forms;

namespace PasswordManager
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!UserDataIOManager.LoginDataExists)
                new NewPasswordForm().ShowDialog();
            else UserDataIOManager.LoadCryptoRNGData();
            CheckPasswordForm CheckPWForm = new CheckPasswordForm();
            CheckPWForm.ShowDialog();
            if (CheckPWForm.LoggedIn)
                Application.Run(new MainForm());
            else Environment.Exit(0);
        }
    }
}