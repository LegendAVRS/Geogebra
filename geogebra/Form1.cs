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
        
        int threshold = 150;
        int form_width, form_height;

        bool line_connect = true, line_cut = false, round = false, show_dot = true, da_giac = false, cursor = true;
        bool first_dot = true;
        int poly_dot_cnt = 0;
        SolidBrush poly_brush = new SolidBrush(Color.FromArgb(128, 176, 196, 222));
        List<int> poly_dot_cnt_list = new List<int>();
        Poly poly = new Poly();
        Point middle_point = new Point();

        


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
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

            poly_dot_cnt_list.Add(0);
            middle_point = new Point(form_width / 2, form_height / 2);
        }

        void rbtnCheck()
        {
            line_connect = rbtnLine.Checked;
            line_cut = rbtnLineCut.Checked;
            da_giac = rbtnDagiac.Checked;
            cursor = rbtnCursor.Checked;
        }
        private void rbtnLineCut_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void rbtnCursor_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void rbtnDagiac_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void cbtnShowDot_CheckedChanged(object sender, EventArgs e)
        {
            show_dot = cbtnShowDot.Checked;
            dot.dot_matrix = Graphics.FromImage(drawn_surface);
            if (show_dot)
            {
                dot.pen.Color = Color.Black;
                dot.brush.Color = Color.Black;
            }
            else
            {
                dot.pen.Color = this.BackColor;
                dot.brush.Color = this.BackColor;
            }
                
            for (int i = 0; i < dot.dot_list.Count; ++i)
            { 
                dot.drawDot(dot, dot.dot_list[i].X, dot.dot_list[i].Y);
            }
            
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

            caseCursor(false);
          
            dot_surface = new Bitmap(form_width, form_height);
            dot.dot_matrix = Graphics.FromImage(dot_surface);
            dot.dot_matrix.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

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

            dot.brush.Color = Color.FromArgb(128, 211, 211, 211);
            dot.drawDot(dot, dot.new_x, dot.new_y);
            dot.old_x = dot.new_x;
            dot.old_y = dot.new_y;

            lblCoord.Text = "X: " + ((float)(dot.new_x - middle_point.X) / 50).ToString("0.0") + 
                            " Y: " + (-(float)(dot.new_y - middle_point.Y) / 50).ToString("0.0");

            Bitmap final = new Bitmap(form_width, form_height);
      
            Graphics graphics = Graphics.FromImage(final);
            graphics.DrawImage(grid_surface, 0, 0, form_width, form_height);
            if (!cursor) graphics.DrawImage(dot_surface, 0, 0, form_width, form_height);
            graphics.DrawImage(drawn_surface, 0, 0, form_width, form_height);
            graphics.Dispose();
   
            picGrid.Image = final;      
        }

        bool caseCursor(bool clicked)
        {
            if (cursor)
            {
                Poly.Polygon polygon_click = poly.GetClickPoly(dot.new_x, dot.new_y);
                if (!(polygon_click.poly_dot_list is null)) Cursor.Current = Cursors.Hand;
                if (!(polygon_click.poly_dot_list is null) && clicked)
                {
                    lblData.Text = "Area: " + polygon_click.area.ToString("0.00") + "\n"
                                    + "Perimeter: " + polygon_click.perimeter.ToString("0.00");
               //     Console.WriteLine("Area: " + polygon_click.area.ToString());
               //     Console.WriteLine("Perimeter: " + polygon_click.perimeter.ToString());
                }

                Line line_click = Line.GetLineClick(dot.new_x, dot.new_y);
                if (line_click.length != 0) Cursor.Current = Cursors.Hand;
                if (line_click.length != 0 && clicked)
                {
                    lblData.Text = "Length: " + line_click.length.ToString();                    
                }

                return true;
            }
            return false;
        }
        
        bool caseLineConnect()
        {
            if (line_connect)
            {
                dot.pen.Color = Color.Black;
                if (dot.dot_list.Count() > 1)
                {
                    dot.dot_matrix.DrawLine(dot.pen, dot.dot_list[dot.dot_list.Count - 2], dot.dot_list[dot.dot_list.Count - 1]);
                    new Line(dot.dot_list[dot.dot_list.Count - 2], dot.dot_list[dot.dot_list.Count - 1]);
                }                
                return true;
            }            
            return false;
        }

        bool caseLineCut()
        {
            if (line_cut)
            {
                if (!first_dot)
                {
                    dot.dot_matrix.DrawLine(dot.pen, dot.dot_list[dot.dot_list.Count - 2], dot.dot_list[dot.dot_list.Count - 1]);
                    first_dot = true;                    
                }
                else first_dot = false;
                return true;
            }
            return false;
        }

        bool caseDagiac()
        {
            if (da_giac)
            {
                ++poly_dot_cnt;
                poly_dot_cnt_list.Add(poly_dot_cnt % (int)numDagiac.Value);

                if (poly_dot_cnt == (int)numDagiac.Value)
                {
                    List<Point> poly_list = new List<Point>();
                    for (int i = 1; i <= (int)numDagiac.Value; ++i)
                        poly_list.Add(dot.dot_list[dot.dot_list.Count - i]);

                    Poly.Polygon new_poly = new Poly.Polygon();
                    new_poly.poly_dot_list = poly_list;
                    new_poly.area = poly.getArea(poly_list);
                    new_poly.perimeter = poly.getPerimeter(poly_list);
                    poly.poly_drawn_list.Add(new_poly);


                    dot.dot_matrix.DrawPolygon(dot.pen, poly_list.ToArray());
                    dot.dot_matrix.FillPolygon(poly_brush, poly_list.ToArray());
                    poly_dot_cnt = 0;
                }
                return true;
            }
            return false;
        }
        private void picGrid_Click(object sender, EventArgs e)
        {            
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                if (caseCursor(true)) return;

                bm_list.Add((Bitmap)drawn_surface.Clone());
                dot.dot_list.Add(new Point(dot.new_x, dot.new_y));

                dot.dot_matrix = Graphics.FromImage(drawn_surface);
                dot.dot_matrix.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                dot.brush.Color = Color.Black;
                if (show_dot) dot.drawDot(dot, dot.new_x, dot.new_y);       

               // Color temp = new Color();
               // temp = dot.pen.Color;

                if (caseLineConnect()) return;
                if (caseLineCut()) return;
                if (caseDagiac()) return;        

               // dot.pen.Color = temp;
            }
            else
            {
                if (bm_list.Count == 0)
                    return;
                drawn_surface = bm_list[bm_list.Count - 1];
                bm_list.RemoveAt(bm_list.Count - 1);
                dot.dot_list.RemoveAt(dot.dot_list.Count - 1);
                if (cursor || da_giac && poly_dot_cnt_list.Count > 1)
                {
                    poly_dot_cnt_list.RemoveAt(poly_dot_cnt_list.Count - 1);
                    if (poly_dot_cnt == 0)
                    {
                        if (poly.poly_drawn_list.Count != 0) poly.poly_drawn_list.RemoveAt(poly.poly_drawn_list.Count - 1);//poly.poly_drawn_list.Count - 1)
                    }
                    poly_dot_cnt = poly_dot_cnt_list[poly_dot_cnt_list.Count - 1];                    
                }
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
