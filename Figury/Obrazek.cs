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

            //listaFigur.Add(new Punkt() { Label = "KINGU", X = 5, Y = 7 });
            //listaFigur.Add(new Punkt() { Label = "testr", X = 5, Y = 7 });
            //listaFigur.Add(new Punkt() { Label = "aasdas", X = 5, Y = 7 });
            //listaFigur.Add(new Punkt() { Label = "eqwqweqwe", X = 5, Y = 7 });

            //listaFigur.Add(new Kolo() { Label = "eqwqweqwe", Punkt = new Punkt(5, 3), Promien = 9 });
            //listaFigur.Add(new Kolo() { Label = "dsadasd", Punkt = new Punkt(5, 3), Promien = 9 });
            //listaFigur.Add(new Kolo() { Label = "aaaaaaaa", Punkt = new Punkt(5, 3), Promien = 9 });
            //listaFigur.Add(new Kolo() { Label = "bbbbbbbb", Punkt = new Punkt(1, 1), Promien = 9 });


            //listaFigur.Add(new Odcinek() { Label = "oiuoui", Punkt1 = new Punkt(5, 4), Punkt2 = new Punkt(5, 4) });
            //listaFigur.Add(new Odcinek() { Label = "asdas", Punkt1 = new Punkt(5, 4), Punkt2 = new Punkt(5, 4) });
            //listaFigur.Add(new Odcinek() { Label = "hjdfghgdf", Punkt1 = new Punkt(5, 4), Punkt2 = new Punkt(5, 4) });
            var newTr = new Trojkat() { Label = "a", Punkt1 = new Punkt(0, 0), Punkt2 = new Punkt(4, 0), Punkt3 = new Punkt(0, 3) };
            newTr.ScalePerimeter(2);
            listaFigur.Add(newTr); 


            listaFigur.Add(new Trojkat() { Label = "a", Punkt1 = new Punkt(-1, 0), Punkt2 = new Punkt(3, 0), Punkt3 = new Punkt(-1, 3) });
            listaFigur.FirstOrDefault().GetOdleglosc();

        }

        public void DodajFigure(Figura nowy)
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
                stringToReturn += $"{counter++} {item.Label} {item.ToString()}\n";
            }
            return ToStringSortedByDistanceFromOrigin(); ;
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


        public string ToStringSortedByLAbel()
        {
            var stringToReturn = string.Empty;
            var counter = 1;

            foreach (var item in listaFigur.OrderBy(x => x.Label))
            {
                stringToReturn += $"{counter++} {item.Label} {item.ToString()}\n";
            }
            return stringToReturn;
        }

        public string ToStringSortedByClassName()
        {
            var stringToReturn = string.Empty;
            var counter = 1;

            foreach (var item in listaFigur.OrderBy(x => x.GetType().Name))
            {
                stringToReturn += $"{counter++} {item.Label} {item.ToString()}\n";
            }
            return stringToReturn;
        }

        public string ToStringSortedByDistanceFromOrigin()
        {
            var stringToReturn = string.Empty;
            var counter = 1;

            foreach (var item in listaFigur.OrderBy(x => x.GetOdleglosc()))
            {
                stringToReturn += $"{counter++} {item.Label} {item.ToString()}\n";
            }
            return stringToReturn;
        }
        public void FillObjects()
        {

        }

        public void ScaleObject()
        {


        }
    }
}
