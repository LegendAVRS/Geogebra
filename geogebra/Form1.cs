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
        int threshold = 100;
        int form_width, form_height;

        bool line_connect = true, line_cut = false, round = false;
        bool first_dot = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
    
            form_width = ActiveForm.Width - threshold;
            form_height = ActiveForm.Height;

            grid_surface = new Bitmap(form_width, form_height);
            drawn_surface = new Bitmap(form_width, form_height);
            picGrid.Height = form_height;
            picGrid.Width = form_width;
        }

        void rbtnCheck()
        {
            line_connect = rbtnLine.Checked;
            line_cut = rbtnLineCut.Checked;
        }
        private void rbtnLineCut_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void cbtnRound_CheckedChanged(object sender, EventArgs e)
        {
            round = cbtnRound.Checked;
        }

        private void rbtnLine_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (g.x_list.Count == 0)
                return;
            if (e.X > form_width)
                return;

            dot_surface = new Bitmap(form_width, form_height);
            dot.dot_matrix = Graphics.FromImage(dot_surface);

            if (round)
            {
                dot.new_x = dot.getNearest(g.x_list, g.first_vertical, e.X);
                dot.new_y = dot.getNearest(g.y_list, g.first_horizontal, e.Y);
            }
            else
            {
                dot.new_x = e.X;
                dot.new_y = e.Y;
            }

            if (!dot.first_dot)
            {
                dot.first_dot = false;
                if (dot.new_x == dot.old_x && dot.new_y == dot.old_y)
                    return;
            }

            dot.drawDot(dot, dot.new_x, dot.new_y);
            dot.old_x = dot.new_x;
            dot.old_y = dot.new_y;

            Bitmap final = new Bitmap(form_width, form_height);
      
            Graphics graphics = Graphics.FromImage(final);
            graphics.DrawImage(grid_surface, 0, 0, form_width, form_height);
            graphics.DrawImage(dot_surface, 0, 0, form_width, form_height);
            graphics.DrawImage(drawn_surface, 0, 0, form_width, form_height);
            graphics.Dispose();
   
            picGrid.Image = final;
      
        }

        private void picGrid_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                bm_list.Add((Bitmap)drawn_surface.Clone());
                dot.dot_list.Add(new Point(dot.new_x, dot.new_y));

                dot.dot_matrix = Graphics.FromImage(drawn_surface);
                dot.drawDot(dot, dot.new_x, dot.new_y);

                if (line_connect)
                {
                    if (dot.dot_list.Count() > 1)
                    {
                        dot.dot_matrix.DrawLine(dot.pen, dot.dot_list[dot.dot_list.Count - 2], dot.dot_list[dot.dot_list.Count - 1]);
                    }
                }
                else if (line_cut)
                {
                    if (!first_dot)
                    {
                        dot.dot_matrix.DrawLine(dot.pen, dot.dot_list[dot.dot_list.Count - 2], dot.dot_list[dot.dot_list.Count - 1]);
                        first_dot = true;
                    }
                    else first_dot = false;
                }

            }
            else
            {
                if (bm_list.Count == 0)
                    return;
                drawn_surface = bm_list[bm_list.Count - 1];
                bm_list.RemoveAt(bm_list.Count - 1);
                dot.dot_list.RemoveAt(dot.dot_list.Count - 1);
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
