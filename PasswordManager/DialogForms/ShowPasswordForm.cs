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
            panel1.BackColor = Settings.ColorAccent;
            this.Opacity = 0;

            Animation.FadeIn(this);
        }

        private int Max(int a, int b)
        {
            if (a > b) return a;
            else if (a < b) return b;
            else return b;
        }

        public void ShowPassword(EntryData entry)
        {
            Entry = entry;
            labelPassword.Text = Entry.Password;
            labelUser.Text = Entry.Username;
            labelURL.Text = Entry.Url;
            int MaxWidth = Max(Max(labelUser.Width, labelURL.Width), labelPassword.Width) + 180;
            this.Width = MaxWidth;
            ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
           => Close();

        private void SetClipboard(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                Clipboard.SetText(s);
                CMessageBox.ShowDialog(Messages.CopiedToClipboard);
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
            => SetClipboard(Entry.Password);

        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => SetClipboard(Entry.Username);

        private void linkLabelURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => SetClipboard(Entry.Url);

        private void ShowPasswordForm_Load(object sender, EventArgs e)
        {
        }
    }
}