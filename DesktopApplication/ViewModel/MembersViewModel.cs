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
using System.Windows;
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
                if (value != null)
                {
                    MId = value.Id;
                    MBarcode = value.Barcode;
                    MAddress = value.Address;
                    MName = value.Name;
                    MTelephone = value.Telephone;
                    MRowVersion = value.RowVersion;
                }
                RaisePropertyChanged();
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
                        var result = await bookService.SearchMemberAsync(SearchString);
                        result.ForEach(b => members.Add(b));
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

        private RelayCommand<Window> backToMainWindowCommand;
        public RelayCommand<Window> BackToMainWindowCommand
        {
            get
            {
                if (backToMainWindowCommand == null)
                {
                    backToMainWindowCommand = new RelayCommand<Window>((w) =>
                    {
                        new MainWindow().Show();
                        w.Close();
                    }, null);
                }
                return backToMainWindowCommand;
            }
        }

        private RelayCommand newMember;
        public RelayCommand NewMember
        {
            get
            {
                if (newMember == null)
                {
                    newMember = new RelayCommand(() =>
                    {
                        SelectedMember = new Member();
                    }, null);
                }
                return newMember;
            }
        }

        private RelayCommand saveMember;
        public RelayCommand SaveMember
        {
            get
            {
                if (saveMember == null)
                {
                    saveMember = new RelayCommand(async () =>
                    {
                        var member = new Member
                        {
                            Id = MId,
                            Name = MName,
                            Barcode = MBarcode,
                            Address = MAddress,
                            Telephone = MTelephone,
                            Registration = DateTime.Now,
                            RowVersion = MRowVersion
                        };
                        var result = await bookService.SaveMemberAsync(member);
                        if (!result.Error)
                        {
                            SelectedMember = result.Member;
                            MessageBox.Show("Sikeres mentés!");
                        }
                        else
                        {
                            MessageBox.Show(result.ErrorMessage,
                                "Hiba",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }, null);
                }
                return saveMember;
            }
        }

        public MembersViewModel(IBookService client)
        {
            bookService = client;
        }

        #region sokprop a semmiért
        private int mId;
        public int MId
        {
            get { return mId; }
            set
            {
                mId = value;
                RaisePropertyChanged();
            }
        }
        private string mBarcode;
        public string MBarcode
        {
            get { return mBarcode; }
            set
            {
                mBarcode = value;
                RaisePropertyChanged();
            }
        }
        private string mAddress;
        public string MAddress
        {
            get { return mAddress; }
            set
            {
                mAddress = value;
                RaisePropertyChanged();
            }
        }
        private string mName;
        public string MName
        {
            get { return mName; }
            set
            {
                mName = value;
                RaisePropertyChanged();
            }
        }
        private string mTelephone;
        public string MTelephone
        {
            get { return mTelephone; }
            set
            {
                mTelephone = value;
                RaisePropertyChanged();
            }
        }
        private byte[] mRowVersion;
        public byte[] MRowVersion
        {
            get { return mRowVersion; }
            set
            {
                mRowVersion = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
