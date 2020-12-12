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
        int old_dot_x, old_dot_y;
        Bitmap grid_surface, dot_surface;

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
           
            
         
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            dot_surface = new Bitmap(ActiveForm.Width, ActiveForm.Height);
            dot.dot_matrix = Graphics.FromImage(dot_surface);

            int new_dot_x = dot.getNearest(g.x_list, e.X);
            int new_dot_y = dot.getNearest(g.y_list, e.Y);
            if (!dot.first_dot)
            {
                dot.first_dot = false;
                if (new_dot_x == old_dot_x && new_dot_y == old_dot_y)
                    return;
            }

            dot.drawDot(dot, new_dot_x, new_dot_y);
            old_dot_x = new_dot_x;
            old_dot_y = new_dot_y;

            Bitmap final = new Bitmap(ActiveForm.Width, ActiveForm.Height);
      
            Graphics new_g = Graphics.FromImage(final);
            new_g.DrawImage(grid_surface, 0, 0, ActiveForm.Width, ActiveForm.Height);
            new_g.DrawImage(dot_surface, 0, 0, ActiveForm.Width, ActiveForm.Height);
            new_g.Dispose();
   
            pictureBox1.Image = final;
      
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g.pen = new Pen(Color.Black);
            g.Matrix = Graphics.FromImage(grid_surface);
            g.DrawGridLine();
            g.DrawAxis();
       
            pictureBox1.Image = grid_surface;


        }    

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            

        }
    }
}
