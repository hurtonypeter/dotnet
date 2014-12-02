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
        public string MyProperty { get; set; }

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
            MyProperty = "anyááááád";
            Messenger.Default.Register<Book>(this, msg =>
                {
                    CurrentBook = msg;
                });
        }
    }
}
