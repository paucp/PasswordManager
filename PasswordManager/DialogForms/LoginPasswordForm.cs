using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class CheckPasswordForm : Form
    {
        public CheckPasswordForm()
        {
            InitializeComponent();
            Opacity = 0;
            panel1.BackColor = Settings.ColorAccent;
            LoggedIn = false;
        }

        public bool LoggedIn { get; set; }

        private void buttonCleanup_Click(object sender, EventArgs e)
        {
            if (CMessageBox.ShowDialog(Messages.CleanupCheck))
                UserDataIOManager.DeleteAllUserData();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "") return;
            new Task(() => CheckPassword(textBoxPassword.Text)).Start();
            label1.Text = "Password: Checking . . .";
        }  

        private void CheckPassword(string Password)
        {
            LockUI(false);
            if (Password.Length < Settings.MinPasswordLength || !UserDataIOManager.IsPasswordCorrect(Password))
            {
                ShowErrorMessage();
                LockUI(true);
            }
            else
            {
                UserDataIOManager.SetSessionKey(Password);
                LoggedIn = true;
                Invoke((MethodInvoker)delegate
                {
                    Dispose();
                });
            }
        }

        private void CheckPasswordForm_Shown(object sender, EventArgs e)
                                            => Animation.FadeIn(this);

        private void LockUI(bool flag)
        {
            Invoke((MethodInvoker)delegate
            {
                foreach (Control c in this.Controls)
                    c.Enabled = flag;
            });
        }

        private void ShowErrorMessage()
        {
            Invoke((MethodInvoker)delegate
            {
                CMessageBox.ShowDialog(Messages.WrongPassword);
                label1.Text = "Password:";
            });
        }
    }
}