using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IBirthable, IIdentifiable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
            this.Food = 0;
        }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
