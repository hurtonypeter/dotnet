using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using DesktopApplication.BookService;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace DesktopApplication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowModel : ViewModelBase
    {
        private BookServiceClient serviceClient = new BookServiceClient();

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();

        public ObservableCollection<Book> Books
        {
            get { return _books; }
        }

        private string searchString;

        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; RaisePropertyChanged(); }
        }

        private RelayCommand<KeyEventArgs> searchStartCommand;

        public RelayCommand<KeyEventArgs> SearchStartCommand
        {
            get
            {
                if (searchStartCommand == null)
                {
                    searchStartCommand = new RelayCommand<KeyEventArgs>(e =>
                    {
                        _books.Clear();
                        var result = serviceClient.SearchBook(SearchString);
                        result.ForEach(b => _books.Add(b));
                    }, e => {
                        if (e.Key == Key.Enter)
                            return true;
                        else
                            return false;
                    });
                }
                return searchStartCommand;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }
            _books.Add(
                new Book { ISBN = "123213213", Title = "az", OriginalTitle = "that", Writer = new List<Writer> {
                    new Writer { FirstName = "J. K.", LastName = "Rowling" },
                    new Writer { FirstName = "J. J.", LastName = "Abrams" }
                }
            });
            searchString = "harry";
        }

    }
}