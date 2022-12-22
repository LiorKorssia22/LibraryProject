using BookLIB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace OOPFinalProject.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
    : base("data source=(localdb)\\mssqllocaldb;initial catalog=Library;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Journal> Journals { get; set; }


    }
}
