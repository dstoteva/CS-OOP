using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double weightToGain = 0.25; 
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void FeedAnimal(Food food)
        {
            base.Eat(food, new List<string> { nameof(Meat) }, weightToGain);
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
