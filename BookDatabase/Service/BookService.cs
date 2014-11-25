using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Entities;
using BookDatabase.DataAccess;

namespace BookDatabase.Service
{
    public class BookService : IBookService
    {
        //private IRepository db = new DesktopRepository();

        private IRepository db;

        public BookService(IRepository repo)
        {
            db = repo;
        }

        public List<Book> GetAllBook()
        {
            return db.GetAllBook();
        }
        public List<PaperBook> GetAllPaperBook()
        {
            return db.GetAllPaperBook();
        }

        public List<EBook> GetAllEBook()
        {
            return db.GetAllEBook();
        }

        public Book GetBookById(int id)
        {
            return db.GetBookById(id);
        }

        public void SaveBook(Book book)
        {
            db.SaveBook(book);
        }

        public List<Book> SearchBook(string key)
        {
            return db.SearchBook(key);
        }
    }
}
