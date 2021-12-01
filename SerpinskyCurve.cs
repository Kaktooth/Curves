using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
