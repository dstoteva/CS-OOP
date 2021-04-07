using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Draw()
        {
            var sb = new StringBuilder();

            DrawLine(this.Width, '*', '*', sb);

            for (int i = 1; i < this.Height - 1; ++i)

                DrawLine(this.Width, '*', ' ', sb);

            DrawLine(this.Width, '*', '*', sb);

            return sb.ToString();
        }

        private void DrawLine(int width, char end, char mid, StringBuilder sb)
        {

            sb.Append(end);

            for (int i = 1; i < width - 1; ++i)

                sb.Append(mid);

            sb.AppendLine(end.ToString());

        }

    }
}
