using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Figury
{
    public class Obrazek
    {
        public List<Punkt> listaPunktow { get; set; }
        public List<Trojkat> listaTrojkatow { get; set; }
        public List<Kolo> listaKol { get; set; }
        public List<Odcinek> listaOdcinkow { get; set; }

        public Obrazek()
        {
            listaPunktow = new List<Punkt>();
            listaTrojkatow = new List<Trojkat>();
            listaKol = new List<Kolo>();
            listaOdcinkow = new List<Odcinek>();
        }

        public void DodajPunkt(Punkt nowy)
        {
            listaPunktow.Add(nowy);
        }

        public void DodajTrojkat(Trojkat nowy)
        {
            listaTrojkatow.Add(nowy);
        }

        public void DodajKolo(Kolo nowy)
        {
            listaKol.Add(nowy);
        }

        public void DodajOdcinek(Odcinek nowy)
        {
            listaOdcinkow.Add(nowy);
        }

        public void Move(double xMove, double yMove)
        {
            listaPunktow.ForEach(i => i.Move(xMove, yMove));
            listaTrojkatow.ForEach(i => i.Move(xMove, yMove));
            listaKol.ForEach(i => i.Move(xMove, yMove));
            listaOdcinkow.ForEach(i => i.Move(xMove, yMove));
        }

        public override string ToString()
        {
            var stringToReturn = string.Empty;
            var counter = 1;



            foreach (var item in listaPunktow)
                stringToReturn += $"{counter++} {item.ToString()}\n";
            stringToReturn += "\n";

            foreach (var item in listaTrojkatow)
                stringToReturn += $"{counter++} {item.ToString()}\n";
            stringToReturn += "\n";

            foreach (var item in listaKol)
                stringToReturn += $"{counter++} {item.ToString()}\n";
            stringToReturn += "\n";

            foreach (var item in listaOdcinkow)
                stringToReturn += $"{counter++} {item.ToString()}\n";
            stringToReturn += "\n";
            return stringToReturn;
        }

        public double GetArea()
        {
            var area = listaPunktow.Select(x => x.GetArea()).Sum();
            area += listaTrojkatow.Select(x => x.GetArea()).Sum();
            area += listaKol.Select(x => x.GetArea()).Sum();
            area += listaOdcinkow.Select(x => x.GetArea()).Sum();

            return area;
        }

    }
}
