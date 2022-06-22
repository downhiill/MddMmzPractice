using System;

using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;


namespace Mdd.Mmz.Practice.ConsoleApp
{
    class Program
    {   

        static void Main(string[] args)
        {
            var a = 2;

            IRepository repository = a == 1 ? new RepositoryFake() : new RepositoryFile();
            var model = new Model(repository);

            var view = new View();
            
            var controller = new Controller(model, view);

            controller.Start();


            Thread.Sleep(Timeout.Infinite);

        }
    }
     
}


