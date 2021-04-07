using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleDatabase
{
    public class Person
    {
        private long id;
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }

        public string Username { get; private set; }
        public long Id
        {
            get => this.id;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("ID can not be negative.");
                }
                this.id = value;
            }
        }
    }
}
