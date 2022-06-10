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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            DDA dda = new DDA();
            dda.ShowDialog();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bresenham bresenham = new Bresenham();
            bresenham.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        MidpointCircleAlgorithm algorithm = new MidpointCircleAlgorithm();
            algorithm.ShowDialog();
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            MidpointEllipseAlgorithm ellipse = new MidpointEllipseAlgorithm();
            ellipse.ShowDialog();
        }

        private void btn_2d_Click(object sender, EventArgs e)
        {
            TwoDimensionalTransformations twoDimension = new TwoDimensionalTransformations();
            twoDimension.ShowDialog();
        }

        private void btn_3d_Click(object sender, EventArgs e)
        {
            var threeDimension = new ThreeDimensionalTransformations();
            threeDimension.ShowDialog();
        }
    }
}
