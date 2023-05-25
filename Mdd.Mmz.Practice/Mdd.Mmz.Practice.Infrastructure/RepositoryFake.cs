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
            new Person() { Id = 1, Score = 77546343, NameEvents = "Вася", Status = "Москва", CountryAndCity = "Россия" },
            new Person() { Id = 2, Score = 77123579, NameEvents = "Артем", Status = "Краснодар", CountryAndCity = "Россия" },
            new Person() { Id = 3, Score = 77132829, NameEvents = "Лера", Status = "Челябинск", CountryAndCity = "Россия" },
            new Person() { Id = 4, Score = 77754731, NameEvents = "Арина", Status = "Екатеринбург", CountryAndCity = "Россия" },
            new Person() { Id = 5, Score = 77241573, NameEvents = "Леша", Status = "Москва", CountryAndCity = "Россия" }
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
