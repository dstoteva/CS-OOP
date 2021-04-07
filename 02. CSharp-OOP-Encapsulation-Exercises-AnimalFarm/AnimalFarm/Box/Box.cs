using System;
using System.Collections.Generic;
using System.Text;

namespace BoxEx
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get => this.length;
            private set
            {
                ExceptionThrower(value, nameof(Length));
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                ExceptionThrower(value, nameof(Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                ExceptionThrower(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ExceptionThrower(double value, string name)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }
        }
        public Box(double length, double width, double heigth)
        {
            this.Length = length;
            this.Width = width;
            this.Height = heigth;
        }

        public double ReturnSurfaceArea()
        {
            return 2 * (this.Length * this.Height + this.Length * this.Width + this.Height * this.Width);
        }
        public double ReturnLateralArea()
        {
            return 2 * (this.Height * this.Width + this.Length * this.Height);
        }

        public double ReturnVolume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}
