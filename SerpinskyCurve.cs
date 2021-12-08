using System;
using System.Drawing;
using System.Windows.Forms;

namespace Curves
{
    public partial class SerpinskyCurve : Form
    {
        public SerpinskyCurve()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int step = Convert.ToInt32(textBox1.Text);
            int size = Convert.ToInt32(trackBar1.Value);
            Serpinsky serpinskyCurve = new Serpinsky(step, size, pictureBox1);
            serpinskyCurve.ConstructSerpinskyCurve();
        }
    }
}
