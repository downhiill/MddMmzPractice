using System;

using Mdd.Mmz.Practice.Core;


namespace Mdd.Mmz.Practice.ConsoleApp
{
    public class Controller : IController
    {
        private readonly IModel model;
        private readonly IView view;

        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Start()
        {
            var ModeStart = view.GetMode();

            switch (Convert.ToInt32(ModeStart))
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Edit();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    Get();
                    break;
            }

            Start();

        }

        private void Add()
        {
            AddPerson();

            var ModeRepeat = view.GetRepeat();

            if (Convert.ToInt32(ModeRepeat) == 1)
            {
                AddPerson();

            }

        }

        private void AddPerson()
        {
            var person = view.EditPerson(new Person());

            model.Save(person);

            var ModeInfo = view.GetShow();

            if (Convert.ToInt32(ModeInfo) == 1)
            {
                view.ShowPerson(person);

            }

        }

        private void Edit()
        {
            try
            {
                var personId = view.GetEditPersonId();

                var person = model.Get(Convert.ToInt32(personId));

                view.ShowPerson(person);

                person = view.EditPerson(person);

                model.Save(person);

            }
            catch (Exception e)
            {
                view.ShowMessage(e.Message);
            }



        }
        private void Delete()
        {
            var personId = view.GetDeletePersonId();

            var person = model.Get(Convert.ToInt32(personId));

            view.ShowPerson(person);

            //добавить подтверждение

            model.Delete(person);
            
        }
        private void Get()
        {
            var people = model.Get();

            people.ForEach(i => view.ShowPerson(i));

        }

    }

}
