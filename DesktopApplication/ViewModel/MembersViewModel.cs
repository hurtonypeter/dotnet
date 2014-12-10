using DesktopApplication.BookService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApplication.ViewModel
{
    public class MembersViewModel : ViewModelBase
    {
        private IBookService bookService;

        private ObservableCollection<Member> members = new ObservableCollection<Member>();
        public ObservableCollection<Member> Members
        {
            get { return members; }
        }

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; RaisePropertyChanged(); }
        }

        private Member selectedMember;
        public Member SelectedMember
        {
            get { return selectedMember; }
            set
            {
                selectedMember = value;
                RaisePropertyChanged();
                Messenger.Default.Send<Member>(value);
            }
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
                        members.Clear();
                        //var result = await bookService.SearchBookAsync(SearchString);
                        //result.ForEach(b => members.Add(b));
                    }, e =>
                    {
                        if (e.Key == Key.Enter)
                            return true;
                        else
                            return false;
                    });
                }
                return searchStartCommand;
            }
        }

        public MembersViewModel(IBookService client)
        {
            bookService = client;
        }
    }
}
