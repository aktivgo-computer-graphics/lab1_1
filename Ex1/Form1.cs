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
        private bool PiMode;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
            PiMode = true;
        }
        
        private void paintButton_Click(object sender, EventArgs e)
        {
            const int k = 200;
            const int xMin = -2;
            const int xMax = 2;
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

            int i = 0;
            for (int x = xMiddle + k; x < ClientSize.Width; x += k, i++)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                ChooseNumAndDraw(i, false, xMiddle, k, x + 5, yMiddle + 15);
            }
            i = 0;
            for (int x = xMiddle - k; x > 0; x -= k, i++)
            {
                Graph.DrawLine(MyPen, x, yMiddle - 5, x, yMiddle + 5);
                ChooseNumAndDraw(i, true, xMiddle, k, x - 7, yMiddle + 15);
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
            if (PiMode)
            {
                string piNum = "";
                switch (i)
                {
                    case 0:
                        piNum = minus ? "-π/2" : "π/2";
                        break;
                    case 1:
                        piNum = minus ? "-π" : "π";
                        break;
                    case 2:
                        piNum = minus ? "-3π/2" : "3π/2";
                        break;
                    case 3:
                        piNum = minus ? "-2π" : "2π";
                        break;
                    case 4:
                        piNum = minus ? "-5π/2" : "5π/2";
                        break;
                }
                Graph.DrawString(piNum, new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x, y);
                return;
            }
            else
            {
                string piNum = "";
                switch (i)
                {
                    case 0:
                        piNum = minus ? (-Math.Round(Math.PI / 2, 2)).ToString() : Math.Round(Math.PI / 2, 2).ToString();
                        break;
                    case 1:
                        piNum = minus ? (-Math.Round(Math.PI, 2)).ToString() : Math.Round(Math.PI, 2).ToString();
                        break;
                    case 2:
                        piNum = minus ? (-Math.Round(3 * Math.PI, 2)).ToString() : Math.Round(3 * Math.PI, 2).ToString();
                        break;
                    case 3:
                        piNum = minus ? (-Math.Round(2 * Math.PI, 2)).ToString() : Math.Round(2 * Math.PI, 2).ToString();
                        break;
                    case 4:
                        piNum = minus ? (-Math.Round(5 * Math.PI, 2)).ToString() : Math.Round(5 * Math.PI, 2).ToString();
                        break;
                }
                Graph.DrawString(piNum, new Font(FontFamily.GenericSansSerif, 10), Brushes.Black, x, y);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}