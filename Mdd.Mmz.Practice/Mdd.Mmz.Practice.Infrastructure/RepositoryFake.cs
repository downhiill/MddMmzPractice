using System;
using System.Collections.Generic;
using System.Linq;

using Mdd.Mmz.Practice.Core;



namespace Mdd.Mmz.Practice.Infrastructure
{

    public class RepositoryFake : IRepository
    {
        public List<Person> people = new List<Person>()
        {
            new Person() { Id = 1, Age = 15, Phone = 77546343, Name = "Вася", City = "Москва", Country = "Россия" },
            new Person() { Id = 2, Age = 18, Phone = 77123579, Name = "Артем", City = "Краснодар", Country = "Россия" },
            new Person() { Id = 3, Age = 25, Phone = 77132829, Name = "Лера", City = "Челябинск", Country = "Россия" },
            new Person() { Id = 4, Age = 36, Phone = 77754731, Name = "Арина", City = "Екатеринбург", Country = "Россия" },
            new Person() { Id = 5, Age = 34, Phone = 77241573, Name = "Леша", City = "Москва", Country = "Россия" }
        };
        

        public List<Person> Get()
        {
            return people;

        }

        public void Save(Person person)
        {
            if (person.Id == null)
            {

                var id = people.Count == 0 ? 0 : people.Max(i => i.Id);
                id++;

                person.Id = id;

                //var newPerson = new Person();
                //newPerson = person;

                people.Add(person);
            }
            else
            {

                //Get();

            }

        }

        public void Delete(Person person)
        {
            var index = people.IndexOf(people.First(i => i.Id == person.Id));
            people[index] = person;

            people.Remove(person);

        }

        public Person Get(int personId)
        {
            var person = new Person(); 

            try
            {
                person = Get().First(i => i.Id == personId);
                
            }
            catch
            {
            }

            return person;

        }
    }
}
