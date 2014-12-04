using DesktopApplication.BookService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplication.ViewModel
{
    public class BookViewModel : ViewModelBase
    {
        private IBookService bookService;

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

        private PaperBook paperBook;
        public PaperBook PaperBook
        {
            get
            {
                return paperBook;
            }
            set
            {
                paperBook = value;
                RaisePropertyChanged();
            }
        }

        private EBook eBook;
        public EBook EBook
        {
            get
            {
                return eBook;
            }
            set
            {
                eBook = value;
                RaisePropertyChanged();
            }
        }

        public BookViewModel(IBookService _client)
        {
            bookService = _client;

            Messenger.Default.Register<Book>(this, async (msg) =>
                {
                    CurrentBook = msg;
                    if (msg.GetType() == typeof(EBook))
                    {
                        EBook = (EBook)msg;
                        PaperBook = null;
                    }
                    if (msg.GetType() == typeof(PaperBook))
                    {
                        PaperBook = (PaperBook)msg;
                        EBook = null;
                        var result = (PaperBook)await bookService.GetBookByIdAsync(msg.Id);
                        PaperBook.Copies = result.Copies;
                    }
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
