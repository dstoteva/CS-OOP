using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string[] parameters)
            : base(parameters)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
