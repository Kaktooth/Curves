using System;
using System.Drawing;
using System.Windows.Forms;

namespace Curves
{
    public partial class HilbertCurve : Form
    {
        public HilbertCurve()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int step = Convert.ToInt32(textBox1.Text);
            int size = Convert.ToInt32(trackBar1.Value);
            Hilbert hilbertCurve = new Hilbert(step, size, pictureBox1);
            hilbertCurve.ConstructHilbertCurve();
        }

    }
}
