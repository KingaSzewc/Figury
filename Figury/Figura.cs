using System;
using System.Collections.Generic;
using System.Text;

namespace Figury
{
    public abstract class Figura
    {
        public string Label { get; set; }


        public virtual void Move(double xMove, double yMove)
        {

        }

        public virtual double GetArea()
        {
            return 0;
        }
        public virtual double GetOdleglosc()
        {
            return 0;
        }


    }
}
