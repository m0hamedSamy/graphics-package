using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsPackage
{
    public partial class TwoDimensionalTransformations : Form
    {
        public TwoDimensionalTransformations()
        {
            InitializeComponent();

            #region Config

            picbox.BackColor = Color.Black;
            picbox.BorderStyle = BorderStyle.Fixed3D;


            #endregion
        }


        private void btn_draw_Click(object sender, EventArgs e)
        {
            clearPBox(picbox);


            if (HasError(GetTextBoxes()))
            {
                return;
            }
            else
            {
                Draw(GetAvailablePionts(), Color.Blue);
            }

        }

        private List<TextBox> GetTextBoxes()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(txtbox_x1);
            textBoxes.Add(txtbox_y1);
            textBoxes.Add(txtbox_x2);
            textBoxes.Add(txtbox_y2);
            textBoxes.Add(txtbox_x3);
            textBoxes.Add(txtbox_y3);
            textBoxes.Add(txtbox_x4);
            textBoxes.Add(txtbox_y4);

            return textBoxes;
        }

        private int CountPoints(List<TextBox> textBoxes)
        {
            int count = 0;

            for (int i = 0, j = 0; i < textBoxes.Count / 2; i++, j += 2)
            {
                try
                {
                    int.Parse(textBoxes[j].Text);
                    int.Parse(textBoxes[j + 1].Text);
                }
                catch
                {
                    break;
                }

                count++;
            }

            return count;
        }

        private bool HasError(List<TextBox> textBoxes)
        {

            string anyDigitPattern = @"(\d)+";
            string anyNonDigitPattern = @"(\D)+";
            Regex rgxNonDigit = new Regex(anyNonDigitPattern);
            Regex rgxDigit = new Regex(anyDigitPattern);

            int firstEmptyPoint = -1;

            for (int i = 0, j = 0; i < textBoxes.Count / 2; i++, j += 2)
            {
                try
                {
                    int.Parse(textBoxes[j].Text);
                    int.Parse(textBoxes[j + 1].Text);
                }
                catch
                {
                    if (textBoxes[j].Text.Equals("") || textBoxes[j + 1].Text.Equals(""))
                    {
                        // if the first point or any other point doesn't have either x or y
                        if (i == 0 || !(textBoxes[j].Text.Equals("") && textBoxes[j + 1].Text.Equals("")))
                        {
                            MessageBox.Show($"Missing an input at point number {i + 1}.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // if there is an empty point other than the first one
                        else
                        {
                            firstEmptyPoint = j;
                            break;
                        }

                    }
                    else
                    {
                        // if the input contains non-digit value
                        if (rgxNonDigit.IsMatch(textBoxes[j].Text) || rgxNonDigit.IsMatch(textBoxes[j + 1].Text))
                        {
                            MessageBox.Show($"Wrong input type at point number {i + 1}. Please enter only integer numbers", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    return true;
                }


            }

            // if there is an empty point
            if (firstEmptyPoint != -1)
            {
                for (int i = firstEmptyPoint + 1; i < textBoxes.Count; i++)
                {
                    // if there is an input after an empty point
                    if (rgxNonDigit.IsMatch(textBoxes[i].Text) || rgxDigit.IsMatch(textBoxes[i].Text))
                    {
                        MessageBox.Show($"Missing an input after point number {firstEmptyPoint / 2}.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
            }

            // if there are three points that doesn't make a right triangle
            if (CountPoints(textBoxes) == 3 && !IsTriangle())
            {
                MessageBox.Show($"Can't form a valid triangle with these points. Please adjust the values.", "BAD POINTS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;

        }

        private void DrawLine(Point pStart, Point pEnd, Color c)
        {
            Graphics g = Graphics.FromHwnd(picbox.Handle);
            Pen pen = new Pen(c);
            Point origin = new Point(picbox.Width / 2, picbox.Height / 2);
            pStart.X += origin.X;
            pStart.Y = origin.Y - pStart.Y;
            pEnd.X += origin.X;
            pEnd.Y = origin.Y - pEnd.Y;
            g.DrawLine(pen, pStart, pEnd);
        }

        private void DrawTriangle(List<Point> points, Color c)
        {

            DrawLine(points[0], points[1], c);

            DrawLine(points[1], points[2], c);

            DrawLine(points[2], points[0], c);
        }

        private void DrawRectangle(List<Point> points, Color c)
        {
            DrawLine(points[0], points[1], c);

            DrawLine(points[1], points[2], c);

            DrawLine(points[2], points[3], c);

            DrawLine(points[3], points[0], c);
        }

        private void Draw(List<Point> points, Color c)
        {
            
            switch (points.Count)
            {

                case 1:
                    DrawLine(points[0], points[0], c);
                    break;

                case 2:
                    DrawLine(points[0], points[1], c);
                    break;

                case 3:
                    DrawTriangle(points, c);
                    break;

                case 4:
                    DrawRectangle(points, c);
                    break;
            }
        }

        private bool IsTriangle()
        {
            double X2MinusX1_sqr_d1 = Math.Pow((int.Parse(txtbox_x2.Text) - int.Parse(txtbox_x1.Text)), 2);
            double Y2MinusY1_sqr_d1 = Math.Pow((int.Parse(txtbox_y2.Text) - int.Parse(txtbox_y1.Text)), 2);
            double X2MinusX1_sqr_d2 = Math.Pow((int.Parse(txtbox_x3.Text) - int.Parse(txtbox_x2.Text)), 2);
            double Y2MinusY1_sqr_d2 = Math.Pow((int.Parse(txtbox_y3.Text) - int.Parse(txtbox_y2.Text)), 2);
            double X2MinusX1_sqr_d3 = Math.Pow((int.Parse(txtbox_x3.Text) - int.Parse(txtbox_x1.Text)), 2);
            double Y2MinusY1_sqr_d3 = Math.Pow((int.Parse(txtbox_y3.Text) - int.Parse(txtbox_y1.Text)), 2);

            int distance1 = (int)(Math.Round(Math.Sqrt(X2MinusX1_sqr_d1 + Y2MinusY1_sqr_d1)));
            int distance2 = (int)(Math.Round(Math.Sqrt(X2MinusX1_sqr_d2 + Y2MinusY1_sqr_d2)));
            int distance3 = (int)(Math.Round(Math.Sqrt(X2MinusX1_sqr_d3 + Y2MinusY1_sqr_d3)));

            if (   (distance1 + distance2) > distance3
                && (distance2 + distance3) > distance1
                && (distance1 + distance3) > distance2)
            {
                return true;
            }
            else
            {
                return false;
            }
           
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

        private List<Point> GetAvailablePionts()
        {
            List<Point> points = new List<Point>();

            List<TextBox> textBoxes = GetTextBoxes();

            int numOfPoints = CountPoints(textBoxes);

            for(int i=0; i<numOfPoints*2; i+=2)
            {
                points.Add(new Point(int.Parse(textBoxes[i].Text), int.Parse(textBoxes[i + 1].Text)));
            }

            return points;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearPBox(picbox);
        }

        private void btn_translation_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            try
            {
                int.Parse(txtbox_op_x.Text);
                int.Parse(txtbox_op_y.Text);
            }
            catch
            {
                if (txtbox_op_x.Text.Equals("") || txtbox_op_y.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that both X and Y have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter only integer numbers", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            List<Point> points = GetAvailablePionts();
            List<Point> translatedPoints = new List<Point>();

            foreach(var point in points)
            {
                translatedPoints.Add(Translate2D(point, int.Parse(txtbox_op_x.Text), int.Parse(txtbox_op_y.Text)));
            }

            Draw(translatedPoints, Color.Red);

        }

        private double[][] GetMatrix(int rows, int cols)
        {
            double[][] matrix = new double[rows][];
            for(int i=0; i<rows; i++)
            {
                matrix[i] = new double[cols];
            }

            return matrix;
        }

        private double[][] GetPointMatrix(Point point)
        {
            double[][] matrix = new double[3][];
            for (int i = 0; i < 3; i++)
            {
                matrix[i] = new double[3];
            }

            matrix[0][0] = point.X;
            matrix[1][0] = point.Y;
            matrix[2][0] = 1;

            return matrix;
        }

        /* Construct the 3 x 3 identity matrix. */
        private void SetIdentityMatrix(double[][] matrix)
        {
            int row, col;
            for (row = 0; row < 3; row++)
                for (col = 0; col < 3; col++)
                    matrix[row][col] = (row == col) ? 1 : 0;
        }

        /* Premultiply matrix m1 times matrix m2, store result in m2. */
        private void PreMultiplyMatrix(double[][] m1, double[][] m2)
        {
            int row, col;
            double[][] matTemp = GetMatrix(3, 3);
            for (row = 0; row < 3; row++)
                for (col = 0; col < 3; col++)
                    matTemp[row][col] = m1[row][0] * m2[0][col] + m1[row][1] *
                    m2[1][col] + m1[row][2] * m2[2][col];

            for (row = 0; row < 3; row++)
                for (col = 0; col < 3; col++)
                    m2[row][col] = matTemp[row][col];
        }

        private Point Translate2D(Point point, double tx, double ty)
        {
            double[][] matTransl = GetMatrix(3,3);
            /* Initialize translation matrix to identity. */
            SetIdentityMatrix(matTransl);

            matTransl[0][2] = tx;
            matTransl[1][2] = ty;


            double[][] translatedPointMat = GetPointMatrix(point);

            PreMultiplyMatrix(matTransl, translatedPointMat);

            return new Point((int)(translatedPointMat[0][0]), (int)(translatedPointMat[1][0]));
        }

        private Point Rotate2D(Point point, Point pivotPt, double theta)
        {
            double[][] matRot = GetMatrix(3, 3);
            /* Initialize rotation matrix to identity. */
            SetIdentityMatrix(matRot);
            
            matRot[0][0] = Math.Cos(Math.PI / 180 * theta);
            matRot[0][1] = -Math.Sin(Math.PI / 180 * theta);
            matRot[0][2] = pivotPt.X * (1 - Math.Cos(Math.PI / 180 * theta)) + pivotPt.Y * Math.Sin(Math.PI / 180 * theta);
            matRot[1][0] = Math.Sin(Math.PI / 180 * theta);
            matRot[1][1] = Math.Cos(Math.PI / 180 * theta);
            matRot[1][2] = pivotPt.Y * (1 - Math.Cos(Math.PI / 180 * theta)) - pivotPt.X * Math.Sin(Math.PI / 180 * theta);

            double[][] rotatedPointMat = GetPointMatrix(point);

            PreMultiplyMatrix(matRot, rotatedPointMat);

            return new Point((int)(rotatedPointMat[0][0]), (int)(rotatedPointMat[1][0]));
        }


        private Point Scale2D(Point point, double sx, double sy)
        {

            double[][] matScale = GetMatrix(3, 3);

            /* Initialize scaling matrix to identity. */
            SetIdentityMatrix(matScale);

            matScale[0][0] = sx;
            matScale[1][1] = sy;

            double[][] scaledPointMat = GetPointMatrix(point);

            PreMultiplyMatrix(matScale, scaledPointMat);

            return new Point((int)(scaledPointMat[0][0]), (int)(scaledPointMat[1][0]));
        }

        private void btn_rotation_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            try
            {
                double.Parse(txtbox_op_angle.Text);
                int.Parse(txtbox_op_pivot_x.Text);
                int.Parse(txtbox_op_pivot_y.Text);
            }
            catch
            {
                if (txtbox_op_angle.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that the angle has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtbox_op_pivot_x.Text.Equals("") || txtbox_op_pivot_y.Text.Equals(""))
                {
                    if(!(txtbox_op_pivot_x.Text.Equals("") && txtbox_op_pivot_y.Text.Equals("")))
                    {
                        MessageBox.Show($"Missing An Input. Please make sure that both X and Y of the pivot point have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtbox_op_pivot_x.Text = "0";
                        txtbox_op_pivot_y.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Point pivotPt = new Point(int.Parse(txtbox_op_pivot_x.Text), int.Parse(txtbox_op_pivot_y.Text));
            List<Point> points = GetAvailablePionts();
            List<Point> rotatedPoints = new List<Point>();

            foreach (var point in points)
            {
                rotatedPoints.Add(Rotate2D(point, pivotPt, double.Parse(txtbox_op_angle.Text)));
            }

            Draw(rotatedPoints, Color.Red);
        }

        private void btn_scaling_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            try
            {
                double.Parse(txtbox_op_x.Text);
                double.Parse(txtbox_op_y.Text);
            }
            catch
            {
                if (txtbox_op_x.Text.Equals("") || txtbox_op_y.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that both X and Y have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            List<Point> points = GetAvailablePionts();
            List<Point> scaledPoints = new List<Point>();

            foreach (var point in points)
            {
                scaledPoints.Add(Scale2D(point, double.Parse(txtbox_op_x.Text), double.Parse(txtbox_op_y.Text)));
            }

            Draw(scaledPoints, Color.Red);
        }

        private void btn_shear_x_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            try
            {
                double.Parse(txtbox_shx.Text);
            }
            catch
            {
                if (txtbox_shx.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that ShX has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter only integer numbers.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            List<Point> points = GetAvailablePionts();
            List<Point> shearedPoints = new List<Point>();

            foreach (var point in points)
            {
                shearedPoints.Add(ShearX(point, double.Parse(txtbox_shx.Text)));
            }

            Draw(shearedPoints, Color.Red);
        }

        private void btn_ref_x_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            List<Point> points = GetAvailablePionts();
            List<Point> scaledPoints = new List<Point>();

            foreach (var point in points)
            {
                scaledPoints.Add(Scale2D(point, 1, -1));
            }

            Draw(scaledPoints, Color.Red);
        }

        private void btn_ref_y_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            List<Point> points = GetAvailablePionts();
            List<Point> scaledPoints = new List<Point>();

            foreach (var point in points)
            {
                scaledPoints.Add(Scale2D(point, -1, 1));
            }

            Draw(scaledPoints, Color.Red);
        }

        private void btn_ref_origin_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            List<Point> points = GetAvailablePionts();
            List<Point> scaledPoints = new List<Point>();

            foreach (var point in points)
            {
                scaledPoints.Add(Scale2D(point, -1, -1));
            }

            Draw(scaledPoints, Color.Red);
        }

        private Point ShearY(Point point, double shY)
        {

            double[][] matShearY = GetMatrix(3, 3);
            SetIdentityMatrix(matShearY);

            matShearY[1][0] = shY;

            double[][] shearedPointMat = GetPointMatrix(point);
            PreMultiplyMatrix(matShearY, shearedPointMat);

            return new Point((int)(shearedPointMat[0][0]), (int)(shearedPointMat[1][0]));
        }

        private Point ShearX(Point point, double shX)
        {

            double[][] matShearX = GetMatrix(3, 3);
            SetIdentityMatrix(matShearX);

            matShearX[0][1] = shX;

            double[][] shearedPointMat = GetPointMatrix(point);
            PreMultiplyMatrix(matShearX, shearedPointMat);

            return new Point((int)(shearedPointMat[0][0]), (int)(shearedPointMat[1][0]));
        }

        private void btn_shear_y_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            clearPBox(picbox);
            Draw(GetAvailablePionts(), Color.Blue);

            try
            {
                double.Parse(txtbox_shy.Text);
            }
            catch
            {
                if (txtbox_shx.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that ShY has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter only integer numbers.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            List<Point> points = GetAvailablePionts();
            List<Point> shearedPoints = new List<Point>();

            foreach (var point in points)
            {
                shearedPoints.Add(ShearY(point, double.Parse(txtbox_shy.Text)));
            }

            Draw(shearedPoints, Color.Red);
        }
    }
}
