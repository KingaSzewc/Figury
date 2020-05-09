using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    [Serializable]
    public class Kolo : Figura, IScalable, IFillable
    {
        public Punkt Punkt { get; set; }
        public double Promien { get; set; }
        public int Color { get; set; }
        public Kolo()
        {

        }
        public Kolo(Punkt punkt, double promien)
        {
            this.Punkt = punkt;
            this.Promien = promien;
        }
        public Kolo(Kolo k)
        {
            this.Punkt = new Punkt(k.Punkt);
            this.Promien = k.Promien;
        }

        public override void Move(double xMove, double yMove)
        {
            this.Punkt.Move(xMove, yMove);
        }

        public override string ToString()
        {
            return
                $"Kolo " +
                $"Promien: {this.Promien} " +
                $"Punkt: {this.Punkt.ToString()}" +
                $"Kolor: {this.Color}";
        }
        public override double GetArea()
        {
            var pi = 3.14;

            var area = pi * this.Promien * this.Promien;
            return area;
        }

        public override double GetOdleglosc()
        {
            return this.Punkt.GetOdleglosc();
        }

        public void ScalePerimeter(double k)
        {
            Promien = Promien * k;
        }

        public void fill(int color)
        {
            this.Color = color;
        }
    }
}
