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
            obrazek.OdczytajZPliku();
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
                        case 10: UstawKolor(); break;
                        case 11: Przeskaluj(); break;
                        case 12: return;
                        default:
                            break;
                    }
                }
                obrazek.ZapiszDoPliku();
            }
        }

        public void WyswietlMenu()
        {
            var listaMenu = new string[] {
            "Wyswietl",
            "Dodaj Punkt",
            "Dodaj odcinek",
            "Dodaj koło",
            "Dodaj trójkąt",
            "Przesun Element",
            "Posortowane po etykiecie",
            "Posortowane po nazwie klasy",
            "Posortowane wg. odległości punktu centroida obiektu  od początku układu współrzędnych",
            "Ustaw kolor figury",
            "Przeskaluj figure",
            "Wyjscie z programu"
            };

            for (int i = 0; i < listaMenu.Count(); i++)
            {
                Console.WriteLine((i + 1) + ". " + listaMenu[i]);
            }
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
            k.Label = etykieta;
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

        public void UstawKolor()
        {
            Console.WriteLine(obrazek.ToStringTrojkatIKolo());
            Console.WriteLine("Podaj numer figury");
            var numerFigury = Console.ReadLine();
            Console.WriteLine("Podaj kolor");
            var kolor = Console.ReadLine();
            obrazek.FillObjects(int.Parse(numerFigury), int.Parse(kolor));
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(obrazek.ToStringTrojkatIKolo());
            Console.WriteLine("Kliknij dowolny przycisk");
            Console.ReadKey();
        }

        public void Przeskaluj()
        {
            Console.WriteLine(obrazek.ToStringTrojkatIKolo());
            Console.WriteLine("Podaj numer figury");
            var numerFigury = Console.ReadLine();
            Console.WriteLine("Podaj wspolczynnik k");
            var k = Console.ReadLine();
            obrazek.ScaleObject(int.Parse(numerFigury), int.Parse(k));
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(obrazek.ToStringTrojkatIKolo());
            Console.WriteLine("Kliknij dowolny przycisk");
            Console.ReadKey();
        }


    }
}
