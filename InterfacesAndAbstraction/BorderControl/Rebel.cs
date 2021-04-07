using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        private string group;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.group = group;
            this.Food = 0;
        }
        public int Age { get; set; }
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
