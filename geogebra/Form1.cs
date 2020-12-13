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
        Dot dot = new Dot();
        Bitmap grid_surface, dot_surface, drawn_surface;
        List<Bitmap> bm_list = new List<Bitmap>();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            grid_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            drawn_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            picGrid.Height = ActiveForm.Height;
            picGrid.Width = ActiveForm.Width;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g.x_list.Count == 0)
                return;

            dot_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            dot.dot_matrix = Graphics.FromImage(dot_surface);

            dot.new_x = dot.getNearest(g.x_list, e.X);
            dot.new_y = dot.getNearest(g.y_list, e.Y);
            if (!dot.first_dot)
            {
                dot.first_dot = false;
                if (dot.new_x == dot.old_x && dot.new_y == dot.old_y)
                    return;
            }

            dot.drawDot(dot, dot.new_x, dot.new_y);
            dot.old_x = dot.new_x;
            dot.old_y = dot.new_y;

            Bitmap final = new Bitmap(ActiveForm.Width, ActiveForm.Height);
      
            Graphics graphics = Graphics.FromImage(final);
            graphics.DrawImage(grid_surface, 0, 0, ActiveForm.Width, ActiveForm.Height);
            graphics.DrawImage(dot_surface, 0, 0, ActiveForm.Width, ActiveForm.Height);
            graphics.DrawImage(drawn_surface, 0, 0, ActiveForm.Width, ActiveForm.Height);
            graphics.Dispose();
   
            picGrid.Image = final;
      
        }

        private void picGrid_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                bm_list.Add((Bitmap)drawn_surface.Clone());
                dot.dot_matrix = Graphics.FromImage(drawn_surface);
                dot.drawDot(dot, dot.new_x, dot.new_y);
            }
            else
            {
                if (bm_list.Count == 0)
                    return;
                drawn_surface = bm_list[bm_list.Count - 1];
                bm_list.RemoveAt(bm_list.Count - 1);
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.pen = new Pen(Color.Black);
            g.Matrix = Graphics.FromImage(grid_surface);
            g.DrawGridLine();
            g.DrawAxis();
       
            picGrid.Image = grid_surface;
        }   
    }
}
