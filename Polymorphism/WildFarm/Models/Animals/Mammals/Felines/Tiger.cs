using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double weightToGain = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void FeedAnimal(Food food)
        {
            base.Eat(food, new List<string> { nameof(Meat) }, weightToGain);
        }
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
