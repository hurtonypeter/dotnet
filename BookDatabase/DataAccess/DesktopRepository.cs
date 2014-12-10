using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Entities;
using BookDatabase.Service;

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
                    return db.Books.OfType<PaperBook>()
                        .Include(b => b.Copies.Select(c => c.BookStateEntries))
                        //.Include(b => b.Copies)
                        //.Include(b => b.Copies.Select(s => s.BookStateEntries))
                        .SingleOrDefault(b => b.Id == id);
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

        public ResponseBase LendBook(string bookId, string memberId)
        {
            var response = new ResponseBase();
            using (var db = new BookContext())
            {
                var book = db.BookItems.Include(b => b.BookStateEntries).SingleOrDefault(b => b.Barcode == bookId);
                var member = db.Members.SingleOrDefault(b => b.Barcode == memberId);

                if(book == null || member == null)
                {
                    response.ErrorMessage = "Nincs ilyen könyv vagy tag.";
                    response.Error = true;
                    return response;
                }

                if(book.CurrentState == BookStates.Rent || 
                    book.CurrentState == BookStates.Expired)
                {
                    response.ErrorMessage = "A megadott könyv nem szabad.";
                    response.Error = true;
                    return response;
                }

                var status = new BookStateEntry
                {
                    Date = DateTime.Now,
                    BookItem = book,
                    Member = member,
                    Type = BookStateEntryType.Borrow
                };

                try
                {
                    db.BookStateEntries.Add(status);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    response.ErrorMessage = e.Message;
                    response.Error = true;
                }
            }
            return response;
        }


        public ResponseBase BackBook(string bookId, string memberId)
        {
            var response = new ResponseBase();
            using (var db = new BookContext())
            {
                var book = db.BookItems.Include(b => b.BookStateEntries).SingleOrDefault(b => b.Barcode == bookId);
                var member = db.Members.SingleOrDefault(b => b.Barcode == memberId);

                if (book == null || member == null)
                {
                    response.ErrorMessage = "Nincs ilyen könyv vagy tag.";
                    response.Error = true;
                    return response;
                }

                if (book.CurrentState == BookStates.Free )
                {
                    response.ErrorMessage = "A megadott könyv a könyvtárban van.";
                    response.Error = true;
                    return response;
                }

                var status = new BookStateEntry
                {
                    Date = DateTime.Now,
                    BookItem = book,
                    Member = member,
                    Type = BookStateEntryType.Back
                };

                try
                {
                    db.BookStateEntries.Add(status);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    response.ErrorMessage = e.Message;
                    response.Error = true;
                }
            }
            return response;
        }


        public List<Member> SearchMember(string searchKey)
        {
            string key = searchKey.ToLower();
            using (var db = new BookContext())
            {
                return db.Members.Where(m => m.Barcode.ToLower().Contains(key) ||
                    m.Name.ToLower().Contains(key)).ToList();
            }
        }

        public SaveMemberResponse SaveMember(Member member)
        {
            var response = new SaveMemberResponse();

            return response;
        }
    }
}
