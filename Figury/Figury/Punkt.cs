using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    public class Punkt : Figura
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Punkt() { }

        public Punkt(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public Punkt(Punkt p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }

        public override void Move(double xMove, double yMove)
        {
            this.X += xMove;
            this.Y += yMove;
        }

        public override string ToString()
        {
            return $"Punkt X: {this.X} y: {this.Y} ";
        }
    }
}
