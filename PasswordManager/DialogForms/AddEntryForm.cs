using System;
using System.Windows.Forms;
using PasswordManager.Engine.Passwords;

namespace PasswordManager
{
    public partial class AddEntryForm : Form
    {
        public bool EntryCreatedOrEdited = false;
        public EntryData Entry;

        public AddEntryForm()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string Password = PasswordGenerator.GeneratePassword((int)numericUpDown1.Value);
            textBoxPassword.Text = Password;
            textBoxPWRepeat.Text = Password;
        }
    }
}