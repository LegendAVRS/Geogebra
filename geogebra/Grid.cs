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
        public void DrawAxis()
        {
            this.pen.Color = Color.Black;
            Point p1 = new Point(Form1.ActiveForm.Size.Width / 2, 0);
            Point p2 = new Point(Form1.ActiveForm.Size.Width / 2, Form1.ActiveForm.Size.Height);
            this.Matrix.DrawLine(this.pen, p1, p2);
            p1.X = 0;
            p1.Y = Form1.ActiveForm.Size.Height / 2;
            p2.X = Form1.ActiveForm.Size.Width;
            p2.Y = p1.Y;
            this.Matrix.DrawLine(this.pen, p1, p2);
        }

        public void DrawGridLine()
        {
            this.pen.Color = Color.LightGray;
            Point middle_point = new Point(Form1.ActiveForm.Size.Width / 2, Form1.ActiveForm.Size.Height / 2);
            Point p1 = middle_point, p2 = middle_point;
            p1.X = 0;
            p2.X = Form1.ActiveForm.Size.Width;
            int space = 50;

            while (p1.Y > 0)
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                p1.Y -= space;
                p2.Y -= space;
            }

            p1 = middle_point;
            p2 = middle_point;
            p1.X = 0;
            p2.X = Form1.ActiveForm.Size.Width;
            while (p1.Y < Form1.ActiveForm.Size.Height)
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                p1.Y += space;
                p2.Y += space;
            }

            p1 = middle_point;
            p2 = middle_point;
            p1.Y = 0;
            p2.Y = Form1.ActiveForm.Size.Height; 

            while (p1.X > 0)
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                p1.X -= space;
                p2.X -= space;
            }

            p1 = middle_point;
            p2 = middle_point;
            p1.Y = 0;
            p2.Y = Form1.ActiveForm.Size.Height;

            while (p1.X < Form1.ActiveForm.Size.Width)
            {
                this.Matrix.DrawLine(this.pen, p1, p2);
                p1.X += space;
                p2.X += space;
            }
        }
    }
}
