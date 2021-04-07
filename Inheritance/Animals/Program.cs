using System;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string animalType = Console.ReadLine();
                    if (animalType == "Beast!")
                    {
                        break;
                    }
                    string[] animalArgs = Console.ReadLine().Split();
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new Dog(animalArgs);
                            dog.GetTypeOfAnimal();
                            Console.WriteLine(dog.ToString());
                            dog.ProduceSound();
                            break;
                        case "Cat":
                            Cat cat = new Cat(animalArgs);
                            cat.GetTypeOfAnimal();
                            Console.WriteLine(cat.ToString());
                            cat.ProduceSound();
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalArgs);
                            frog.GetTypeOfAnimal();
                            Console.WriteLine(frog.ToString());
                            frog.ProduceSound();
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalArgs);
                            kitten.GetTypeOfAnimal();
                            Console.WriteLine(kitten.ToString());
                            kitten.ProduceSound();
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalArgs);
                            tomcat.GetTypeOfAnimal();
                            Console.WriteLine(tomcat.ToString());
                            tomcat.ProduceSound();
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }    
            }
        }

    }
}
