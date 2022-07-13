using BookLIB;
using BookLIB.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        readonly ItemCollection itemCollection = new ItemCollection();
        readonly ItemCollectionBook itembook = new ItemCollectionBook();
        readonly ItemCollectionJournal itemjournal = new ItemCollectionJournal();

        readonly Book book = new Book("Lior", "Korssia", 209177442, DateTime.Parse("31/7/2021 12:00:00"), 56, 89, 30, 23, CatgoryType.comedy, 0);
        readonly Journal Journal = new Journal("Harry Poter", "JK Rolling", 123456789, DateTime.Parse("31/7/2012 12:00:00"), 45, 87, 40, 99, 0, CatgoryTypeJornal.magazine);

        [TestMethod]
        public void ChechAddBook()
        {
            Assert.IsTrue(itembook.AddBookToList(book.Name, book.Auther, book.ISBN, book.DatePrint, book.Copies, book.Price, book.Discount, book.Stock, book.Catgory, 0));
        }

        [TestMethod]
        public void ChechAddJournal()
        {
            Assert.IsTrue(itemjournal.AddJournalToList(Journal.Name, Journal.Auther, Journal.ISBN, Journal.DatePrint, Journal.Copies, Journal.Price, Journal.Discount, Journal.Stock, 0, Journal.CatgoryJournal));
        }

        [TestMethod]
        public void ChechFilter()
        {
            Assert.IsTrue(itemCollection.Filter("drive", "mountain", 112233, 10, true, false, true, false).GetType() == typeof(List<AbstractItem>));
        }

        [TestMethod]
        public void ChechEdit()
        {
            var Abstract = book as AbstractItem;
            Assert.IsTrue(itemCollection.EditItems(ref Abstract, "Harry Poter", "JK Rolling", 123456789, 87, 87, DateTime.Parse("31/7/2012 12:00:00"), 40, 99, 0, CatgoryTypeJornal.magazine,false, true, false, true, false, true, false, false, false, false));
        }

        [TestMethod]
        public void CheckAllCollection()
        {
            Assert.IsTrue(itemCollection.FulList());
        }
    }
}
