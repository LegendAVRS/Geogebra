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
        public int getNearest(List<int> p_list, int p)
        {
            int l = 0, r = p_list.Count() - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (p_list[mid] <= p_list[l])
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return l;
        }
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
            for (int i = 0; i < g.x_list.Count(); ++i)
                Console.WriteLine(g.x_list[i]);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
            int dot_x = g.x_list[getNearest(g.x_list, e.X)];
            Console.WriteLine(dot_x);
          //  label1.Text = e.X.ToString();

        }
    }
}
