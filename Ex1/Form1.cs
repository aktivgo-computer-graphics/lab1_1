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
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
        }
        
        private void paintButton_Click(object sender, EventArgs e)
        {
            const int k = 90;
            const double xMin = -5;
            const double xMax = 5;
            const double step = 0.01;
            
            Graph.Clear(Color.White);
            PaintOXY(k);
            
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double x = xMin;
            double y = - x * x + 4;
            int x1 = (int)(x0 + x * k);
            int y1 = (int)(y0 - y * k);
            while (x < xMax)
            {
                x = x + step;
                y = - x * x + 4;
                int x2 = (int)(x0 + x * k);
                int y2 = (int)(y0 - y * k);
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }
        
        private void PaintOXY(int k)
        {
            int xMiddle = ClientSize.Width / 2;
            int yMiddle = ClientSize.Height / 2;
            Graph.DrawLine(MyPen, 0, yMiddle, ClientSize.Width, yMiddle);
            Graph.DrawLine(MyPen, xMiddle, 0, xMiddle, ClientSize.Height);
            for (int x = xMiddle + k; x < ClientSize.Width; x += k)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                Graph.DrawString(((x - xMiddle) / k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x - 5, yMiddle + 15);
            }
            for (int x = xMiddle - k; x > 0; x -= k)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                Graph.DrawString(((x - xMiddle) / k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x - 7, yMiddle + 15);
            }
            for (int y = yMiddle + k; y < ClientSize.Width; y += k)
            {
                Graph.DrawLine(MyPen, xMiddle - 5, y, xMiddle + 5, y);
                Graph.DrawString(((y - xMiddle) / k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, xMiddle + 7, y + 7);
            }
            for (int y = yMiddle - k; y > 0; y -= k)
            {
                Graph.DrawLine(MyPen, xMiddle - 5, y, xMiddle + 5, y);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}