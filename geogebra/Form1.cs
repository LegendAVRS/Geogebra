using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geogebra
{

    public partial class Form1 : Form
    {
        Grid g = new Grid();
        Dot new_dot = new Dot();
        int dot_x, dot_y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        { 
            g.pen = new Pen(Color.Black);
            g.Matrix = this.CreateGraphics();
            g.DrawGridLine();
            g.DrawAxis();

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
              if (!new_dot.first_dot)
              {
                g.pen.Color = Form1.DefaultBackColor;
                g.Matrix.DrawEllipse(g.pen, dot_x, dot_y, 5, 5);
                g.pen.Color = Color.Black;
              }

              dot_x = new_dot.getNearest(g.x_list, e.X);
              dot_y = new_dot.getNearest(g.y_list, e.Y);
              g.Matrix.DrawEllipse(g.pen, dot_x, dot_y, 5, 5);
              new_dot.first_dot = false;


        }
    }
}
