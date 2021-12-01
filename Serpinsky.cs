using System.Collections.Generic;
using System.Windows.Forms;

namespace Curves
{
    public class Serpinsky
    {
        private int steps = 0;

        private PictureBox p;

        private int size = 0;

        public Serpinsky(int steps, int size, PictureBox p)
        {
            this.steps = steps;
            this.size = size;
            this.p = p;
        }


        public void ConstructSerpinskyCurve()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("X", "XF+G+XF−−F−−XF+G+X");
            LSystem l = new LSystem("F−−XF−−F−−XF", steps, 90, d);
            string rules = l.BuildStringWithRules(0, "F−−XF−−F−−XF");

            l.DrawGraphicsFromRule(p, size, rules);
            //l.DrawGraphicsFromRule(p,size, "-+AF-BFB-FA+F+-BF+AFA+FB-F-BF+AFA+FB-+F+AF-BFB-FA+");
        }
    }
}
