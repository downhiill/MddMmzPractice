using System.Collections.Generic;

namespace Mdd.Mmz.Practice.Core
{
    public interface IRepository
    {

        List<Person> Get();   
        Person Get(int personId);
        void Save(Person person);
        void Delete(Person person);



    }
}