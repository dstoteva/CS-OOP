using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favFood)
        {
            this.Name = name;
            this.FavouriteFood = favFood;
        }
        public string Name { get; private set; }
        public string FavouriteFood { get; private set; }
        public virtual string ExplainSelf()
        {
            return string.Format("I am {0} and my fovourite food is {1}", this.Name, this.FavouriteFood);
        }
    }
}
