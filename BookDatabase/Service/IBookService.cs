using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Entities;

namespace BookDatabase.Service
{
    [ServiceContract]
    interface IBookService
    {
        [OperationContract]
        List<Book> GetAllBook();

        [OperationContract]
        List<PaperBook> GetAllPaperBook();

        [OperationContract]
        List<EBook> GetAllEBook();

        [OperationContract]
        Book GetBookById(int id);

        [OperationContract]
        List<Book> SearchBook(string key);

        [OperationContract]
        void SaveBook(Book book);
    }
}
