using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.ConsoleApp
{
    public interface IView
    {
        string GetMode();

        string GetRepeat();

        string GetShow();

        string GetEditPersonId();

        string GetDeletePersonId();

        Person EditPerson(Person person);

        void ShowPerson(Person person);

        void ShowMessage(string message);

    }
}