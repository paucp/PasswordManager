namespace PasswordManager
{
    public struct Message
    {
        public string Text { get;  }
        public string Title { get; }
        public bool CancelButton { get; }
        public Message(string text, string title = null, bool cancelButton = false)
        {
            Text = text;
            Title = title;
            CancelButton = cancelButton;
        }
    }
    public static class Messages
    {
        public static Message InstancesAlreadyRunning = new Message("There are other instances of the program running. Do you want to close them?", "Instance already running", true);
        public static Message EmptyTextBox = new Message("Necessary field is empty");
        public static Message PasswordDontMatch = new Message("Passwords don't match");
        public static Message WrongPassword = new Message("Introduced password is wrong", "Wrong password");
        public static Message CleanupCheck = new Message("All data will be removed, inculing saved entries and master password. Do you want to continue?", "Continue?", true);
        public static Message CopiedToClipboard = new Message("Copied to clipboard", "Copied");
        public static Message ChangesCheck = new Message("The changes aren't saved. Do you want to continue?", "Program closing", true);
        public static Message DeleteEntryCheck = new Message("The entry will be remain until next save. Do you want to continue?", "Continue?", true);
        public static Message DeleteEntriesCheck = new Message("The entries will be remain until next save. Do you want to continue?", "Continue?", true);
        public static Message NoBackup = new Message("There is not an available backup file", "Error");
        public static Message SuccessSaving = new Message("Data saved correctly");
        public static Message CorruptedData = new Message("The data may be corrupted, Restore the data using the backup function.", "Critical Error");
    }
}
