using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Point
    {
        private int X;
        private int Y;

        public Point(int x1, int y1)
        {
            X1 = x1;
            Y1 = y1;
        }

        public int X1 { get => X; set => X = value; }
        public int Y1 { get => Y; set => Y = value; }
    }
}
