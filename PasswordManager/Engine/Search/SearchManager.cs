using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.Engine.Search
{
    public class SearchManager
    {
        public bool CanSearchLastString =>
            LastSearchString != null;

        private List<EntryData> Entries;
        private int ElapsedTime = 0;
        private int LastSearchIndex = -1;
        private string LastSearchString;

        public SearchManager(ref List<EntryData> entries)
        {
            Entries = entries;
            Task.Run(() => AutoResetSearch());
        }

        public int SearchIndexWithLastString()
            => SearchIndex(LastSearchString);

        public int SearchIndex(string SearchText)
        {
            if (SearchText == null)
                return -1;
            SearchText = SearchText.ToLower();
            LastSearchIndex = Entries.FindIndex
                (LastSearchIndex + 1, x => SearchText.Contains(x.Name.ToLower())
                || x.Name.ToLower().Contains(SearchText));
            ElapsedTime = 0;
            LastSearchString = SearchText;
            return LastSearchIndex;
        }

        private void AutoResetSearch()
        {
            while (true)
            {
                Thread.Sleep(100);
                ElapsedTime += 100;
                if (ElapsedTime == 4000
                    && LastSearchIndex != -1)
                {
                    LastSearchIndex = -1;
                    LastSearchString = null;
                }
            }
        }
    }
}