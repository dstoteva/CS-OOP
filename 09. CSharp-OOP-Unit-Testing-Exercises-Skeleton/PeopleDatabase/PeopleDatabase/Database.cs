using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeopleDatabase
{
    public class Database
    {
        private List<Person> people;

        public Database()
        {
            this.People = new List<Person>();
        }

        public List<Person> People { get; private set; }

        public void Add(Person person)
        {
            if (this.People.Any(x => x.Username == person.Username))
            {
                throw new InvalidOperationException("Database already contains a person with this username.");
            }
            else if (this.People.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException("Database already contains a person with this ID.");
            }
            this.People.Add(person);
        }
        public void Remove(Person person)
        {
            if (this.People.Contains(person))
            {
                this.People.Remove(person);
            }
        }
        public Person FindByUsername(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Username can not be empty.");
            }
            else if (!this.People.Any(x => x.Username == name))
            {
                throw new InvalidOperationException("No user with this username is found.");
            }
            return People.FirstOrDefault(x => x.Username == name);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("ID can not be negative.");
            }
            else if (!this.People.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("No user with this ID is found.");
            }
            return this.People.FirstOrDefault(x => x.Id == id);
        }
    }
}
