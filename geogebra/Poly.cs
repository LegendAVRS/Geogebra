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
        public List<List<Point>> poly_drawn_list = new List<List<Point>>();        
        public bool GetClickPoly(int x, int y)
        {          
            foreach (var poly_list in poly_drawn_list)
            {
                var new_path = new GraphicsPath();                
                new_path.AddPolygon(poly_list.ToArray());
                if (new_path.IsVisible(x, y))        
                    return true;                                                         
            }
            return false;
        }
    }
}
