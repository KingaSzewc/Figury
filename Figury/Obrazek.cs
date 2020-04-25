using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Figury
{
    public class Obrazek
    {
        public List<Figura> listaFigur { get; set; }

        public Obrazek()
        {
            listaFigur = new List<Figura>();
        }

        public void DodajPunkt(Punkt nowy)
        {
            listaFigur.Add(nowy);
        }

        public void DodajTrojkat(Trojkat nowy)
        {
            listaFigur.Add(nowy);
        }

        public void DodajKolo(Kolo nowy)
        {
            listaFigur.Add(nowy);
        }

        public void DodajOdcinek(Odcinek nowy)
        {
            listaFigur.Add(nowy);
        }

        public void Move(double xMove, double yMove)
        {
            foreach (var item in listaFigur)
            {
                item.Move(xMove, yMove);
            }
        }

        public override string ToString()
        {
            var stringToReturn = string.Empty;
            var counter = 1;

            foreach (var item in listaFigur)
            {
                stringToReturn += $"{counter++} {item.ToString()}\n";
            }
            return stringToReturn;
        }

        public double GetArea()
        {
            var area = 0.0;

            foreach (var item in listaFigur)
            {
                area += item.GetArea();
            }
            return area;
        }
    }
}
