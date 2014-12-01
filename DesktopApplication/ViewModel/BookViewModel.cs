using GalaSoft.MvvmLight;
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

        public BookViewModel()
        {
            MyProperty = "anyááááád";
        }
    }
}
