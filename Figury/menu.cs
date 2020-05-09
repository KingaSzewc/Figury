using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Figury
{
    public class Menu
    {
        public UstandaryzowanyObrazek obrazek;
        public Menu()
        {
            obrazek = new UstandaryzowanyObrazek();
        }

        public void StartMenu()
        {
            int wybrane;

            while (true)
            {
                Console.Clear();
                WyswietlMenu();
                Console.Write("Wybierz: ");

                if (int.TryParse(Console.ReadLine(), out wybrane))
                {
                    Console.Clear();
                    switch (wybrane)
                    {
                        case 1:
                            Wyswietl();
                            Console.WriteLine("Kliknij dowolny przycisk");
                            Console.ReadKey(); break;
                        case 2: DodajPunkt(); break;
                        case 3: DodajOdcinek(); break;
                        case 4: DodajKolo(); break;
                        case 5: DodajTrojkat(); break;
                        case 6: Move(); break;
                        case 7: Sortowanepolabel(); break;
                        case 8: Sortowanepoclassname(); break;
                        case 9: SortowaneByDistanceFromOrigin(); break;
                        case 10: return;
                        default:
                            break;
                    }
                }
            }
        }

        public void WyswietlMenu()
        {
            Console.WriteLine("1. Wyswietl");
            Console.WriteLine("2. Dodaj Punkt");
            Console.WriteLine("3. Dodaj odcinek");
            Console.WriteLine("4. Dodaj koło");
            Console.WriteLine("5. Dodaj trójkąt");
            Console.WriteLine("6. Przesun Element");
            Console.WriteLine("7. Posortowane po etykiecie");
            Console.WriteLine("8. Posortowane po nazwie klasy");
            Console.WriteLine("9. Posortowane wg. odległości punktu centroida obiektu  od początku układu współrzędnych.");
            Console.WriteLine("10. Wyjscie z programu");
        }

        public void Wyswietl()
        {
            Console.WriteLine("Area: " + obrazek.GetArea());
            Console.WriteLine();
            Console.WriteLine(obrazek.ToString());
        }

        public void DodajPunkt()
        {
            var pom1 = 0;
            var pom2 = 0;
            var etykieta = string.Empty;

            Console.WriteLine("Podaj Etykiete");
            etykieta = Console.ReadLine();

            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p = new Punkt(pom1, pom2);
            p.Label = etykieta;

            obrazek.DodajFigure(p);
        }

        public void DodajOdcinek()
        {
            var pom1 = 0;
            var pom2 = 0;
            var etykieta = string.Empty;

            Console.WriteLine("Podaj Etykiete");
            etykieta = Console.ReadLine();

            Console.WriteLine("Punkt 1");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p1 = new Punkt(pom1, pom2);

            Console.WriteLine("Punkt 2");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p2 = new Punkt(pom1, pom2);

            Odcinek o = new Odcinek(p1, p2);
            o.Label = etykieta;
            obrazek.DodajFigure(o);
        }

        public void DodajKolo()
        {
            var pom1 = 0;
            var pom2 = 0;
            var etykieta = string.Empty;

            Console.WriteLine("Podaj Etykiete");
            etykieta = Console.ReadLine();

            Console.WriteLine("Punkt");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p1 = new Punkt(pom1, pom2);

            Console.WriteLine("Podaj Promien");
            pom1 = int.Parse(Console.ReadLine());
            Kolo k = new Kolo(p1, pom1);
            k.Label=etykieta;
            obrazek.DodajFigure(k);
        }

        public void DodajTrojkat()
        {
            var pom1 = 0;
            var pom2 = 0;
            var etykieta = string.Empty;

            Console.WriteLine("Podaj Etykiete");
            etykieta = Console.ReadLine();

            Console.WriteLine("Punkt 1");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p1 = new Punkt(pom1, pom2);

            Console.WriteLine("Punkt 2");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p2 = new Punkt(pom1, pom2);

            Console.WriteLine("Punkt 3");
            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());
            Punkt p3 = new Punkt(pom1, pom2);

            Trojkat t = new Trojkat(p1, p2, p3);
            t.Label = etykieta;
            obrazek.DodajFigure(t);
        }

        public void Move()
        {
            Wyswietl();
            var pom1 = 0;
            var pom2 = 0;
            var numerElementu = 0;
            Console.WriteLine("Podaj element do przesuniecia");
            numerElementu = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj X");
            pom1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Podaj Y");
            pom2 = int.Parse(Console.ReadLine());

            obrazek.listaFigur.ElementAt(numerElementu - 1).Move(pom1, pom2);
        }
        public void Sortowanepolabel()
        {
            Console.WriteLine(obrazek.ToStringSortedByLAbel());
            Console.WriteLine("Kliknij dowolny przycisk");
            Console.ReadKey();
        }
        public void Sortowanepoclassname()
        {
            Console.WriteLine(obrazek.ToStringSortedByClassName());
            Console.WriteLine("Kliknij dowolny przycisk");
            Console.ReadKey();
        }
        public void SortowaneByDistanceFromOrigin()
        {
            Console.WriteLine(obrazek.ToStringSortedByDistanceFromOrigin());
            Console.WriteLine("Kliknij dowolny przycisk");
            Console.ReadKey();
        }
    }
}
