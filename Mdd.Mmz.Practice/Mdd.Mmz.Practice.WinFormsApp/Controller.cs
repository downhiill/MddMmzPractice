using System;

using Mdd.Mmz.Practice.Core;


namespace Mdd.Mmz.Practice.WinFormsApp
{
    public class Controller 
    {
        private readonly IModel model;
        private readonly IView view;
        private readonly IEditView editView;
        
        public Controller(IModel model, IView view, IEditView editView)
        {
            this.model = model;
            this.view = view;
            this.editView = editView;
        }


        public void Add()
        {
            editView.Open();

        }

        public void Edit(int id)
        {
            var person = model.Get(id);

            editView.Open(person);

        }

        public void Save(Person person)
        {
            try
            {
                model.Save(person);

                Get();

            }
            catch (Exception e)
            {
                view.ShowMessage(e.Message);
            }

        }

        public void Delete(int id)
        {
            var person = model.Get(id);

            model.Delete(person);

            Get();

        }

        public void Get()
        {
            var people = model.Get();

            view.Show(people);

        }

        public Person Get(int id)
        {
            var person = model.Get(id);

            return person;

        }

    }

}
