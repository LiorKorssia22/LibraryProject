using System;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB.InterFaces

{
    public interface IDataBook
    {
        event Action MessageBoxAdd;
        event Action MessageBoxMiss;

        bool AddBookToList(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price, double discount
           , int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal);
        event Action<AbstractItem> AddBookEvent;
    }
}