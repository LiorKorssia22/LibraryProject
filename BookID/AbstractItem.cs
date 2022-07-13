using System;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB
{
    public abstract class AbstractItem //The Properties
    {
        public string Name { get; set; }
        public string Auther { get; set; }
        public long ISBN { get; set; }
        public DateTime DatePrint { get; set; }
        public int Copies { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
        public CatgoryType Catgory { get; set; }
        public CatgoryTypeJornal CatgoryJournal { get; set; }

        public AbstractItem(string name, string authername, long isbn, DateTime dateprint, int copynumber, double price
           , double discount, int unitinstock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal)
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
            CatgoryJournal = catgoryjournal;
        }
    }
}
