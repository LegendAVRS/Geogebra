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
        static public Graphics dot_hover_matrix;
        static public Graphics dot_drawn_matrix;

        static public Pen pen = new Pen(Color.Black);
        static public SolidBrush brush = new SolidBrush(Color.Black);

        static public bool first_hover_dot = true;
        static public int new_hover_x, new_hover_y, old_hover_x, old_hover_y;

        public int dot_cnt = 0;
        static public List<Point> dot_list = new List<Point>();
        static private int dot_size = 8;

        private int getFirstNotSmaller(List<int> p_list, int p)
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
        private int getLastSmaller(List<int> p_list, int p)
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
        public int getNearest(List<int>p_list, int first_p, int p)
        {
            int pR = getFirstNotSmaller(p_list, p);
            int pL = getLastSmaller(p_list, p);
            if (Math.Abs(pR - p) <= Math.Abs(pL - p)) return pR;
            return pL;
        }     
        
        static public void drawDot(bool hover, int x, int y)
        {
            if (hover)
            {
                dot_hover_matrix.DrawEllipse(pen, x - 4, y - 4, dot_size, dot_size);
                dot_hover_matrix.FillEllipse(brush, x - 4, y - 4, dot_size, dot_size);
            }         
            else
            {
                dot_drawn_matrix.DrawEllipse(pen, x - 4, y - 4, dot_size, dot_size);
                dot_drawn_matrix.FillEllipse(brush, x - 4, y - 4, dot_size, dot_size);
            }
        }
       
    }
}
