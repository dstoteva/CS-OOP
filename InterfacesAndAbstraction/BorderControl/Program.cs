using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            var buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] buyersArgs = Console.ReadLine().Split();
                string name = buyersArgs[0];
                int age = int.Parse(buyersArgs[1]);
                if (buyersArgs.Length == 3)
                {
                    string group = buyersArgs[2];
                    var rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
                else
                {
                    string id = buyersArgs[2];
                    string birthDate = buyersArgs[3];
                    var citizen = new Citizen(name, age, id, birthDate);
                    buyers.Add(citizen);
                }
            }
            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }
                foreach (var b in buyers)
                {
                    if (b.Name == name)
                    {
                        b.BuyFood();
                    }
                }
            }
            int food = 0;
            foreach (var b in buyers)
            {
                food += b.Food;
            }
            Console.WriteLine(food);
        }
        static void PrintInhabitorsBornInYear(List<IBirthable> birthables, string birthYear)
        {
            foreach (var b in birthables)
            {
                string currentYear = b.BirthDate.Split('/')[2];
                if (currentYear == birthYear)
                {
                    Console.WriteLine(b.BirthDate);
                }
            }
        }
    }
}
