using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get => radius; set => radius = value; }

        public override double CalculateArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        public override string Draw()
        {
            return base.Draw() + Environment.NewLine + "I am a circle";
        }
    }
}
