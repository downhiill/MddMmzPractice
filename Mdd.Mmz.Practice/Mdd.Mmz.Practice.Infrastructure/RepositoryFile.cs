using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Mdd.Mmz.Practice.Core;

namespace Mdd.Mmz.Practice.Infrastructure
{
    public class RepositoryFile : IRepository
    {
        private readonly string fileName = "Repository.json";
 
        public List<Person> Get()
        {
            var people = new List<Person>();

            try
            {
                var json = File.ReadAllText(fileName);

                people = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            catch
            {
            
            }

            return people;

        }

        public Person Get(int personId)
        {
            Person person;

            try
            {
                person = Get().First(i => i.Id == personId);
                
            }
            catch
            {
                throw;
            }

            return person;

        }

        public void Save(Person person)
        {
            var people = Get();

            if (person.Id == null)
            {

                var id = people.Count == 0 ? 0 : people.Max(k => k.Id);
                id++;

                person.Id = id;

                people.Add(person);


            }
            else
            {
                var index = people.IndexOf(people.First(i => i.Id == person.Id));
                people[index] = person;

            }

            string text = JsonConvert.SerializeObject(people, Formatting.Indented);

            File.WriteAllText(fileName, text);

           
        }

        public void Delete(Person person)
        {
            var people = Get();

            var index = people.IndexOf(people.First(i => i.Id == person.Id));
            people[index] = person;

            people.Remove(person);

            string text = JsonConvert.SerializeObject(people, Formatting.Indented);

            File.WriteAllText(fileName, text);

        }

    }
}
