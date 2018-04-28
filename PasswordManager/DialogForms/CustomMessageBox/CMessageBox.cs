using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordManager
{
    public enum CMEssageBoxResult
    {
        Accept = 0,
        Cancel = 1
    }

    public partial class CMessageBox : Form
    {
        public static bool ShowDialog(Message Message) => ShowDialog(Message.Text, Message.Title, Message.CancelButton);

        public static bool ShowDialog(string Text, string Title = null, bool ShowCancelButton = false)
         => new CMessageBox().ShowCDialog(Text, Title, ShowCancelButton) == CMEssageBoxResult.Accept;

        public CMEssageBoxResult Result = CMEssageBoxResult.Cancel;

        private const int minWidth = 315;
        private const int minHeight = 160;

        public CMessageBox()
        {
            InitializeComponent();
            Opacity = 0;
            labelTitle.Text = null;
            labelText.Text = null;
        }

        public CMEssageBoxResult ShowCDialog(string message, string Title, bool ShowCancelButton = false)
        {
            if (Title == null)
            {
                labelTitle.Text = message;
                Height = 120;
                buttonAccept.Location = new Point(buttonAccept.Location.X, buttonAccept.Location.Y - 40);
                buttonCancel.Location = new Point(buttonCancel.Location.X, buttonCancel.Location.Y - 40);
            }
            else
            {
                if (message.Length > Settings.CMessageBoxMaxLineLength)
                    message = SplitLargeString(message);
                labelText.Text = message;
                labelTitle.Text = Title;
            }

            if (labelText.Width > (minWidth - 50))
                Width = (labelText.Width + 100);
            buttonAccept.Location = new Point(Width - buttonAccept.Width - 30, buttonAccept.Location.Y);
            buttonCancel.Location = new Point(Width - buttonCancel.Width - buttonAccept.Width - 40, buttonAccept.Location.Y);
            if (!ShowCancelButton) buttonCancel.Dispose();
            ShowDialog();
            return Result;
        }

        private string SplitLargeString(string value)
        {
            string temp = value;
            int index = temp.IndexOf(" ", Settings.CMessageBoxMaxLineLength) + 1;
            temp = temp.Substring(0, index) + '\n' + temp.Substring(index, value.Length - index);
            return temp;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
            => Close();

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Result = CMEssageBoxResult.Accept;
            Close();
        }

        private void CMessageBox_Shown(object sender, EventArgs e) => Animation.FadeIn(this, 10);
    }
}