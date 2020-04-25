using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Figury
{
    public class UstandaryzowanyObrazek : Obrazek
    {

        public UstandaryzowanyObrazek() : base()
        {

        }

        public new void DodajFigure(Figura nowy)
        {
            if (sprawdzCzyDuzeLiteryICyfry(nowy.Label))
            {
                listaFigur.Add(nowy);
            }
            else
            {
                Console.WriteLine("etykieta zawiera małe litery lub zaczyna sie cyfra ");
                Console.WriteLine("Naciśnij Dowolny przycisk");
                Console.ReadKey();
            }
        }

        private bool sprawdzCzyDuzeLiteryICyfry(string etykieta)
        {
            string pattern = @"^[A-Z][A-Z0-9]*";
            Regex rg = new Regex(pattern);
            MatchCollection matchedAuthors = rg.Matches(etykieta);

            if (matchedAuthors.Any())
            {
                return true;
            }
            return false;
        }


    }
}
