using System.Windows.Forms;

namespace PasswordManager
{
    public class ClipboardManager
    {
        public static void SetClipboardString(string str, Form sender)
        {
            var oldData = Clipboard.GetDataObject();
            Clipboard.SetText(str);         
        }       
    }
}