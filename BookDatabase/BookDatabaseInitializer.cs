using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Entities;

namespace BookDatabase
{
    public class BookDatabaseInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            base.Seed(context);

            var cat1 = new Category("Gyermek és ifjúsági regények");
            var cat2 = new Category("Krimi");
            var cat3 = new Category("Szépirodalom");

            var writer1 = new Writer
            {
                FirstName = "J. K.",
                LastName = "Rowling"
            };
            var writer2 = new Writer
            {
                FirstName = "Agatha",
                LastName = "Christie"
            };
            var writer3 = new Writer
            {
                FirstName = "István",
                LastName = "Örkény"
            };

            var books = new List<Book>
            {
                new PaperBook()
                {
                    ISBN = "123-321-123-2222",
                    Title = "Harry Potter és a Bölcsek Köve",
                    OriginalTitle = "Harry Potter and the Philosoper's Stone",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 }
                },
                new PaperBook()
                {
                    ISBN = "123-321-123-2223",
                    Title = "Harry Potter and the Chamber of Secrets",
                    OriginalTitle = "Harry Potter and the Chamber of Secrets",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 }
                },
                new PaperBook()
                {
                    ISBN = "123-321-123-2224",
                    Title = "Harry Potter és az Azkabani fogoly",
                    OriginalTitle = "Harry Potter and the Prisoner of Azkaban",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 }
                },
                new PaperBook()
                {
                    ISBN = "123-321-123-2225",
                    Title = "Harry Potter és a Tűz Serlege",
                    OriginalTitle = "Harry Potter and the Goblet of Fire",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 }
                },
                new PaperBook()
                {
                    ISBN = "123-321-123-2222",
                    Title = "Harry Potter és a Főnix Rendje",
                    OriginalTitle = "Harry Potter and the Order of the Phoenix",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 }
                },
                new PaperBook()
                {
                    ISBN = "124-321-223-2222",
                    Title = "Tíz kicsi niga",
                    OriginalTitle = "Ten little niggers",
                    Writer = new List<Writer>() { writer2 },
                    Category = new List<Category>() { cat2 }
                },
                new PaperBook()
                {
                    ISBN = "124-321-323-2222",
                    Title = "Gyilkosság az Orient expresszen",
                    OriginalTitle = "Murder on the Orient Express",
                    Writer = new List<Writer>() { writer2 },
                    Category = new List<Category>() { cat2 }
                },
                new PaperBook()
                {
                    ISBN = "124-321-123-2222",
                    Title = "Az ABC-gyilkosságok",
                    OriginalTitle = "The ABC Murders",
                    Writer = new List<Writer>() { writer2 },
                    Category = new List<Category>() { cat2 }
                },
                new PaperBook()
                {
                    ISBN = "124-325-123-2272",
                    Title = "Egyperces novellák",
                    OriginalTitle = "Egyperces novellák",
                    Writer = new List<Writer>() { writer3 },
                    Category = new List<Category>() { cat3 }
                },
                new PaperBook()
                {
                    ISBN = "124-323-123-2252",
                    Title = "Élőszóval",
                    OriginalTitle = "Élőszóval",
                    Writer = new List<Writer>() { writer3 },
                    Category = new List<Category>() { cat3 }
                },
                new EBook()
                {
                    ISBN = "123-321-123-2882",
                    Title = "Harry Potter és a Félvér Herceg",
                    OriginalTitle = "Harry Potter and the Half-Blood Prince",
                    Writer = new List<Writer>() { writer1 },
                    Category = new List<Category>() { cat1 },
                    FilePath = "itt e ni",
                    Downloadable = true
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
