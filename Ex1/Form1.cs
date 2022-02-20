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
        private int PiMode; // 0 - выкл, 1 - вкл, числа, 2 - вкл, pi числа

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
            PiMode = 2;
        }
        
        private void paintButton_Click(object sender, EventArgs e)
        {
            const int k = 200;
            const double xMin = -2;
            const double xMax = 2;
            const double step = 0.01;
            
            Graph.Clear(Color.White);
            PaintOxy(k);
            
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double x = xMin;
            double y = Math.Sin(3 * x + 1);
            int x1 = (int)(x0 + x * k);
            int y1 = (int)(y0 - y * k);
            while (x < xMax)
            {
                x += step;
                y = Math.Sin(3 * x + 1);
                int x2 = (int)(x0 + x * k);
                int y2 = (int)(y0 - y * k);
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }
        
        private void PaintOxy(int k)
        {
            int xMiddle = ClientSize.Width / 2;
            int yMiddle = ClientSize.Height / 2;
            
            Graph.DrawLine(MyPen, 0, yMiddle, ClientSize.Width, yMiddle);
            Graph.DrawLine(MyPen, xMiddle, 0, xMiddle, ClientSize.Height);
            Graph.DrawString("0", new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, xMiddle + 7, yMiddle + 7);
            
            for (int x = xMiddle + k, i = 0; x < ClientSize.Width; x += k, i++)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                ChooseNumAndDraw(i, false, xMiddle, k, x + 5, yMiddle + 15);
            }
            for (int x = xMiddle - k, i = 0; x > 0; x -= k, i++)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                ChooseNumAndDraw(i, true, xMiddle, k, x - 7, yMiddle + 15);
                //Graph.DrawString(((x - xMiddle) / k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x - 7, yMiddle + 15);
            }
            for (int y = yMiddle + k; y < ClientSize.Width; y += k)
            {
                Graph.DrawLine(MyPen, xMiddle - 5, y, xMiddle + 5, y);
                Graph.DrawString(((y - yMiddle) / -k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, xMiddle + 15, y - 7);
            }
            for (int y = yMiddle - k; y > 0; y -= k)
            {
                Graph.DrawLine(MyPen, xMiddle - 5, y, xMiddle + 5, y);
                Graph.DrawString(((y - yMiddle) / -k).ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, xMiddle + 15, y - 7);
            }
        }

        private void ChooseNumAndDraw(int i, bool minus, int xMiddle, int k, int x, int y)
        {
            string numStr = "";
            double num = 0;
            switch (i)
            {
                case 0:
                    numStr = minus ? "-π/2" : "π/2";
                    num = minus ? -3.14 : 3.14;
                    break;
                case 1:
                    numStr = minus ? "-π" : "π";
                    num = minus ? -6.28 : 6.28;
                    break;
                case 2:
                    numStr = minus ? "-3π/2" : "3π/2";
                    num = minus ? -9.42 : 9.42;
                    break;
                case 3:
                    numStr = minus ? "-2π" : "2π";
                    num = minus ? -12.56 : 12.56;
                    break;
                case 4:
                    numStr = minus ? "-5π/2" : "5π/2";
                    num = minus ? -15.7 : 15.7;
                    break;
            }
            
            switch (PiMode)
            {
                case 0:
                    DrawString(((x - xMiddle) / k).ToString(), x, y);
                    break;
                case 1:
                    DrawString(num.ToString(), x, y);
                    break;
                case 2:
                    DrawString(numStr, x, y);
                    break;
            }
        }

        private void DrawString(string num, int x, int y)
        {
            Graph.DrawString(num, new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}