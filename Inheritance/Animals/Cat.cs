using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string[] parameters)
            :base(parameters)
        {

        }
        public override void ProduceSound()
        {
            Console.WriteLine("Meow meow");
        }
    }
}
