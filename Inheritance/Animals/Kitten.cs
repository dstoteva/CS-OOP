using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Animal
    {
        private const string gender = "Female";

        public Kitten(string[] parameters)
            :base(parameters)
        {
        }
        public override string Gender { get => base.Gender; set => base.Gender = gender; }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
