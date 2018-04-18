using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager.Engine.Archive
{   

    public class ArchiveIOManager
    {
        public delegate void ProgressCompleted();
        public delegate void ExceptionThrown(Exception ex);

        public ProgressCompleted ProgressCompletedEvent;
        public ExceptionThrown ExceptionThrownEvent;

        public ArchiveIOManager(ExceptionThrown ExceptionHandler)
        {
            ExceptionThrownEvent += ExceptionHandler;
        }

        public void DeleteArchive() => File.Delete(Settings.ArchivePath);

        public void WriteArchive(List<EntryData> list)
            => WriteArchive(list, new FileStream(Settings.ArchivePath, FileMode.Create));

        public void WriteArchive(List<EntryData> EntryList, Stream BaseStream)
        {
            if (EntryList.Count == 0)
            {
                BaseStream.Close();
                DeleteArchive();
                return;
            }
            Stream CryptoStream = Crypto.AESStream.CtrEncryptionStreamCurrentSession(BaseStream);
            ArchiveWriter Writer = new ArchiveWriter(CryptoStream, EntryList.Count);
            try
            {
                for (int i = 0; i < EntryList.Count; i++)
                    Writer.WriteEntry(EntryList[i]);
            }
            catch (Exception ex)
            {
                ExceptionThrownEvent?.Invoke(ex);
            }
            finally
            {
                Writer.Close();
                GC.Collect();
                ProgressCompletedEvent?.Invoke();
            }
        }

        public List<EntryData> ReadPasswords()
        {
            if (File.Exists(Settings.ArchivePath))
                return ReadPasswords(new FileStream(Settings.ArchivePath, FileMode.Open));
            else
            {
                ProgressCompletedEvent?.Invoke();
                return null;
            }
        }

        public List<EntryData> ReadPasswords(Stream ReadingStream)
        {
            Stream CryptoStream = Crypto.AESStream.CtrDecryptionStreamCurrentSession(ReadingStream);
            ArchiveReader Reader = new ArchiveReader(CryptoStream);
            List<EntryData> EntryList = new List<EntryData>();
            try
            {
                if (Math.Abs(Reader.EntryCount) > 1024 * 1024)
                    new Exception("Max entries exceeded");
                for (int i = 0; i < Reader.EntryCount; i++)
                    EntryList.Add(Reader.ParseEntry());
            }
            catch (Exception ex)
            {
                ExceptionThrownEvent?.Invoke(ex);
            }
            finally
            {
                if (!Reader.TryClose())
                    ExceptionThrownEvent(new Exception("Error closing stream"));
                GC.Collect();
                ProgressCompletedEvent?.Invoke();
            }
            return EntryList;
        }
    }
}