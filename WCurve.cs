using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Curves
{
    public partial class WCurve : Form
    {
        public WCurve()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            string[] pointArray = textBox1.Text.Split(';').ToArray();
            List<PointF> points = new List<PointF>();
            for (int i = 0; i < pointArray.Length; i++)
            {
                string[] point = pointArray[i].Split(',');
                points.Add(new PointF(
                        (float)Convert.ToDouble(point[0]),
                    (float)Convert.ToDouble(point[1]))
                    );
            }

            PointF P0 = points[0];
            PointF P1 = points[1];
            PointF P2 = points[2];

            PointF scaledP0 = new PointF(P0.X * trackBar1.Value + (pictureBox1.Width / 3),
                -P0.Y * trackBar2.Value + (pictureBox1.Height / 2));
            PointF scaledP1 = new PointF(P1.X * trackBar1.Value + (pictureBox1.Width / 3),
                -P1.Y * trackBar2.Value + (pictureBox1.Height / 2));
            PointF scaledP2 = new PointF(P2.X * trackBar1.Value + (pictureBox1.Width / 3),
                -P2.Y * trackBar2.Value + (pictureBox1.Height / 2));

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.DrawLine(new Pen(Color.DarkGray, 1), scaledP0, scaledP1);
                g.DrawLine(new Pen(Color.DarkGray, 1), scaledP1, scaledP2);
                Pen graphicPen = new Pen(Color.Blue, 2);
                Pen pointPen = new Pen(Color.Red, 2);
                int counter = 0;
                foreach (var p in points)
                {
                    float scaleX = p.X * trackBar1.Value + (pictureBox1.Width / 3) - Convert.ToInt32(9 / 2);
                    float scaleY = -p.Y * trackBar2.Value + (pictureBox1.Height / 2) - Convert.ToInt32(9 / 2);

                    g.FillEllipse(Brushes.Red, scaleX, scaleY, 9, 9);

                    g.DrawString("P" + counter + " (" + points[counter].X + ", " + points[counter].Y + ")".ToString(), new Font(FontFamily.GenericSerif, 8), Brushes.Black, new PointF(scaleX - 10, scaleY - 25));
                    counter++;
                }
                List<PointF> pointslist = new List<PointF>();
                for (float i = 0; i < 1; i += 0.01f)
                {
                    float Bx = MathF.Pow((1 - i), 2) * P0.X + 2 * i * (1 - i) * P1.X + MathF.Pow(i, 2) * P2.X;
                    float By = MathF.Pow((1 - i), 2) * P0.Y + 2 * i * (1 - i) * P1.Y + MathF.Pow(i, 2) * P2.Y;
                    pointslist.Add(new PointF(Bx * trackBar1.Value + (pictureBox1.Width / 3),
                        -By * trackBar2.Value + (pictureBox1.Height / 2)));
                }
                pointslist.Reverse();
                g.DrawLines(graphicPen, pointslist.ToArray());
            }
        }
    }
}
