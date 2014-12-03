using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using DesktopApplication;

namespace DesktopApplication.BookService
{
    public partial class BookServiceClient
    {
        [PreferredConstructor]
        public BookServiceClient(IDummyClass dc) : base()
        {
        }
    }

    public class DummyClass : IDummyClass
    {
        public DummyClass()
        {

        }
    }

    public interface IDummyClass
    {

    }
}
