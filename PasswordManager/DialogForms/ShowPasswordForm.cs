using System;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class ShowPasswordForm : Form
    {
        public ShowPasswordForm()
        {
            InitializeComponent();
        }
        public void ShowPassword(string password)
        {
            labelPassword.Text = password;
            ShowDialog();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonCopy_Click(object sender, EventArgs e)
        {
            ClipboardManager.SetClipboardString(labelPassword.Text, this);
            CMessageBox.ShowDialog(Messages.CopiedToClipboard);
        }
    }
}
