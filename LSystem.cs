using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Curves
{
    public class LSystem
    {
        private int step = 0;

        private int angle = 0;

        private Pen color = new Pen(Color.Black);

        private string stringRule = "";

        private Dictionary<string, string> rules = new Dictionary<string, string>();

        public LSystem(string startRule, int step, int angle, Dictionary<string, string> rules)
        {
            this.step = step;
            this.rules = rules;
            this.angle = angle;
            this.stringRule = startRule;
        }

        public string BuildStringWithRules(int counter,string rule)
        {
            string newStringRule = "";
            if (counter == step)
            {
                
                return rule;
            }
            else
            {

                foreach (var r in rules)
                {
                    newStringRule.Replace(r.Key.ToString(), r.Value.ToString());
                }

                counter++;
                return BuildStringWithRules(counter,newStringRule);
            }
        }

        private int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }

        public void DrawGraphicsFromRule(PictureBox p, int size)
        {
            int currentAngle = 0;
            float a = p.Width / 2;
            float b = p.Height / 2;
            using (var g = Graphics.FromImage(p.Image))
            {
                using (Matrix m = new Matrix())
                {
                    m.RotateAt(180, new PointF(a, b));
                    g.Transform = m;
                    g.Clear(Color.White);
                    foreach (var rule in stringRule)
                    {
                        if (rule == 'F')
                        {
                            float angleRadian = currentAngle * MathF.PI / 180;
                            float nexta =
                                MathF.Round(a + size * MathF.Cos(angleRadian));
                            float nextb =
                                MathF.Round(b + size * MathF.Sin(angleRadian));
                            g.DrawLine(color, new PointF(a, b), new PointF(nexta, nextb));
                            //RotateLine(g, a, b, angle, color);

                            a += size * MathF.Cos(angleRadian);
                            b += size * MathF.Sin(angleRadian);


                        }
                        else if (rule == '+')
                        {
                            currentAngle += angle;
                        }
                        else if (rule == '-')
                        {
                            currentAngle -= angle;
                        }
                        
                    }
                    g.ResetTransform();
                }

                p.Refresh();
            }
        }
        public void DrawGraphicsFromRule(PictureBox p, int size, string rules)
        {
            int stepF = 0;
            if (step > 2)
            {
                stepF = Factorial(step - 1);
            }
            else
            {
                stepF = Factorial(step);
            }

            int currentAngle = 0;
            float halfWight = (p.Width/ 2)+size+(stepF*size/step);
            float halfHeight = (p.Height / 2)-size-(stepF*size/step);
            float a = halfWight;
            float b = halfHeight;
            using (var g = Graphics.FromImage(p.Image))
            {
                using (Matrix m = new Matrix())
                {
                    m.RotateAt(180, new PointF(a, b));
                    
                    g.Transform = m;

                    g.Clear(Color.White);
                    foreach (var rule in rules)
                    {
                        if (rule == 'F')
                        {
                            float angleRadian = currentAngle * MathF.PI / 180;
                            float nexta =
                                MathF.Round(a + size * MathF.Cos(angleRadian));
                            float nextb =
                                MathF.Round(b + size * MathF.Sin(angleRadian));
                            g.DrawLine(color, new PointF(a, b), new PointF(nexta, nextb));
                            //RotateLine(g, a, b, angle, color);

                            a += size * MathF.Cos(angleRadian);
                            b += size * MathF.Sin(angleRadian);


                        }
                        else if (rule == '+')
                        {
                            currentAngle += angle;
                        }
                        else if (rule == '-')
                        {
                            currentAngle -= angle;
                        }

                    }
                    g.ResetTransform();
                    
                }
               
                p.Refresh();
            }
        }
    }
}
