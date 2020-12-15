using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geogebra
{
    public class Grid
    {
        public Graphics Matrix;
        public Pen pen;
        public List<int> x_list = new List<int>();
        public List<int> y_list = new List<int>();

        public int first_horizontal;
        public int first_vertical;    
        

        public void DrawAxis()
        {
            int form_width = Form1.ActiveForm.Width - 100;
            int form_height = Form1.ActiveForm.Height;

            this.pen.Color = Color.Black;
            Point p1 = new Point(form_width / 2, 0);
            Point p2 = new Point(form_width / 2, Form1.ActiveForm.Height);
            this.Matrix.DrawLine(this.pen, p1, p2);
            p1.X = 0;
            p1.Y = Form1.ActiveForm.Height / 2;
            p2.X = form_width;
            p2.Y = p1.Y;
            this.Matrix.DrawLine(this.pen, p1, p2);
        }

        public void DrawGridLine()
        {
            int form_width = Form1.ActiveForm.Width - 100;
            int form_height = Form1.ActiveForm.Height;

            this.pen.Color = Color.LightGray;
            Point middle_point = new Point(form_width / 2, form_height / 2);
            Point p1 = middle_point, p2 = middle_point;
            p1.X = 0;
            p2.X = form_width;
            int space = 50;

            while (p1.Y > 0) //Upper horizontal lines
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                y_list.Add(p1.Y);
                p1.Y -= space;
                p2.Y -= space;
            }

            first_horizontal = p1.Y + space;

            p1 = middle_point;
            p2 = middle_point;
            p1.X = 0;
            p2.X = form_width;
            while (p1.Y < form_height) //Lower horizontal lines
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                y_list.Add(p1.Y);
                p1.Y += space;
                p2.Y += space;
            }

            p1 = middle_point;
            p2 = middle_point;
            p1.Y = 0;
            p2.Y = form_height; 

            while (p1.X > 0) //Left vertial lines
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                x_list.Add(p1.X);
                p1.X -= space;
                p2.X -= space;
            }

            first_vertical = p1.X + space;

            p1 = middle_point;
            p2 = middle_point;
            p1.Y = 0;
            p2.Y = form_height;

            while (p1.X < form_width)  //Right vertical lines
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                x_list.Add(p1.X);
                p1.X += space;
                p2.X += space;
            }

            x_list.Sort();
            y_list.Sort();
        }
    }
}
