using DesktopApplication.BookService;
using DesktopApplication.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopApplication.ViewModel
{
    public class LendBookViewModel : ViewModelBase
    {
        private IBookService bookService;

        private string lendBookId;
        public string LendBookId
        {
            get { return lendBookId; }
            set
            {
                lendBookId = value;
                RaisePropertyChanged();
            }
        }

        private string lendMemberId;
        public string LendMemberId
        {
            get { return lendMemberId; }
            set
            {
                lendMemberId = value;
                RaisePropertyChanged();
            }
        }

        private string backBookId;
        public string BackBookId
        {
            get { return backBookId; }
            set
            {
                backBookId = value;
                RaisePropertyChanged();
            }
        }

        private string backMemberId;
        public string BackMemberId
        {
            get { return backMemberId; }
            set
            {
                backMemberId = value;
                RaisePropertyChanged();
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

        private RelayCommand lendBookCommand;
        public RelayCommand LendBookCommand
        {
            get
            {
                if (lendBookCommand == null)
                {
                    lendBookCommand = new RelayCommand(async () =>
                    {
                        var result = await bookService.LendBookAsync(LendBookId, LendMemberId);
                        if (!result.Error)
                        {
                            MessageBox.Show("Sikeres kölcsönzés!",
                                "Siker!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            LendBookId = "";
                            LendMemberId = "";
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
                return lendBookCommand;
            }
        }

        private RelayCommand backBookCommand;
        public RelayCommand BackBookCommand
        {
            get
            {
                if (backBookCommand == null)
                {
                    backBookCommand = new RelayCommand(async () =>
                    {
                        var result = await bookService.BackBookAsync(BackBookId, BackMemberId);
                        if (!result.Error)
                        {
                            MessageBox.Show("A könyv visszahozva!",
                                "Siker!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            BackBookId = "";
                            BackMemberId = "";
                        }
                        else
                        {
                            MessageBox.Show(result.ErrorMessage,
                                "Hiba",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        }
                    }, null /*() =>
                    {
                        if (string.IsNullOrWhiteSpace(BackBookId) ||
                            string.IsNullOrWhiteSpace(BackMemberId))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }*/);
                }
                return backBookCommand;
            }
        }

        public LendBookViewModel(IBookService client)
        {
            bookService = client;
        }
    }
}
