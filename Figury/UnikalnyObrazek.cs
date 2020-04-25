using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Figury
{
    public class UnikalnyObrazek : Obrazek
    {

        public new void DodajFigure(Figura nowy)
        {
            if (!sprawdźCzyEtykietaIstnieje(nowy.Label))
            {
                listaFigur.Add(nowy);
            }
            else
            {
                Console.WriteLine("etykieta już istnieje");
                Console.WriteLine("Naciśnij Dowolny przycisk");
                Console.ReadKey();
            }
        }

        private bool sprawdźCzyEtykietaIstnieje(string etykieta)
        {
            return listaFigur.Where(x => x.Label == etykieta).Any();
        }


    }
}
