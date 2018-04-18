using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public class Animation
    {
        public static void FadeIn(Form sender, int interval = 10)
            => FadeIn(sender, null, interval);

        public static void FadeOut(Form sender, int interval = 10)
            => FadeOut(sender, null, interval);

        public static async void FadeIn(Form sender, Action action, int interval = 13)
        {
            sender.Opacity = 0;
            while (sender.Opacity < 1.0)
            {
                await Task.Delay(interval);
                sender.Opacity += 0.05;
            }
            action?.Invoke();
            sender.Opacity = 1;
        }

        public static async void FadeOut(Form sender, Action action, int interval = 13)
        {
            sender.Opacity = 1;
            while (sender.Opacity > 0)
            {
                await Task.Delay(interval);
                sender.Opacity -= 0.05;
            }
            action?.Invoke();
            sender.Opacity = 0;
        }
    }
}