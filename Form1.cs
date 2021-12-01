using System.Windows.Forms;

namespace Curves
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            HilbertCurve hilbert = new HilbertCurve();
            hilbert.Show();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            SerpinskyCurve serpinsky = new SerpinskyCurve();
            serpinsky.Show();
        }
    }
}
