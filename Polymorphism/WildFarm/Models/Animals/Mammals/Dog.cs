using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double weightToGain = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        public override void FeedAnimal(Food food)
        {
            base.Eat(food, new List<string> { nameof(Meat) }, weightToGain);
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
