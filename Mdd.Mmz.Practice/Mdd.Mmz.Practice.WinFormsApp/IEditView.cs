using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.WinFormsApp
{
    public interface IEditView
    {

        void Open();

        void Open(Person person);

        void Save();

    }
}