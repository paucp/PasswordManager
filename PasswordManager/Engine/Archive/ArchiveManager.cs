using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.Engine.Archive
{
    public static class ArchiveManager
    {
        private static ArchiveIOManager IOManager = new ArchiveIOManager(HandleException);
        private static List<EntryData> LoadedData;
        private static bool LoadedFlag;

        public static void WriteEntries(List<EntryData> entries)
        {           
            IOManager.WriteArchive(entries);
            CMessageBox.ShowDialog(Messages.SuccessSaving);
        }

        public static List<EntryData> LoadEntries()
        {
            LoadedFlag = false;
            IOManager.ProgressCompletedEvent += LoadingCompletedHandler;
            Task.Run(() => LoadedData = IOManager.ReadPasswords());
            while (!LoadedFlag)
                Thread.Sleep(10);
            return LoadedData;
        }

        private static void LoadingCompletedHandler()
        {
            LoadedFlag = true;
            IOManager.ProgressCompletedEvent -= LoadingCompletedHandler;
        }

        private static void HandleException(Exception ex)
        {
            CMessageBox.ShowDialog(ex.Message, "Critical Error");
            CMessageBox.ShowDialog(Messages.CorruptedData);
            IOManager.ExceptionThrownEvent -= HandleException;
            Application.Restart();
        }
    }
}