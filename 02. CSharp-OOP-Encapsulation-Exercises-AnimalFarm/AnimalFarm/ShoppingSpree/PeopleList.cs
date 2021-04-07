using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class PeopleList
    {
        private List<Person> allPeople;

        public PeopleList(string[] parameters)
        {
            this.AllPeople = new List<Person>();
            for (int i = 0; i < parameters.Length; i += 2)
            {
                Person currentPerson = new Person(parameters[i], decimal.Parse(parameters[i + 1]));
                this.AllPeople.Add(currentPerson);
            }
        }
        public List<Person> AllPeople
        {
            get => this.allPeople;
            private set
            {
                this.allPeople = value;
            }
        }
        public Person GetPerson(string name)
        {
            return AllPeople.FirstOrDefault(x => x.Name == name);
        }
    }
}
