using System;

namespace BoxEx
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.ReturnSurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.ReturnLateralArea():f2}");
                Console.WriteLine($"Volume - {box.ReturnVolume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
