using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void FeedAnimal(Food food);
        public void Eat(Food food, List<string> eatableFoods, double weightToGain)
        {
            string foodType = food.GetType().Name;
            if (eatableFoods.Contains(foodType))
            {
                this.Weight += food.Quantity * weightToGain;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType}!");
            }
        }
        public virtual string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
