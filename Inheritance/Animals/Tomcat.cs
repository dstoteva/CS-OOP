using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Animal
    {
        private const string gender = "Male";

        public Tomcat(string[] parameters)
            :base(parameters)
        {
        }

        public override string Gender { get => base.Gender; set => base.Gender = gender; }
        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
