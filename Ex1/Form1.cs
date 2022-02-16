using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form
    {
        private Graphics Graph;
        private Pen MyPen;

        public Form1()
        {
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Magenta);
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            const double xMin = -5;
            const double xMax = 5;
            const double step = 0.01;
            const double k = 5.5;
            double x = xMin;
            double y = - x * x + 3;
            int x1 = (int)(x0 + x * k);
            int y1 = (int)(y0 - y * k);
            while (x < xMax)
            {
                x = x + step;
                y = - x * x + 3;
                int x2 = (int)(x0 + x * k);
                int y2 = (int)(y0 - y * k);
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}