using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookJournalInfo
    {
        public string BookJournal { get; set; }


        public long ISBN { get; set; }
        public string AutherName { get; set; }

        public DateTime DatePrint { get; set; }
        public int CopyNumber { get; set; }
        public string Topic { get; set; }

        public CatgoryType Catgory;

        public enum CatgoryType
        {
            Action = 0b0001,
            romantic = 0b0010,
            comedy = 0b0011,
            Fictional = 0b0100,
            news = 0b0101,

        }
        public string Kind { get; set; }
    }
}
