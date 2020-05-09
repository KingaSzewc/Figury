using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    public class Trojkat : Figura, IScalable, IFillable
    {
        public Punkt Punkt1 { get; set; }
        public Punkt Punkt2 { get; set; }
        public Punkt Punkt3 { get; set; }
        public int Color { get; set; }

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

        public override void Move(double xMove, double yMove)
        {
            this.Punkt1.Move(xMove, yMove);
            this.Punkt2.Move(xMove, yMove);
            this.Punkt3.Move(xMove, yMove);
        }

        public override string ToString()
        {
            var xTmp = (Punkt1.X + Punkt2.X + Punkt3.X) / 3;
            var yTmp = (Punkt1.Y + Punkt2.Y + Punkt3.Y) / 3;
            var nowyPunkt = new Punkt(xTmp, yTmp);

            return
                $"Trojkat " +
                $"{this.Punkt1.ToString()} " +
                $"{this.Punkt2.ToString()} " +
                $"{this.Punkt3.ToString()}";
        }

        public override double GetArea()
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

        public override double GetOdleglosc()
        {
            var xTmp = (Punkt1.X + Punkt2.X + Punkt3.X) / 3;
            var yTmp = (Punkt1.Y + Punkt2.Y + Punkt3.Y) / 3;
            var nowyPunkt = new Punkt(xTmp, yTmp);

            return nowyPunkt.GetOdleglosc();
        }

        public void ScalePerimeter(double k)
        {
            var odcA = new Odcinek(Punkt2, Punkt3).GetDlugosc();
            var odcB = new Odcinek(Punkt3, Punkt1).GetDlugosc();
            var odcC = new Odcinek(Punkt1, Punkt2).GetDlugosc();

            var xSrodek = (odcA * Punkt1.X + odcB * Punkt2.X + odcC * Punkt3.X) / (odcA + odcB + odcC);
            var ySrodek = (odcA * Punkt1.Y + odcB * Punkt2.Y + odcC * Punkt3.Y) / (odcA + odcB + odcC);
            var tablica = new Punkt[] { Punkt1, Punkt2, Punkt3 };

            foreach (var item in tablica)
            {
                var newPunkt3X = (item.X - xSrodek) * k;
                var newPunkt3Y = (item.Y - ySrodek) * k;
                item.X = newPunkt3X + xSrodek;
                item.Y = newPunkt3Y + ySrodek;
            }
        }

        public void fill(int color)
        {
            this.Color = color;
        }
    }
}
