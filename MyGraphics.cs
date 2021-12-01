using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Curves
{
    public class MyGraphics
    {
        Color color { get; set; }
        public Color currentColor { get; set; }
        string name { get; set; }
        int Size { get; set; }
        int X { get; set; }
        int Y { get; set; }
        public int angle { get; set; }
        Pen p = new Pen(Color.Red, 1f);

        public void Hide()
        {
            currentColor = Color.White;
        }
        public void Show()
        {
            currentColor = color;
        }
        public void SetLocation(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void IncreaseSize()
        {
            Size++;
        }
        public void ReduceSize()
        {
            Size--;
        }
        //public Graphics GetGraphicsFromRule(Graphics graphics)
        //{
        //    return graphics;
        //}


        public void Draw(PictureBox pictureBox, float angle)
        {
            p.Color = currentColor;
            using (var g = Graphics.FromImage(pictureBox.Image))
            {
                g.DrawEllipse(p, X, Y, Size, Size);
                double d = Size;
                float side = (float)(d * (Math.Sqrt(2f) / 2f));
                g.DrawRectangle(p, X + Size / 7, Y + Size / 7, side, side);
                Rectangle r = new Rectangle(X + Size / 7, Y + Size / 7, (int)side, (int)side);

                RotateRectangle(g, r, angle, p);

                pictureBox.Refresh();
            }
        }

        public void RotateRectangle(Graphics g, Rectangle r, float angle, Pen p)
        {
            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, new PointF(r.Left + (r.Width / 2),
                    r.Top + (r.Height / 2)));
                g.Transform = m;
                g.DrawRectangle(p, r);
                g.ResetTransform();
            }
        }
    }
}
