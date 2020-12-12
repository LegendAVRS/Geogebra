using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geogebra
{
    
    public class Dot
    {
        public Graphics dot_matrix;
        public Pen pen= new Pen(Color.Black);
        public bool first_dot = true;
        private int dot_size = 8;
        public int getFirstNotSmaller(List<int> p_list, int p)
        {
            int l = 0, r = p_list.Count() - 1, res = r;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (p_list[mid] >= p)
                {
                    res = mid;
                    r = mid - 1;
                }
                else l = mid + 1;
            }
            return p_list[res];
        }
        public int getLastSmaller(List<int> p_list, int p)
        {
            int l = 0, r = p_list.Count() - 1, res = 0;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (p_list[mid] < p)
                {
                    res = mid;
                    l = mid + 1;
                }
                else r = mid - 1;
            }
            return p_list[res];
        }
        public int getNearest(List<int> p_list, int p)
        {
            int pR = getFirstNotSmaller(p_list, p);
            int pL = getLastSmaller(p_list, p);
            if (Math.Abs(pR - p) <= Math.Abs(pL - p)) return pR;
            return pL;
        }
        
        public void deleteDot(Dot g, int x, int y)
        {
            g.pen.Color = Form1.DefaultBackColor;
            g.dot_matrix.DrawEllipse(g.pen, x - 4 , y - 4, dot_size, dot_size);
           // g.pen.Color = Color.LightGray;
          //  g.Matrix.DrawLine(g.pen, x - 2, y, x + 2, y);
           // g.Matrix.DrawLine(g.pen, x, y - 2, x, y + 2);
        }

        public void drawDot(Dot g, int x, int y)
        {
            g.dot_matrix.DrawEllipse(g.pen, x - 4, y - 4, dot_size, dot_size);
        }
    }
}
