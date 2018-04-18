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
            BackupSystem.BackupManager.GenerateBackup();
            CMessageBox.ShowDialog(Messages.SuccessSaving);
        }

        public static List<EntryData> LoadEntries()
        {
            LoadedFlag = false;
            IOManager.ProgressCompletedEvent += ProgressCompletedHandler;
            Task.Run(() => LoadedData = IOManager.ReadPasswords());
            while (!LoadedFlag)
                Thread.Sleep(5);
            return LoadedData;
        }

        private static void ProgressCompletedHandler()
        {
            LoadedFlag = true;
            IOManager.ProgressCompletedEvent -= ProgressCompletedHandler;
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