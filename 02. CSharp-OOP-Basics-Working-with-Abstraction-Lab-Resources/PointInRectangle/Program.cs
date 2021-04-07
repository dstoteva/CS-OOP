using System;
using System.Linq;

namespace PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] points = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Point topLeft = new Point(points[0], points[1]);
            Point bottomRight = new Point(points[2], points[3]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int[] pointArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                Point point = new Point(pointArgs[0], pointArgs[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
