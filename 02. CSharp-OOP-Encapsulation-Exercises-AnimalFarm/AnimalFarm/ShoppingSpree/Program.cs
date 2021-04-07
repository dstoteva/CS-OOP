using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] peopleInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var allPeople = new PeopleList(peopleInput);

                string[] productsInput = Console.ReadLine().Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
                var allProducts = new ProductsList(productsInput);
                while (true)
                {
                    string[] inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (inputArgs[0] == "END")
                    {
                        break;
                    }
                    string personsName = inputArgs[0];
                    string productName = inputArgs[1];

                    var product = allProducts.GetProduct(productName);
                    var person = allPeople.GetPerson(personsName);

                    person.AddProduct(product);
                }
                foreach (Person person in allPeople.AllPeople)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
