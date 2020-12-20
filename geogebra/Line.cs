using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace geogebra
{
    class Line
    {
        public Point first_point, second_point;
        public float length;

        static public List<Line> line_drawn_list = new List<Line>();

        float getLength(Point a, Point b)
        {
            float value_x = Math.Abs(a.X - b.X);
            value_x *= value_x;
            float value_y = Math.Abs(a.Y - b.Y);
            value_y *= value_y;
            return (float)Math.Sqrt(value_x + value_y);
        }

        public Line()
        { }

        public Line(Point a, Point b)
        {
            this.first_point = a;
            this.second_point = b;
            this.length = getLength(a, b);
            line_drawn_list.Add(this);
        }

        static public Line GetLineClick(int x, int y)
        {
            for (int i = line_drawn_list.Count - 1; i >= 0; --i)
            {
                Line item = line_drawn_list[i];
                var new_path = new GraphicsPath();
                new_path.AddLine(item.first_point, item.second_point);
                if (new_path.IsOutlineVisible(x, y, new Pen(Color.Black, 5)))
                    return item;
            }
            return new Line();
        }
    }
}
