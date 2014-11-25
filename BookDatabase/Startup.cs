using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDatabase.Service;
using BookDatabase.DataAccess;
using Autofac;
using Autofac.Integration.Wcf;
using System.ServiceModel;
using Autofac.Core.Registration;
using Autofac.Core;

namespace BookDatabase
{
    public class Startup
    {
        public static void Run()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(c => new DesktopRepository()).As<IRepository>();
            builder.Register(c => new BookService(c.Resolve<IRepository>())).As<IBookService>();

            using (var container = builder.Build())
            {
                using (ServiceHost host = new ServiceHost(typeof(BookService)))
                {
                    host.AddDependencyInjectionBehavior<IBookService>(container);
                    host.Open();

                    Console.WriteLine("Service is running...");
                    Console.ReadKey();
                }
            }
        }
    }
}
