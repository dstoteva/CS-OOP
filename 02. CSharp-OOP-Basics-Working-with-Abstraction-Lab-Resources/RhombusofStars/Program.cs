using System;

namespace RhombusofStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintUpperPart(n);
            PrintSecondPart(n);
        }
        public static void PrintLine(int num, int n)
        {
            for (int i = 0; i < n - num; i++)
            {
                Console.Write(' ');
            }
            char[] stars = new char[num + 1];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = '*';
            }
            Console.WriteLine(string.Join(' ', stars));
        }
        public static void PrintUpperPart(int n)
        {
            for (int i = 0; i < n; i++)
            {
                PrintLine(i, n);
            }
        }

        public static void PrintSecondPart(int n)
        {
            for (int i = n - 2; i >= 0; i--)
            {
                PrintLine(i, n);
            }
        }
    }
}
