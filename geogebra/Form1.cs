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
        Dot dot = new Dot();
        Bitmap grid_surface, dot_hover_surface, dot_drawn_surface, drawn_surface, final;
        List<Bitmap> bm_drawn_list = new List<Bitmap>(), bm_dot_list = new List<Bitmap>();
        Graphics drawn_graphic;
        
        int form_width, form_height;

        bool line_connect = true, line_cut = false, round = false, show_dot = true, da_giac = false, cursor = true;
        bool first_dot = true;
        int poly_dot_cnt = 0;

        
        List<int> poly_dot_cnt_list = new List<int>();
        Point middle_point = new Point();

        Bitmap bmp;
        Cursor cur;


        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(12, 12);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawEllipse(new Pen(Color.Black), 0, 0, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Transparent), 0, 0, 10, 10);
            cur = new Cursor(bmp.GetHicon()); 
        }

        private void changeCursor()
        {
            picGrid.Cursor = cur;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {    
            form_width = ActiveForm.Width - GlobalVar.threshold;
            form_height = ActiveForm.Height;

            grid_surface = new Bitmap(form_width, form_height);
            drawn_surface = new Bitmap(form_width, form_height);
            dot_drawn_surface = new Bitmap(form_width, form_height);
            picGrid.Height = form_height;
            picGrid.Width = form_width;

            drawn_graphic = Graphics.FromImage(drawn_surface);
            drawn_graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Dot.dot_drawn_matrix = Graphics.FromImage(dot_drawn_surface);

            final = new Bitmap(form_width, form_height);

            poly_dot_cnt_list.Add(0);
            middle_point = new Point(form_width / 2, form_height / 2);

            changeCursor();
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
            if (cursor) picGrid.Cursor = Cursors.Default;
        }

        private void rbtnDagiac_CheckedChanged(object sender, EventArgs e)
        {
            rbtnCheck();
        }

        private void drawGraphic(Bitmap surface)
        {
            Graphics graphics = Graphics.FromImage(final);
            graphics.DrawImage(surface, 0, 0, form_width, form_height);
            picGrid.Image = final;
        }

        private void redrawGraphic()
        {
            final.Dispose();
            final = new Bitmap(form_width, form_height);
            drawGraphic(grid_surface);
            if (show_dot) drawGraphic(dot_drawn_surface);
            drawGraphic(drawn_surface);
            //if (!cursor && round) drawGraphic(dot_hover_surface);
            picGrid.Image = final;
        }
        private void cbtnShowDot_CheckedChanged(object sender, EventArgs e)
        {
            show_dot = cbtnShowDot.Checked;
            if (show_dot) drawGraphic(dot_drawn_surface);  
            else
            {
                final = new Bitmap(form_width, form_height);
                drawGraphic(grid_surface);               
                drawGraphic(drawn_surface);
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
            if (Grid.x_list.Count == 0)
                return;
            if (e.X > form_width)
                return;

            caseCursor(false);
            /*if (!cursor && round)
            {
                if (!(dot_hover_surface is null)) dot_hover_surface.Dispose();
                dot_hover_surface = new Bitmap(form_width, form_height);
                Dot.dot_hover_matrix = Graphics.FromImage(dot_hover_surface);
                Dot.dot_hover_matrix.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }*/

            if (round && !cursor)
            {
                Dot.new_hover_x = dot.getNearest(Grid.x_list, Grid.first_vertical, e.X);
                Dot.new_hover_y = dot.getNearest(Grid.y_list, Grid.first_horizontal, e.Y);
            }
            else
            {
                Dot.new_hover_x = e.X;
                Dot.new_hover_y = e.Y;
            }

            if (!Dot.first_hover_dot)
            {
                Dot.first_hover_dot = false;
                if (Dot.new_hover_x == Dot.old_hover_x && Dot.new_hover_y == Dot.old_hover_y)
                    return;
            }

            if (!cursor && round)
            {
                //Dot.drawDot(true, Dot.new_hover_x, Dot.new_hover_y);
                Dot.old_hover_x = Dot.new_hover_x;
                Dot.old_hover_y = Dot.new_hover_y;
            }

            lblCoord.Text = "X: " + ((float)(Dot.new_hover_x - middle_point.X) / 50).ToString("0.0") + 
                            " Y: " + (-(float)(Dot.new_hover_y - middle_point.Y) / 50).ToString("0.0");

            /*if (round)
            {
                redrawGraphic();
            }            */
        }

        bool caseCursor(bool clicked)
        {
            if (cursor)
            {
                Poly polygon_click = Poly.GetClickPoly(Dot.new_hover_x, Dot.new_hover_y);

                if (!(polygon_click.poly_dot_list is null) && clicked)
                {
                    lblData.Text = "Area: " + polygon_click.area.ToString("0.00") + "\n"
                                    + "Perimeter: " + polygon_click.perimeter.ToString("0.00");
                }

                Line line_click = Line.GetLineClick(Dot.new_hover_x, Dot.new_hover_y);

                if (line_click.length != 0 && clicked)
                {
                    lblData.Text = "Length: " + line_click.length.ToString("0.00");
                }

                if (line_click.length != 0 || !(polygon_click.poly_dot_list is null)) picGrid.Cursor = Cursors.Hand;
                else picGrid.Cursor = Cursors.Default;

                return true;
            }
            else changeCursor();
            return false;
        }
        
        bool caseLineConnect()
        {
            if (line_connect)
            {
                Dot.pen.Color = Color.Black;
                if (Dot.dot_list.Count() > 1)
                {
                    drawn_graphic.DrawLine(Dot.pen, Dot.dot_list[Dot.dot_list.Count - 2], Dot.dot_list[Dot.dot_list.Count - 1]);
                    new Line(Dot.dot_list[Dot.dot_list.Count - 2], Dot.dot_list[Dot.dot_list.Count - 1]);                    
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
                    new Line(Dot.dot_list[Dot.dot_list.Count - 2], Dot.dot_list[Dot.dot_list.Count - 1]);
                    drawn_graphic.DrawLine(Dot.pen, Dot.dot_list[Dot.dot_list.Count - 2], Dot.dot_list[Dot.dot_list.Count - 1]);
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
                    List<Point> poly_dot_list = new List<Point>();
                    for (int i = 1; i <= (int)numDagiac.Value; ++i)
                        poly_dot_list.Add(Dot.dot_list[Dot.dot_list.Count - i]);

                    Poly new_poly = new Poly(poly_dot_list, Poly.getPerimeter(poly_dot_list), Poly.getArea(poly_dot_list));
                    Poly.poly_drawn_list.Add(new_poly);

                    drawn_graphic.DrawPolygon(Dot.pen, poly_dot_list.ToArray());
                    drawn_graphic.FillPolygon(Poly.brush, poly_dot_list.ToArray());
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

                bm_drawn_list.Add((Bitmap)drawn_surface.Clone());
                bm_dot_list.Add((Bitmap)dot_drawn_surface.Clone());

                Dot.dot_drawn_matrix = Graphics.FromImage(dot_drawn_surface);
                drawn_graphic = Graphics.FromImage(drawn_surface);

                Dot.dot_drawn_matrix.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                drawn_graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                Dot.dot_list.Add(new Point(Dot.new_hover_x, Dot.new_hover_y));

                Dot.brush.Color = Color.Black;
                Dot.drawDot(false, Dot.new_hover_x, Dot.new_hover_y);

                if (caseLineConnect())
                {
                    redrawGraphic();
                    return;
                }
                if (caseLineCut())
                {
                    redrawGraphic();
                    return;
                }
                if (caseDagiac())
                {
                    redrawGraphic();
                    return;
                }
            }
            else
            {
                if (bm_drawn_list.Count == 0)
                    return;

                drawn_surface = bm_drawn_list[bm_drawn_list.Count - 1];
                bm_drawn_list.RemoveAt(bm_drawn_list.Count - 1);

                dot_drawn_surface = bm_dot_list[bm_dot_list.Count - 1];
                bm_dot_list.RemoveAt(bm_dot_list.Count - 1);

                Dot.dot_list.RemoveAt(Dot.dot_list.Count - 1);
                if ((cursor || da_giac) && poly_dot_cnt_list.Count > 1)
                {
                    poly_dot_cnt_list.RemoveAt(poly_dot_cnt_list.Count - 1);
                    if (poly_dot_cnt == 0)
                    {
                        if (Poly.poly_drawn_list.Count != 0) Poly.poly_drawn_list.RemoveAt(Poly.poly_drawn_list.Count - 1);
                    }
                    poly_dot_cnt = poly_dot_cnt_list[poly_dot_cnt_list.Count - 1];                    
                }
                redrawGraphic();
            }           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Grid.pen = new Pen(Color.Black);
            Grid.Matrix = Graphics.FromImage(grid_surface);
            Grid.DrawGridLine();
            Grid.DrawAxis();

            //drawGraphic(grid_surface);
       
            picGrid.Image = grid_surface;
        }   
    }
}
