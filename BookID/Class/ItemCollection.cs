using BookLIB.InterFaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB.Class
{
    public class ItemCollection : IDataService
    {

        public static readonly List<AbstractItem> Items = new List<AbstractItem>();
        public static readonly Hashtable my_hashtable = new Hashtable();
        public event Action<List<AbstractItem>> RefrashEvent;
        public event Action MessageBoxAdd;
        public event Action MessageIfNotFilter;

        #region Indexer
        public AbstractItem this[string name] => Items.Single(item => item.Name == name);
        // public AbstractItem this[string author] => Items.Single(item => item.Auther == author);
        public AbstractItem this[long isbn] => Items.Single(item => item.ISBN == isbn);
        public AbstractItem this[int price] => Items.Single(item => item.Price == price);
        #endregion


        public List<AbstractItem> Filter(string name, string author, long isbn, double price, bool checkname, bool checkauther, bool checkisbn, bool checkprice)
        {
            List<AbstractItem> abstractItems = new List<AbstractItem>();
            bool checking = true;
            try
            {
                foreach (var item in Items)
                {
                    if (checkname == true)
                    {
                        if (!item.Name.ToUpper().Contains(name.ToUpper()))
                            checking = false;
                    }
                    if (checkauther == true)
                    {
                        if (!item.Auther.ToUpper().Contains(author.ToUpper()))
                            checking = false;
                    }
                    if (checkisbn == true)
                    {
                        if (!item.ISBN.ToString().Contains(isbn.ToString()))
                            checking = false;
                    }
                    if (checkprice == true)
                    {
                        if (!item.Price.ToString().Contains(price.ToString()))
                            checking = false;
                    }
                    if (checking)
                    {
                        abstractItems.Add(item);
                    }
                    checking = true;
                }
            }
            catch (Exception)
            {
                MessageIfNotFilter?.Invoke();
            }

            RefrashEvent?.Invoke(abstractItems);
            return abstractItems;
        }

        public bool FulList()
        {
            RefrashEvent?.Invoke(Items);
            return true;
        }

        public bool EditItems(ref AbstractItem item, string name, string author, long isbm, double price, int copies, DateTime dateprint, double discount, int instock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal
            , bool checkEditname, bool checkEditauther, bool checkEditisbn, bool checkEditprice, bool checkcopies, bool checkdateprint
            , bool checkdiscount, bool checkinstock, bool checkcatgory, bool checkcatgoryjournal)
        {
            try
            {
                if (item != null)
                {
                    if (checkEditname) item.Name = name;
                    if (checkEditauther) item.Auther = author;
                    if (checkEditisbn) item.ISBN = isbm;
                    if (checkEditprice) item.Price = price;
                    if (checkcopies) item.Copies = copies;
                    if (checkdateprint) item.DatePrint = dateprint;
                    if (checkdiscount) item.Discount = discount;
                    if (checkinstock) item.Stock = instock;
                    if (checkcatgory) item.Catgory = catgory;
                    if (checkcatgoryjournal) item.CatgoryJournal = catgoryjournal;
                }
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
