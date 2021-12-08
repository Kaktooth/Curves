using System.Collections.Generic;
using System.Windows.Forms;

namespace Curves
{
    public class Hilbert
    {
        private int steps = 0;

        private PictureBox p;

        private int size = 0;

        public Hilbert(int steps, int size, PictureBox p)
        {
            this.steps = steps;
            this.size = size;
            this.p = p;
        }


        public void ConstructHilbertCurve()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Y", "+XF-YFY-FX+");
            d.Add("X", "-YF+XFX+FY-");
            LSystem l = new LSystem("X", steps, 90, d);
            string rules = l.BuildStringWithRules(0, "X");
            l.DrawGraphicsFromRule(p, size, rules, 180);
            //l.DrawGraphicsFromRule(p,size, "-+AF-BFB-FA+F+-BF+AFA+FB-F-BF+AFA+FB-+F+AF-BFB-FA+");
        }
    }
}
