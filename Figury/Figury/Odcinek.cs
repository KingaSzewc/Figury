using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    public class Odcinek : Figura
    {
        public Punkt Punkt1 { get; set; }
        public Punkt Punkt2 { get; set; }

        public Odcinek() { }
        public Odcinek(Punkt punkt1, Punkt punkt2)
        {
            this.Punkt1 = punkt1;
            this.Punkt2 = punkt2;
        }
        public Odcinek(Odcinek o)
        {
            this.Punkt1 = new Punkt(o.Punkt1);
            this.Punkt2 = new Punkt(o.Punkt2);
        }

        public void Move(double xMove, double yMove)
        {
            this.Punkt1.Move(xMove, yMove);
            this.Punkt2.Move(xMove, yMove);
        }

        public override string ToString()
        {
            return $"Odcinek " +
                $"{this.Punkt1.ToString()} " +
                $"{this.Punkt2.ToString()}";
        }
        public double GetArea()
        {
            return 0;
        }
        public double GetDlugosc()
        {
            var x = Punkt1.X - Punkt2.X;
            var y = Punkt1.Y - Punkt2.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
    }
}
