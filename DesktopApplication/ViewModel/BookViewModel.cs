using DesktopApplication.BookService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.ViewModel
{
    public class BookViewModel : ViewModelBase
    {

        private Book currentBook;
        public Book CurrentBook
        {
            get
            {
                return currentBook;
            }
            set
            {
                currentBook = value;
                RaisePropertyChanged();
            }
        }

        public BookViewModel()
        {
            Messenger.Default.Register<Book>(this, msg =>
                {
                    CurrentBook = msg;
                });

            if (IsInDesignMode)
            {
                CurrentBook = new PaperBook()
                {
                    ISBN = "123-321-123-2222",
                    Title = "Harry Potter és a Bölcsek Köve",
                    OriginalTitle = "Harry Potter and the Philosoper's Stone",
                    Writer = new List<Writer>() { new Writer
                        {
                            FirstName = "J. K.",
                            LastName = "Rowling"
                        } 
                    },
                    Category = new List<Category>() { new Category { Name = "Gyermek és ifjúsági regények" } }
                };
            }
        }
    }
}
