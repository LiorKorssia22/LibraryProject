using BookLIB.InterFaces;
using System;
using System.Collections;
using System.Collections.Generic;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB.Class
{
    public class ItemCollectionBook : IDataBook
    {
        public event Action<AbstractItem> AddBookEvent;
        public readonly Hashtable my_hashtable = ItemCollection.my_hashtable;
        public static readonly List<AbstractItem> Items = ItemCollection.Items;

        public event Action MessageBoxAdd;
        public event Action MessageBoxMiss;

        public bool AddBookToList(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price, double discount, int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(authername) || isbn <= 0 || dateprint > DateTime.Now || copynumber <= 0 || price <= 0 || discount <= 0 || unitinstock <= 0 || catgory == default)
            {
                MessageBoxMiss?.Invoke();
                return false;
            }
            var book = new Book(name, authername, isbn, dateprint, copynumber, price, discount, unitinstock, catgory, catgoryjournal);
            try
            {
                my_hashtable.Add(isbn, book);
                Items.Add(book);
                AddBookEvent?.Invoke(book);
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
