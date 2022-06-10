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
    public partial class MidpointEllipseAlgorithm : Form
    {
        public MidpointEllipseAlgorithm()
        {
            InitializeComponent();
            this.Text = "Midpoint Ellipse Algorithm";
            #region Config

            picbox.BackColor = Color.Black;
            picbox.BorderStyle = BorderStyle.Fixed3D;


            #endregion
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            clearPBox(picbox);

            if (HasError())
                return;

            int x = picbox.Width / 2;
            int y = picbox.Height / 2;
            int rx = int.Parse(txtbox_rx.Text); 
            int ry = int.Parse(txtbox_ry.Text);


            Ellipse ellipse = new Ellipse(x, y, rx, ry);

            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int twoRx2 = 2 * rx2;
            int twoRy2 = 2 * ry2;
            int p;
            int px = 0;
            int py = twoRx2 * ry;
            ellipse.setCoords(0, ry);

            ellipsePlotPoints(x, y, ellipse);

            /* Region 1 */
            p = round(ry2 - (rx2 * ry) + (0.25 * rx2));
            while (px < py)
            {
                ellipse.incrementX();
                px += twoRy2;
                if (p < 0)
                    p += ry2 + px;
                else
                {
                    ellipse.decrementY();
                    py -= twoRx2;
                    p += ry2 + px - py;
                }
                ellipsePlotPoints(x, y, ellipse);
            }

            /* Region 2 */
            p = round(ry2 * (ellipse.getX() + 0.5) * (ellipse.getX() + 0.5) + rx2 * (ellipse.getY() - 1) * (ellipse.getY() - 1) - rx2 * ry2);
            while (ellipse.getY() > 0)
            {
                ellipse.decrementY();
                py -= twoRx2;
                if (p > 0)
                    p += rx2 - py;
                else
                {
                    ellipse.incrementX();
                    px += twoRy2;
                    p += rx2 - py + px;
                }
                ellipsePlotPoints(x, y, ellipse);
            }
        }

        private bool HasError()
        {
            try
            {
                int.Parse(txtbox_rx.Text);
                int.Parse(txtbox_ry.Text);
                int.Parse(txtbox_xcenter.Text);
                int.Parse(txtbox_ycenter.Text);

            }
            catch (System.FormatException)
            {
                if (txtbox_rx.Text.Equals("") || txtbox_ry.Text.Equals("") || txtbox_xcenter.Text.Equals("") || txtbox_ycenter.Text.Equals(""))
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

        private void ellipsePlotPoints(int xcenter, int ycenter, Ellipse ellipse)
        {

            SetPixel(xcenter + ellipse.getX(), ycenter + ellipse.getY(), Color.LimeGreen);
            SetPixel(xcenter - ellipse.getX(), ycenter + ellipse.getY(), Color.LimeGreen);
            SetPixel(xcenter + ellipse.getX(), ycenter - ellipse.getY(), Color.LimeGreen);
            SetPixel(xcenter - ellipse.getX(), ycenter - ellipse.getY(), Color.LimeGreen);//blue

        }

        private void SetPixel(int x, int y, Color c)
        {

            int Stroke = 1;
            int DeltaX = int.Parse(txtbox_xcenter.Text) * -1;
            int DeltaY = int.Parse(txtbox_ycenter.Text);

            Graphics g = Graphics.FromHwnd(picbox.Handle);
            SolidBrush brush = new SolidBrush(c);
            Point dPoint = new Point(x, y);

            //Move Whole ellipse x & y pos
            dPoint.X = dPoint.X - DeltaX; ;
            dPoint.Y = dPoint.Y - DeltaY;
            Rectangle rect = new Rectangle(dPoint, new Size(Stroke, Stroke));
            g.FillRectangle(brush, rect);
            g.Dispose();
        }


        private void clearPBox(PictureBox PBox)
        {
            Point p1X = new Point(0, PBox.Height / 2);
            Point p2X = new Point(PBox.Width, PBox.Height / 2);
            Point p1Y = new Point(PBox.Width / 2, 0);
            Point p2Y = new Point(PBox.Width / 2, PBox.Height);
            Graphics g = PBox.CreateGraphics();
            g.Clear(Color.Black);
            g.DrawLine(new Pen(Color.White), p1X, p2X);
            g.DrawLine(new Pen(Color.White), p1Y, p2Y);
        }

        private  int round (double a) { return (int)(a + 0.5); }
    }
}
