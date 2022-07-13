using System;
using static BookLIB.Book;

namespace BookLIB
{
    public class Journal : AbstractItem
    {
        public Journal(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price, double discount, int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal)
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
            CatgoryJournal = catgoryjournal;
            Catgory = 0;
        }

        [Flags]
        public enum CatgoryTypeJornal
        {
            Newspaper = 64,
            magazine = 128,
            Artistic = 256,
            Food = 512,
            Travel = 1024,
        }
    }
}
