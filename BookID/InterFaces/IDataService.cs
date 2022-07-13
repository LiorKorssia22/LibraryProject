using System;
using System.Collections.Generic;
using static BookLIB.Book;
using static BookLIB.Journal;

namespace BookLIB.InterFaces
{
    public interface IDataService
    {
        event Action<List<AbstractItem>> RefrashEvent;
        event Action MessageBoxAdd;
        event Action MessageIfNotFilter;

        bool FulList();
        List<AbstractItem> Filter(string name, string author, long isbn, double price, bool checkname, bool checkauther, bool checkisbn, bool checkprice);
        bool EditItems(ref AbstractItem item, string name, string author, long isbm, double price, int copies, DateTime dateprint, double discount, int instock, CatgoryType catgory, CatgoryTypeJornal catgoryjournal
         , bool checkEditname, bool checkEditauther, bool checkEditisbn, bool checkEditprice, bool checkcopies, bool checkdateprint, bool checkdiscount, bool checkinstock, bool checkcatgory, bool checkcatgoryjournal);
    }
}
