using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNums = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();
            var smartphone = new Smartphone(phoneNums, sites);
            Console.Write(smartphone);
        }
    }
}
