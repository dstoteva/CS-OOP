using System;

namespace Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            var ferrari = new Ferrari(name);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
