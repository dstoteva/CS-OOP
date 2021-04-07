using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        private Point topLeftPoint;
        private Point bottomRightPoint;

        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            TopLeftPoint = topLeftPoint;
            BottomRightPoint = bottomRightPoint;
        }

        public Point TopLeftPoint { get => topLeftPoint; set => topLeftPoint = value; }
        public Point BottomRightPoint { get => bottomRightPoint; set => bottomRightPoint = value; }

        public bool Contains(Point point)
        {
            if (point.X1 >= TopLeftPoint.X1 && point.X1 <= BottomRightPoint.X1 && point.Y1 >= TopLeftPoint.Y1 && point.Y1 <= BottomRightPoint.Y1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
