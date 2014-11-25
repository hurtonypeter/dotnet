using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.BookService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new BookService.BookServiceClient())
            {
                Console.ReadKey();
                var asd = client.GetAllBook();
                var rowling = client.SearchBook("harry potter");

                foreach (var item in asd)
                {
                    Console.WriteLine(item.GetType());
                    if(typeof(EBook).ToString() == item.GetType().ToString())
                    {
                        var tmp = (EBook)item;
                        Console.WriteLine(tmp.FilePath);
                    }
                }
                
                Console.ReadKey();
            }
        }
    }
}
