using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using BookDatabase.Service;
using Autofac;
using Autofac.Integration.Wcf;
using BookDatabase;

namespace DatabaseHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<BookService>();

            //using (var container = builder.Build())
            //{
            //    using (ServiceHost host = new ServiceHost(typeof(BookService)))
            //    {
            //        host.Open();
            //        host.AddDependencyInjectionBehavior<IBookService>(container);

            //        Console.WriteLine("Service is running...");
            //        Console.ReadKey();
            //    }
            //}
            Startup.Run();
        }
    }
}
