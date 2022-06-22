using Mdd.Mmz.Practice.Core;
using Mdd.Mmz.Practice.Infrastructure;
using Microsoft.Data.Sqlite;

namespace Mdd.Mmz.Practice.WinFormsApp
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var a = 1;

            IRepository repository = a == 1 ? new RepositoryFile(): new RepositoryDb();
            var model = new Model(repository);

            var view = new Form1();
            var editView = new EditForm();

            var controller = new Controller(model, view, editView);

            view.GetAction = () => { controller.Get(); };
            view.AddAction = () => { controller.Add(); };
            view.EditAction = (i) => { controller.Edit(i); };
            view.DeleteAction = (i) => { controller.Delete(i);};


            editView.SaveAction = (p) => { controller.Save(p); };

            

            //Application.Run(new Form1());
            Application.Run(view);
        }
    }


}