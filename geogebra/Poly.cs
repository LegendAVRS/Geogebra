using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace geogebra
{
    class Poly
    {
        
        public struct Polygon
        {
            public List<Point> poly_dot_list;
            public float area;
            public float perimeter;
        }

        // public List<List<Point>> poly_drawn_list = new List<List<Point>>();

        public List<Polygon> poly_drawn_list = new List<Polygon>();

        public List<float> poly_area_list = new List<float>();
        public Polygon GetClickPoly(int x, int y)
        {          
            foreach (var item in poly_drawn_list)
            {
                var new_path = new GraphicsPath();                
                new_path.AddPolygon(item.poly_dot_list.ToArray());
                if (new_path.IsVisible(x, y))        
                    return item;                                                         
            }
            return new Polygon();
        }

        public float getArea(List<Point> poly_list)
        {
            int num_points = poly_list.Count;

            Point temp_point_1 = poly_list[0];
            Point temp_point_2 = poly_list[1];

            int value_1 = Math.Abs(temp_point_1.X - temp_point_2.X);
            value_1 *= value_1;

            int value_2 = Math.Abs(temp_point_1.Y - temp_point_2.Y);
            value_2 *= value_2;

            float d1 = (float)Math.Sqrt(value_1 + value_2);
            float d2 = d1 / 50;

            float line_ratio = d1 / d2;
            line_ratio *= line_ratio;

            List<Point> p_list = new List<Point>();
            foreach (var p in poly_list)
                p_list.Add(new Point(p.X, p.Y));
            
            p_list.Add(poly_list[0]);

            // Get the areas.
            float area = 0;
            for (int i = 0; i < num_points; i++)
            {
                area +=
                    (p_list[i + 1].X - p_list[i].X) *
                    (p_list[i + 1].Y + p_list[i].Y) / 2;
            }

            return Math.Abs(area / line_ratio);
        }

        public float getPerimeter(List<Point>poly_list)
        {
            float res = 0;
            for (int i = 0;i < poly_list.Count;++i)
            {
                int value_1 = Math.Abs(poly_list[i].X - poly_list[(i + 1) % poly_list.Count].X);
                value_1 *= value_1;

                int value_2 = Math.Abs(poly_list[i].Y - poly_list[(i + 1) % poly_list.Count].Y);
                value_2 *= value_2;

                float d = (float)Math.Sqrt(value_1 + value_2);

                res += d / 50;
            }      
            return res;
        }
    }
}
