using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;
using WildFarm.Models.Foods;

namespace WildFarm
{
    public class Program
    {    
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string[] animalArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string type = animalArgs[0];

                if (type == "End")
                {
                    break;
                }
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);

                string[] foodArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string food = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);
                
                if (animalArgs.Length == 5)
                {
                    string livingRegion = animalArgs[3];
                    string breed = animalArgs[4];
                    if (type == "Cat")
                    {
                        Cat cat = new Cat(name, weight, livingRegion, breed);
                        Console.WriteLine(cat.ProduceSound());
                        animals.Add(cat);
                        try
                        {
                            cat.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    else if (type == "Tiger")
                    {
                        Tiger tiger = new Tiger(name, weight, livingRegion, breed);
                        Console.WriteLine(tiger.ProduceSound());
                        animals.Add(tiger);
                        try
                        {
                            tiger.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                }
                else if (double.TryParse(animalArgs[3], out double wingsSize))
                {
                    if (type == "Hen")
                    {
                        Hen hen = new Hen(name, weight, wingsSize);
                        Console.WriteLine(hen.ProduceSound());
                        animals.Add(hen);
                        try
                        {
                            hen.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (type == "Owl")
                    {
                        Owl owl = new Owl(name, weight, wingsSize);
                        Console.WriteLine(owl.ProduceSound());
                        animals.Add(owl);
                        try
                        {
                            owl.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                }
                else 
                {
                    string livingRegion = animalArgs[3];
                    if (type == "Dog")
                    {
                        Dog dog = new Dog(name, weight, livingRegion);
                        Console.WriteLine(dog.ProduceSound());
                        animals.Add(dog);
                        try
                        {
                            dog.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                    else if (type =="Mouse")
                    {
                        Mouse mouse = new Mouse(name, weight, livingRegion);
                        Console.WriteLine(mouse.ProduceSound());
                        animals.Add(mouse);
                        try
                        {
                            mouse.FeedAnimal(ReturnFood(food, foodQuantity));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                    }
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        public static Food ReturnFood(string name, int quantity)
        {
            if (name == "Seeds")
            {
                return new Seeds(quantity);
            }
            else if (name == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (name == "Meat")
            {
                return new Meat(quantity);
            }
            else
            {
                return new Vegetable(quantity);
            }   
        }
    }
    
}
