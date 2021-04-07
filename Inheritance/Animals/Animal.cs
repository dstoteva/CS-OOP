using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;


        public Animal(string[] parameters)
        {
            if (parameters.Length != 3 || !int.TryParse(parameters[1], out int test))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.Name = parameters[0];
            this.Age = int.Parse(parameters[1]);
            this.Gender = parameters[2];
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public virtual string Gender
        {
            get => this.gender;
            set
            {
                if (value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public void GetTypeOfAnimal()
        {
            Console.WriteLine(this.GetType().Name);
        }
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
        public virtual void ProduceSound()
        {
        }
    }
}
