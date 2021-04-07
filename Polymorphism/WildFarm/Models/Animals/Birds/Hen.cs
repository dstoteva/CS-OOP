using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double weightToGain = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override void FeedAnimal(Food food)
        {
            base.Eat(food, new List<string> { nameof(Fruit), nameof(Vegetable), nameof(Meat), nameof(Seeds) }, weightToGain);
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
