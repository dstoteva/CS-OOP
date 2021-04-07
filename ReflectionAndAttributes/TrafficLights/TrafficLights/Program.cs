using System;
using System.Linq;

namespace TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var lights = Console.ReadLine().Split().Select(l => new LightChanger(l)).ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                lights.ForEach(l => l.ChangeLight());
                Console.WriteLine(string.Join(" ", lights));
            }
        }
    }
}
