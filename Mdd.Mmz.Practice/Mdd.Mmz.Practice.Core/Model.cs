using System;
using System.Collections.Generic;

namespace Mdd.Mmz.Practice.Core
{
    public class Model : IModel
    {
        private readonly IRepository repository;

        public Model(IRepository repository)
        {
            this.repository = repository;

        }

        public List<Person> Get()
        {
            try
            {
                return repository.Get();
            }
            catch
            {
                throw;
            }

        }

        public Person Get(int personId)
        {
            try 
            {
                return repository.Get(personId);
            }
            catch
            {
                throw;
            }

        }

        public void Save(Person person)
        {
            try
            {
                repository.Save(person);
            }
            catch 
            {
                throw;
            }

        }

        public void Delete(Person person)
        {
            try
            {
                repository.Delete(person);
            }
            catch
            {
                throw;
            }

        }

    }

}
