using PasswordManager.Engine.Passwords;
using System;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class EntryForm : Form
    {
        public EntryData Entry;
        public bool EntryCreatedOrEdited = false;

        public EntryForm()
        {
            InitializeComponent();
            panel2.BackColor = Settings.ColorAccent;
            this.Opacity = 0;
            Animation.FadeIn(this);
        }

        public void ShowData(EntryData data)
        {
            textBoxName.Text = data.Name;
            textBoxComment.Text = data.Comment;
            textBoxPassword.Text = data.Password;
            textBoxPWRepeat.Text = data.Password;
            textBoxUser.Text = data.Username;
            textBoxURL.Text = data.Url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Password = PasswordGenerator.GeneratePassword((int)numericUpDown1.Value);
            textBoxPassword.Text = Password;
            textBoxPWRepeat.Text = Password;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "" || textBoxName.Text == "" || textBoxPWRepeat.Text == "")
                CMessageBox.ShowDialog(Messages.EmptyTextBox);
            else if (textBoxPassword.Text != textBoxPWRepeat.Text)
                CMessageBox.ShowDialog(Messages.PasswordDontMatch);
            else
            {
                Entry.Name = textBoxName.Text;
                Entry.Password = textBoxPWRepeat.Text;
                Entry.Username = textBoxUser.Text;
                Entry.Comment = textBoxComment.Text;
                Entry.Url = textBoxURL.Text;
                EntryCreatedOrEdited = true;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) => Close();

        private void checkBoxShowPasswords_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBoxShowPasswords.Checked;
            textBoxPWRepeat.UseSystemPasswordChar = !checkBoxShowPasswords.Checked;
        }
    }
}