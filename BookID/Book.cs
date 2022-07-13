using System;
using static BookLIB.Journal;

namespace BookLIB
{
    public class Book : AbstractItem
    {
        public Book(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price, double discount, int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal)
            : base(name, authername, isbn, dateprint, copynumber, price, discount, unitinstock, catgory, catgoryjournal)
        {
            Name = name;
            Auther = authername;
            ISBN = isbn;
            DatePrint = dateprint;
            Copies = copynumber;
            Price = price;
            Discount = discount;
            Stock = unitinstock;
            Catgory = catgory;
            CatgoryJournal = 0;
        }


        [Flags]
        public enum CatgoryType
        {
            Action = 2,
            romantic = 4,
            comedy = 8,
            Fictional = 16,
            news = 32,
        }
    }
}
