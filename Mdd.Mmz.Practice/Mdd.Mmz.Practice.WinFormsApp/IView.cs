using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.WinFormsApp
{
    public interface IView
    {

        void Show(List<Person> people);

        void ShowMessage(string message);
    }
}