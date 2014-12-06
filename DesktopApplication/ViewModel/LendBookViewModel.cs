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
                    lendBookCommand = new RelayCommand(() =>
                    {
                        
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
                    backBookCommand = new RelayCommand(() =>
                    {
                        
                    }, null);
                }
                return backBookCommand;
            }
        }

        public LendBookViewModel()
        {
            
        }
    }
}
