using System;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class ShowPasswordForm : Form
    {
        private EntryData Entry;
        public ShowPasswordForm()
        {
            InitializeComponent();
        }
        public void ShowPassword(EntryData entry)
        {
            Entry = entry;
            labelPassword.Text = Entry.Password;
            labelUser.Text = Entry.Username;
            labelURL.Text = Entry.Url;
            ShowDialog();
        }
        private void buttonClose_Click(object sender, EventArgs e)        
           => Close();
        private void SetClipboard(string s)
        {
            Clipboard.SetText(s);
            CMessageBox.ShowDialog(Messages.CopiedToClipboard);
        }
        private void buttonCopy_Click(object sender, EventArgs e)
            => SetClipboard(Entry.Password);
        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => SetClipboard(Entry.Username);

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => SetClipboard(Entry.Url);
       
    }
}
