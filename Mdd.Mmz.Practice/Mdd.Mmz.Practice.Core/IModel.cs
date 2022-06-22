using System.Collections.Generic;

namespace Mdd.Mmz.Practice.Core
{
    public interface IModel
    {
        List<Person> Get();
        Person Get(int personId);
        void Save(Person person);
        void Delete(Person person);
    }
}