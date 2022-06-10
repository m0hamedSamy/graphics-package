using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsPackage
{
    public partial class Bresenham : Form
    {
        public Bresenham()
        {
            InitializeComponent();
            this.Text = "Bresenham Algorithm";

            linePanel.BackColor = Color.Black;
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            if (HasError())
                return;

            int x1 = 250 + int.Parse(X1.Text);
            int y1 = 250 + int.Parse(Y1.Text);
            int x2 = 250 + int.Parse(X2.Text);
            int y2 = 250 + int.Parse(Y2.Text);
            Point p1X = new Point(0, linePanel.Height / 2);
            Point p2X = new Point(linePanel.Width, linePanel.Height / 2);
            Point p1Y = new Point(linePanel.Width / 2, 0);
            Point p2Y = new Point(linePanel.Width / 2, linePanel.Height);
            Graphics g = linePanel.CreateGraphics();
          
            g.DrawLine(new Pen(Color.White), p1X, p2X);
            g.DrawLine(new Pen(Color.White), p1Y, p2Y);
            BresenhamAlgo(x1,y1 ,x2 ,y2);
        }

        private bool HasError()
        {
            try
            {
                int.Parse(X1.Text);
                int.Parse(Y1.Text);
                int.Parse(X2.Text);
                int.Parse(Y2.Text);

            }
            catch (System.FormatException)
            {
                if (X1.Text.Equals("") || X2.Text.Equals("") || Y1.Text.Equals("") || Y2.Text.Equals(""))
                {
                    MessageBox.Show("Missing An Input. Please fill all text fields", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Wrong input type. Please enter only integer numbers", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                return true;
            }

            return false;
        }

        public void BresenhamAlgo(int x0, int y0, int xEnd, int yEnd)
        {
            int x, y;
            int Dx = Math.Abs(xEnd - x0);
            int Dy = Math.Abs(yEnd - y0);
            int Dp = (2 * Dy) - Dx;
            int twoDy = 2 * Dy;
            int twoDyMinusDx = 2 * (Dy - Dx);
            if (x0 > xEnd)
            {
                x = xEnd;
                y = yEnd;
                xEnd = x0;

            }
            else
            {
                x = x0;
                y = y0;
            }
            SetPixel(x, y , Color.LimeGreen);
            while (x < xEnd)
            {
                x++;
                if (Dp < 0)
                    Dp += twoDy;
                else
                {
                    y++;
                    Dp += twoDyMinusDx;
                }

                SetPixel(x, y, Color.LimeGreen);




            }
        }
        private void SetPixel(int cx, int cy, Color c, int Stroke = 3)
        {


            int DeltaX = 2;
            int DeltaY = 2;

            Graphics g = Graphics.FromHwnd(linePanel.Handle);
            SolidBrush brush = new SolidBrush(c);
            Point dPoint = new Point(cx, (linePanel.Height - cy));

            //Move Whole circle x & y pos
            dPoint.X = dPoint.X - DeltaX; ;
            dPoint.Y = dPoint.Y - DeltaY;
            Rectangle rect = new Rectangle(dPoint, new Size(Stroke, Stroke));
            
            g.FillRectangle(brush, rect);
            g.Dispose();
        }

 

        private void linePanel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = linePanel.CreateGraphics();
            g.Clear(Color.Black);
        }
    }
}
