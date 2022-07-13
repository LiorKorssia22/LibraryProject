using BookLIB.InterFaces;
using System;
using System.Collections;
using System.Collections.Generic;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB.Class
{
    public class ItemCollectionJournal : IDataJournal
    {
        public event Action MessageBoxAdd;
        public event Action<AbstractItem> AddJournalEvent;
        public event Action MessageBoxMiss;

        public readonly Hashtable my_hashtable = ItemCollection.my_hashtable;
        public static readonly List<AbstractItem> Items = ItemCollection.Items;

        public bool AddJournalToList(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price, double discount, int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(authername) || isbn <= 0 || dateprint > DateTime.Now || copynumber < 0 || price <= 0 || discount <= 0 || unitinstock <= 0 || catgoryjournal == default)
            {
                MessageBoxMiss?.Invoke();
                return false;
            }
            var journal = new Journal(name, authername, isbn, dateprint, copynumber, price, discount, unitinstock, catgory, catgoryjournal);
            try
            {
                my_hashtable.Add(isbn, journal);
                Items.Add(journal);
                AddJournalEvent?.Invoke(journal);
                return true;

            }
            catch (Exception)
            {
                MessageBoxAdd?.Invoke();
                return false;
            }
        }
    }
}
