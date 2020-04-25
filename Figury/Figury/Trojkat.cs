using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    public class Trojkat : Figura
    {
        public Punkt Punkt1 { get; set; }
        public Punkt Punkt2 { get; set; }
        public Punkt Punkt3 { get; set; }


        public Trojkat()
        {

        }
        public Trojkat(Punkt punkt1, Punkt punkt2, Punkt punkt3)
        {
            this.Punkt1 = punkt1;
            this.Punkt2 = punkt2;
            this.Punkt3 = punkt3;
        }
        public Trojkat(Trojkat t)
        {
            this.Punkt1 = new Punkt(t.Punkt1);
            this.Punkt2 = new Punkt(t.Punkt2);
            this.Punkt3 = new Punkt(t.Punkt3);
        }

        public void Move(double xMove, double yMove)
        {
            this.Punkt1.Move(xMove, yMove);
            this.Punkt2.Move(xMove, yMove);
            this.Punkt3.Move(xMove, yMove);
        }

        public override string ToString()
        {
            return
                $"Trojkat " +
                $"{this.Punkt1.ToString()} " +
                $"{this.Punkt2.ToString()} " +
                $"{this.Punkt3.ToString()}";
        }

        public double GetArea()
        {
            var odcinek1 = new Odcinek(this.Punkt1, this.Punkt2);
            var odcinek2 = new Odcinek(this.Punkt2, this.Punkt3);
            var odcinek3 = new Odcinek(this.Punkt3, this.Punkt1);

            //wzor herona
            var a = odcinek1.GetDlugosc();
            var b = odcinek2.GetDlugosc();
            var c = odcinek3.GetDlugosc();

            var p = (a + b + c) / 2;

            var area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

    }
}
