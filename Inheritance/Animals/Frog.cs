using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string[] parameters)
            :base(parameters)
        {
        }
        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
