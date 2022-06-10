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
    public partial class ThreeDimensionalTransformations : Form
    {
        public ThreeDimensionalTransformations()
        {
            InitializeComponent();
        }

        private List<TextBox> GetTextBoxes()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(txtbox_x1);
            textBoxes.Add(txtbox_y1);
            textBoxes.Add(txtbox_z1);
            textBoxes.Add(txtbox_x2);
            textBoxes.Add(txtbox_y2);
            textBoxes.Add(txtbox_z2);
            textBoxes.Add(txtbox_x3);
            textBoxes.Add(txtbox_y3);
            textBoxes.Add(txtbox_z3);
            textBoxes.Add(txtbox_x4);
            textBoxes.Add(txtbox_y4);
            textBoxes.Add(txtbox_z4);

            return textBoxes;
        }

        private int CountPoints(List<TextBox> textBoxes)
        {
            int count = 0;

            for (int i = 0; i < textBoxes.Count; i += 3)
            {
                try
                {
                    int.Parse(textBoxes[i].Text);
                    int.Parse(textBoxes[i + 1].Text);
                    int.Parse(textBoxes[i + 2].Text);
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

            for (int i = 0; i < textBoxes.Count; i += 3)
            {
                try
                {
                    int.Parse(textBoxes[i].Text);
                    int.Parse(textBoxes[i + 1].Text);
                    int.Parse(textBoxes[i + 2].Text);
                }
                catch
                {
                    if (textBoxes[i].Text.Equals("") || textBoxes[i + 1].Text.Equals("") || textBoxes[i + 2].Text.Equals(""))
                    {
                        // if the first point or any other point doesn't have either x or y
                        if (i == 0 || !(textBoxes[i].Text.Equals("") && textBoxes[i + 1].Text.Equals("") && textBoxes[i + 2].Text.Equals("")))
                        {
                            MessageBox.Show($"Missing an input at point number {(int)(i /3) + 1}.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        // if there is an empty point other than the first one
                        else
                        {
                            firstEmptyPoint = i;
                            break;
                        }

                    }
                    else
                    {
                        // if the input contains non-digit value
                        if (rgxNonDigit.IsMatch(textBoxes[i].Text) || rgxNonDigit.IsMatch(textBoxes[i + 1].Text) || rgxNonDigit.IsMatch(textBoxes[i + 2].Text))
                        {
                            MessageBox.Show($"Wrong input type at point number {(int)(i/3) + 1}. Please enter only integer numbers", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show($"Missing an input after point number {firstEmptyPoint / 3}.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
            }


            return false;

        }

        private void Clear(ListView listView)
        {
            listView.Items.Clear();
        }

        private List<Point3D> GetAvailablePionts()
        {
            List<Point3D> points = new List<Point3D>();

            List<TextBox> textBoxes = GetTextBoxes();

            int numOfPoints = CountPoints(textBoxes);

            for (int i = 0; i < numOfPoints * 3; i += 3)
            {
                points.Add(new Point3D(int.Parse(textBoxes[i].Text), int.Parse(textBoxes[i + 1].Text), int.Parse(textBoxes[i + 2].Text)));
            }

            return points;
        }

        private double[][] GetMatrix(int rows, int cols)
        {
            double[][] matrix = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new double[cols];
            }

            return matrix;
        }

        private double[][] GetPointMatrix(Point3D point)
        {
            double[][] matrix = new double[4][];
            for (int i = 0; i < 4; i++)
            {
                matrix[i] = new double[4];
            }

            matrix[0][0] = point.X;
            matrix[1][0] = point.Y;
            matrix[2][0] = point.Z;
            matrix[3][0] = 1;

            return matrix;
        }

        /* Construct the 4 x 4 identity matrix. */
        private void SetIdentityMatrix(double[][] matrix)
        {
            int row, col;
            for (row = 0; row < 4; row++)
                for (col = 0; col < 4; col++)
                    matrix[row][col] = (row == col) ? 1 : 0;
        }

        /* Premultiply matrix m1 times matrix m2, store result in m2. */
        private void PreMultiplyMatrix(double[][] m1, double[][] m2)
        {
            int row, col;
            double[][] matTemp = GetMatrix(4, 4);
            for (row = 0; row < 4; row++)
                for (col = 0; col < 4; col++)
                    matTemp[row][col] = m1[row][0] * m2[0][col] + m1[row][1] *
                    m2[1][col] + m1[row][2] * m2[2][col] +
                    m1[row][3] * m2[3][col];
            for (row = 0; row < 4; row++)
                for (col = 0; col < 4; col++)
                    m2[row][col] = matTemp[row][col];
        }

        private Point3D Translate3D(Point3D point, double tx, double ty, double tz)
        {
            double[][] matTransl = GetMatrix(4, 4);
            /* Initialize translation matrix to identity. */
            SetIdentityMatrix(matTransl);

            matTransl[0][3] = tx;
            matTransl[1][3] = ty;
            matTransl[2][3] = tz;


            double[][] translatedPointMat = GetPointMatrix(point);

            PreMultiplyMatrix(matTransl, translatedPointMat);

            return new Point3D((int)(translatedPointMat[0][0]), (int)(translatedPointMat[1][0]), (int)(translatedPointMat[2][0]));
        }

        private Point3D Rotate3D(Point3D point, Point3D p1, Point3D p2, double theta)
        {
            double[][] matQuaternionRot = GetMatrix(4, 4);
            double axisVectLength = Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) +
                                            (p2.Y - p1.Y) * (p2.Y - p1.Y) +
                                            (p2.Z - p1.Z) * (p2.Z - p1.Z));
            double cosA = Math.Cos(Math.PI / 180 * theta);
            double oneC = 1 - cosA;
            double sinA = Math.Sin(Math.PI / 180 * theta);
            double ux = (p2.X - p1.X) / axisVectLength;
            double uy = (p2.Y - p1.Y) / axisVectLength;
            double uz = (p2.Z - p1.Z) / axisVectLength;
            /* Set up translation matrix for moving p1 to origin. */
            Point3D translP = Translate3D(point, -p1.X, -p1.Y, -p1.Z);
            double[][] translatedPointMat = GetPointMatrix(translP);
            /* Initialize matQuaternionRot to identity matrix. */
            SetIdentityMatrix(matQuaternionRot);
            matQuaternionRot[0][0] = ux * ux * oneC + cosA;
            matQuaternionRot[0][1] = ux * uy * oneC - uz * sinA;
            matQuaternionRot[0][2] = ux * uz * oneC + uy * sinA;
            matQuaternionRot[1][0] = uy * ux * oneC + uz * sinA;
            matQuaternionRot[1][1] = uy * uy * oneC + cosA;
            matQuaternionRot[1][2] = uy * uz * oneC - ux * sinA;
            matQuaternionRot[2][0] = uz * ux * oneC - uy * sinA;
            matQuaternionRot[2][1] = uz * uy * oneC + ux * sinA;
            matQuaternionRot[2][2] = uz * uz * oneC + cosA;
            
            /* Combine matQuaternionRot with translation matrix. */
            PreMultiplyMatrix(matQuaternionRot, translatedPointMat);
            Point3D rotatedP = new Point3D((int)translatedPointMat[0][0],
                                           (int)translatedPointMat[1][0],
                                           (int)translatedPointMat[2][0]);
            
            /* Set up inverse matTransl3D and concatenate with
            * product of previous two matrices.
            */
            rotatedP = Translate3D(rotatedP, p1.X, p1.Y, p1.Z);
            double[][] rotatedPointMat = GetPointMatrix(rotatedP);

            return new Point3D((int)(rotatedPointMat[0][0]), (int)(rotatedPointMat[1][0]), (int)(rotatedPointMat[2][0]));
        }

        private Point3D Scale3D(Point3D point, double sx, double sy, double sz)
        {

            double[][] matScale3D = GetMatrix(4, 4);

            /* Initialize scaling matrix to identity. */
            SetIdentityMatrix(matScale3D);

            matScale3D[0][0] = sx;
            matScale3D[1][1] = sy;
            matScale3D[2][2] = sz;

            double[][] scaledPointMat = GetPointMatrix(point);

            PreMultiplyMatrix(matScale3D, scaledPointMat);

            return new Point3D((int)(scaledPointMat[0][0]), (int)(scaledPointMat[1][0]), (int)(scaledPointMat[2][0]));
        }



        private void btn_clear_Click(object sender, EventArgs e)
        {
            Clear(listView);
        }

        private void btn_translation_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                int.Parse(txtbox_op_x.Text);
                int.Parse(txtbox_op_y.Text);
                int.Parse(txtbox_op_z.Text);
            }
            catch
            {
                if (txtbox_op_x.Text.Equals("") || txtbox_op_y.Text.Equals("") || txtbox_op_z.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that X, Y, and Z have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter only integer numbers", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            List<Point3D> points = GetAvailablePionts();
            List<Point3D> translatedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                translatedPoints.Add(Translate3D(point, int.Parse(txtbox_op_x.Text), int.Parse(txtbox_op_y.Text), int.Parse(txtbox_op_z.Text)));
            }

            foreach (var point in translatedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_scaling_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                double.Parse(txtbox_op_x.Text);
                double.Parse(txtbox_op_y.Text);
                double.Parse(txtbox_op_z.Text);
            }
            catch
            {
                if (txtbox_op_x.Text.Equals("") || txtbox_op_y.Text.Equals("") || txtbox_op_z.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that X, Y, and Z have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }


            List<Point3D> points = GetAvailablePionts();
            List<Point3D> scaledPoints = new List<Point3D>();

            foreach (var point in points)
            {
                scaledPoints.Add(Scale3D(point, double.Parse(txtbox_op_x.Text), double.Parse(txtbox_op_y.Text), double.Parse(txtbox_op_z.Text)));
            }

            foreach (var point in scaledPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_rotate_over_x_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                double.Parse(txtbox_op_angle.Text);
            }
            catch
            {
                if (txtbox_op_angle.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that the angle has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else    
                {       
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Point3D p1 = new Point3D(0, 0, 0);
            Point3D p2 = new Point3D(1, 0, 0);

            List<Point3D> points = GetAvailablePionts();
            List<Point3D> rotatedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                rotatedPoints.Add(Rotate3D(point, p1, p2, double.Parse(txtbox_op_angle.Text)));
            }

            foreach (var point in rotatedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_rotate_over_y_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                double.Parse(txtbox_op_angle.Text);
            }
            catch
            {
                if (txtbox_op_angle.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that the angle has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Point3D p1 = new Point3D(0, 0, 0);
            Point3D p2 = new Point3D(0, 1, 0);

            List<Point3D> points = GetAvailablePionts();
            List<Point3D> rotatedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                rotatedPoints.Add(Rotate3D(point, p1, p2, double.Parse(txtbox_op_angle.Text)));
            }

            foreach (var point in rotatedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_rotate_over_z_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                double.Parse(txtbox_op_angle.Text);
            }
            catch
            {
                if (txtbox_op_angle.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that the angle has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Point3D p1 = new Point3D(0, 0, 0);
            Point3D p2 = new Point3D(0, 0, 1);

            List<Point3D> points = GetAvailablePionts();
            List<Point3D> rotatedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                rotatedPoints.Add(Rotate3D(point, p1, p2, double.Parse(txtbox_op_angle.Text)));
            }

            foreach (var point in rotatedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_rotate_over_axis_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;

            try
            {
                double.Parse(txtbox_op_angle.Text);
                int.Parse(txtbox_op_axis_x1.Text);
                int.Parse(txtbox_op_axis_y1.Text);
                int.Parse(txtbox_op_axis_z1.Text);
                int.Parse(txtbox_op_axis_x2.Text);
                int.Parse(txtbox_op_axis_y2.Text);
                int.Parse(txtbox_op_axis_z2.Text);
            }
            catch
            {
                if (txtbox_op_angle.Text.Equals(""))
                {
                    MessageBox.Show($"Missing An Input. Please make sure that the angle has a value.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtbox_op_axis_x1.Text.Equals("") || txtbox_op_axis_y1.Text.Equals("") || txtbox_op_axis_z1.Text.Equals("")
                      || txtbox_op_axis_x2.Text.Equals("") || txtbox_op_axis_y2.Text.Equals("") || txtbox_op_axis_z2.Text.Equals(""))
                {
                    if (!(txtbox_op_axis_x1.Text.Equals("") && txtbox_op_axis_y1.Text.Equals("") && txtbox_op_axis_z1.Text.Equals("")
                      && txtbox_op_axis_x2.Text.Equals("") && txtbox_op_axis_y2.Text.Equals("") && txtbox_op_axis_z2.Text.Equals("")))
                    {
                        MessageBox.Show($"Missing An Input. Please make sure that X, Y, and Z of the two points have values.", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtbox_op_axis_x1.Text = "0";
                        txtbox_op_axis_y1.Text = "0";
                        txtbox_op_axis_z1.Text = "0";
                        txtbox_op_axis_x2.Text = "1";
                        txtbox_op_axis_y2.Text = "1";
                        txtbox_op_axis_z2.Text = "1";
                    }
                }
                else
                {
                    MessageBox.Show($"Wrong Input Type. Please enter numbers only.", "WRONG INPUT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            Point3D p1 = new Point3D(int.Parse(txtbox_op_axis_x1.Text), int.Parse(txtbox_op_axis_y1.Text), int.Parse(txtbox_op_axis_z1.Text));
            Point3D p2 = new Point3D(int.Parse(txtbox_op_axis_x2.Text), int.Parse(txtbox_op_axis_y2.Text), int.Parse(txtbox_op_axis_z2.Text));

            List<Point3D> points = GetAvailablePionts();
            List<Point3D> rotatedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                rotatedPoints.Add(Rotate3D(point, p1, p2, double.Parse(txtbox_op_angle.Text)));
            }

            foreach (var point in rotatedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_ref_xy_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;


            double[][] reflectedMat = GetMatrix(4, 4);
            SetIdentityMatrix(reflectedMat);
            reflectedMat[2][2] = -1;


            List<Point3D> points = GetAvailablePionts();
            List<Point3D> reflectedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                double[][] pointMat = GetPointMatrix(point);
                PreMultiplyMatrix(reflectedMat, pointMat);
                reflectedPoints.Add(new Point3D((int)pointMat[0][0], (int)pointMat[1][0], (int)pointMat[2][0]));
            }

            foreach (var point in reflectedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_ref_xz_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;


            double[][] reflectedMat = GetMatrix(4, 4);
            SetIdentityMatrix(reflectedMat);
            reflectedMat[1][1] = -1;


            List<Point3D> points = GetAvailablePionts();
            List<Point3D> reflectedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                double[][] pointMat = GetPointMatrix(point);
                PreMultiplyMatrix(reflectedMat, pointMat);
                reflectedPoints.Add(new Point3D((int)pointMat[0][0], (int)pointMat[1][0], (int)pointMat[2][0]));
            }

            foreach (var point in reflectedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void btn_ref_yz_Click(object sender, EventArgs e)
        {
            if (HasError(GetTextBoxes()))
                return;


            double[][] reflectedMat = GetMatrix(4, 4);
            SetIdentityMatrix(reflectedMat);
            reflectedMat[0][0] = -1;


            List<Point3D> points = GetAvailablePionts();
            List<Point3D> reflectedPoints = new List<Point3D>();

            foreach (var point in points)
            {
                double[][] pointMat = GetPointMatrix(point);
                PreMultiplyMatrix(reflectedMat, pointMat);
                reflectedPoints.Add(new Point3D((int)pointMat[0][0], (int)pointMat[1][0], (int)pointMat[2][0]));
            }

            foreach (var point in reflectedPoints)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(point.X));
                item.SubItems.Add(Convert.ToString(point.Y));
                item.SubItems.Add(Convert.ToString(point.Z));
                listView.Items.Add(item);
            }
        }

        private void txtbox_shz_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_shear_x_Click(object sender, EventArgs e)
        {

        }

        private void btn_shear_y_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
