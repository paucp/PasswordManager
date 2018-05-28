using PasswordManager.Engine.Passwords;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class NewPasswordForm : Form
    {
        private bool PasswordSet = false;

        public NewPasswordForm()
        {
            SafePasswordChecker.LoadPasswords();
            InitializeComponent();
            panel1.BackColor = Settings.ColorAccent;
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Environment.Exit(0);

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBoxPassword1.Text != "" && textBoxPassword1.Text == textBoxPassword2.Text)
            {
                if (SafePasswordChecker.IsUsedPassword(textBoxPassword1.Text) || textBoxPassword1.Text.Length < Settings.MinPasswordLength)
                {
                    CMessageBox.ShowDialog("This password is not safe and can't be used (Minimum 12 characters, top 100.000 used passwords not allowed)", "Error");
                    return;
                }
                SafePasswordChecker.ReleasePasswords();
                label1.Text = "Password: Setting ...";
                textBoxPassword1.Enabled = false;
                textBoxPassword2.Enabled = false;
                buttonCancel.Enabled = false;
                buttonSet.Enabled = false;
                new Task(SetPasswordTask).Start();
            }
            else
                CMessageBox.ShowDialog("Paswords do not match", "Error");
        }

        private void SetPasswordTask()
        {
            UserDataIOManager.SaveSession(textBoxPassword1.Text);
            PasswordSet = true;
            Invoke((MethodInvoker)delegate
            {
                CMessageBox.ShowDialog("Password set");
                Close();
            });
        }

        private void NewPasswordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PasswordSet) Environment.Exit(0);
        }
    }
}