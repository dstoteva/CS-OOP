using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double weightToGain = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void FeedAnimal(Food food)
        {
            base.Eat(food, new List<string> { nameof(Meat), nameof(Vegetable) }, weightToGain);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
