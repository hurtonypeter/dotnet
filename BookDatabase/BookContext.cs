using BookDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<BookItem> BookItems { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<BookStateEntry> BookStateEntries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Member> Members { get; set; }

        public BookContext(string connecton) { }

        public BookContext() : base("BookDB") 
        {
            Database.SetInitializer<BookContext>(new BookDatabaseInitializer());

            this.Configuration.LazyLoadingEnabled = false; //ne tudjon mindent felhúzni db-ből amikor a WCF szerializál
            this.Configuration.ProxyCreationEnabled = false; //ne generáljon proxy-t, különben elszáll a WCF
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
