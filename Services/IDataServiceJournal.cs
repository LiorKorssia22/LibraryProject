using System;
using System.Collections.ObjectModel;

namespace Services
{
    public interface IDataServiceJournal
    {
        Journal GetJournal(string journalName);
        int CreateJournal(Journal journalInfo);


        event Action<Journal> AddJournalEvent;
        void AddJournal(string journalName);
    }
}