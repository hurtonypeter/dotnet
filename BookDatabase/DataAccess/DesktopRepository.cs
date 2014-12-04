using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Entities;

namespace BookDatabase.DataAccess
{
    public class DesktopRepository : IRepository
    {
        public List<Book> GetAllBook()
        {
            using (var db = new BookContext())
            {
                return db.Books.ToList();
            }
        }
        public List<PaperBook> GetAllPaperBook()
        {
            using (var db = new BookContext())
            {
                return db.Books.OfType<PaperBook>().ToList();
            }
        }

        public List<EBook> GetAllEBook()
        {
            using (var db = new BookContext())
            {
                return db.Books.OfType<EBook>().ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var db = new BookContext())
            {
                var book = db.Books.SingleOrDefault(b => b.Id == id);
                if(book.GetType() == typeof(PaperBook))
                {
                    return db.Books.OfType<PaperBook>().Include(b => b.Copies).SingleOrDefault(b => b.Id == id);
                }
                return book;
            }
        }

        public void SaveBook(Book book)
        {
            using (var db = new BookContext())
            {
                if (book.Id == 0)
                {
                    db.Books.Add(book);
                }
                else
                {
                    db.Entry<Book>(book).CurrentValues.SetValues(book);
                }
                db.SaveChanges();
            }
        }

        public List<Book> SearchBook(string searchKey)
        {
            var key = searchKey.ToLower();
            using (var db = new BookContext())
            {
                var result = (from b in db.Books.Include(p => p.Category).Include(p => p.Writer)
                              where b.ISBN.ToLower().Contains(key) || b.Title.ToLower().Contains(key) || b.OriginalTitle.ToLower().Contains(key)
                              select b).ToList();
                return result;
            }
        }
    }
}
