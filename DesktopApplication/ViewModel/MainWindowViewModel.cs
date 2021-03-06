using DesktopApplication.BookService;
using DesktopApplication.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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
    public class MainWindowViewModel : ViewModelBase
    {
        private IBookService bookService;

        private ObservableCollection<Book> books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get { return books; }
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
                    searchStartCommand = new RelayCommand<KeyEventArgs>(async (e) =>
                    {
                        books.Clear();
                        var result = await bookService.SearchBookAsync(SearchString);
                        result.ForEach(b => books.Add(b));
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

        private Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set 
            {
                selectedBook = value;
                RaisePropertyChanged();
                Messenger.Default.Send<Book>(value);
            }
        }

        private RelayCommand<Window> lendBookCommand;
        public RelayCommand<Window> LendBookCommand
        {
            get
            {
                if (lendBookCommand == null)
                {
                    lendBookCommand = new RelayCommand<Window>((w) =>
                    {
                        new LendBook().Show();
                        w.Close();
                    }, null);
                }
                return lendBookCommand;
            }
        }

        private RelayCommand<Window> membersViewCommand;
        public RelayCommand<Window> MembersViewCommand
        {
            get
            {
                if (membersViewCommand == null)
                {
                    membersViewCommand = new RelayCommand<Window>((w) =>
                    {
                        new Members().Show();
                        w.Close();
                    }, null);
                }
                return membersViewCommand;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainWindowViewModel(IBookService _bookService)
        {
            bookService = _bookService;

            

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }
    }
}