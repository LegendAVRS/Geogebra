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
        int old_dot_x, old_dot_y;
        Bitmap grid_surface, dot_surface;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            picGrid.Width = ActiveForm.Width;
            picGrid.Height = ActiveForm.Height;
            grid_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            g.pen = new Pen(Color.Black);
            g.Matrix = Graphics.FromImage(grid_surface);
            g.DrawGridLine();
            g.DrawAxis();
            /*   Bitmap bitmap = new Bitmap(Form1.ActiveForm.Width, Form1.ActiveForm.Height);
               Rectangle rect = new Rectangle(0, 0, ActiveForm.Width, ActiveForm.Height);
               this.DrawToBitmap(bitmap, rect);
               bitmap.Save("Grid.bmp");*/

            picGrid.Image = grid_surface;

            picDot.Width = ActiveForm.Width;
            picDot.Height = ActiveForm.Height;

            dot_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            new_dot.dot_matrix = Graphics.FromImage(grid_surface);



        }

        private void picDot_MouseMove(object sender, MouseEventArgs e)
        {
            if (g.x_list.Count() == 0)
                return;
            int new_dot_x = new_dot.getNearest(g.x_list, e.X);
            int new_dot_y = new_dot.getNearest(g.y_list, e.Y);
            if (!new_dot.first_dot && (new_dot_x != old_dot_x || new_dot_y != old_dot_y))
            {
                new_dot.deleteDot(new_dot, old_dot_x, old_dot_y);
            }
            old_dot_x = new_dot_x;
            old_dot_y = new_dot_y;
            new_dot.drawDot(new_dot, new_dot_x, new_dot_y);
            new_dot.first_dot = false;
            picDot.Image = dot_surface;
        }

        private void picGrid_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
