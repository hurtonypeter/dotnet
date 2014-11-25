﻿using BookDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDatabase.DataAccess
{
    public interface IRepository
    {
        List<Book> GetAllBook();
        List<PaperBook> GetAllPaperBook();
        List<EBook> GetAllEBook();
        Book GetBookById(int id);
        void SaveBook(Book book);
        List<Book> SearchBook(string searchKey);
    }
}
