using BookLIB;
using System;
using System.Collections.ObjectModel;

namespace Services
{
    public interface IDataServiceBook
    {
        Book GetBook(string bookName);
        int CreateBook(Book bookInfo);


        event Action<Book> AddBookEvent;
        void AddBook(string bookName);
    }
}