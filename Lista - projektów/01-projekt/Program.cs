using System;
using System.Collections.Generic;

namespace GeometriaZaawansowana
{
    public abstract class Figura
    {
        public abstract string Nazwa { get; set; }
        public abstract DateTime DataUtworzenia { get; }
        public abstract string Identyfikator { get; set; }
    }

    public interface IFiguraObliczenia
    {
        double CalculateArea(double x, double y);
        double CalculatePerimeter(double x, double y);
    }

    public class Trapez : Figura, IFiguraObliczenia
    {
        private string _nazwa;
        private string _id;
        private DateTime _data;

        public override string Nazwa { get => _nazwa; set => _nazwa = value; }
        public override string Identyfikator { get => _id; set => _id = value; }
        public override DateTime DataUtworzenia => _data;

        public Trapez(string nazwa, string id, double d, double s, double h)
        {
            _nazwa = nazwa;
            _id = id;
            _data = DateTime.Now;

            GenerujRaportObliczeniowy(d, s, h);
        }

        public double CalculateArea(double dlugosc, double szerokosc)
        {
            return dlugosc * szerokosc;
        }

        public double CalculatePerimeter(double dlugosc, double szerokosc)
        {
            return 2 * (dlugosc + szerokosc);
        }

        private void GenerujRaportObliczeniowy(double dl, double sz, double hg)
        {
            double przestrzen = CalculateArea(dl, sz);
            double metr = CalculatePerimeter(dl, sz);
            double wysokoscObliczona = CalculatePerimeter(metr, hg);
            double Pole_w = wysokoscObliczona / 2;

            Console.WriteLine($"\n========================================");
            Console.WriteLine($"RAPORT DLA: {Nazwa.ToUpper()}");
            Console.WriteLine($"ID: {Identyfikator} | Data: {DataUtworzenia}");
            Console.WriteLine($"========================================");
            Console.WriteLine($"1. Przestrzeń robocza: {przestrzen:F2}");
            Console.WriteLine($"2. Metr bieżący (podstawowy): {metr:F2}");
            Console.WriteLine($"3. Wysokość przetworzona: {wysokoscObliczona:F2}");
            Console.WriteLine($"----------------------------------------");
            Console.WriteLine($"WYNIK KOŃCOWY (Pole właściwe): {Pole_w:F2}");
            Console.WriteLine($"========================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Trapez> kolekcjaTrapezow = new List<Trapez>();

            Console.WriteLine("SYSTEM OBLICZENIOWY TRAPEZÓW");
            
            Console.Write("PODAJ DANE DLA PIERWSZEGO OBIEKTU:");
            Console.Write("\nDługość: ");
            double d1 = PobierzLiczbe();
            Console.Write("Szerokość: ");
            double s1 = PobierzLiczbe();
            Console.Write("Wysokość: ");
            double h1 = PobierzLiczbe();

            Trapez uzytkownika = new Trapez("Trapez Dynamiczny", "USR-001", d1, s1, h1);
            Trapez systemowy = new Trapez("Trapez Wzorcowy", "SYS-999", 50.0, 30.0, 15.0);

            kolekcjaTrapezow.Add(uzytkownika);
            kolekcjaTrapezow.Add(systemowy);

            Console.WriteLine($"Zakończono procesowanie {kolekcjaTrapezow.Count} obiektów.");
            Console.ReadKey();
        }

        static double PobierzLiczbe()
        {
            double wynik;
            while (!double.TryParse(Console.ReadLine(), out wynik) || wynik <= 0)
            {
                Console.Write("Błąd! Wymagana liczba dodatnia. Spróbuj ponownie: ");
            }
            return wynik;
        }
    }
}