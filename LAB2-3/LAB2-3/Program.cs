using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;


namespace lab2
{
    
    public class Osoba
    {
        private string imie;
        private string nazwisko;
        private int wiek;
        private readonly string pesel;

        public Osoba(string imie, string nazwisko, int wiek, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            Wiek = wiek; // Użycie właściwości z walidacją
            this.pesel = pesel;
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public int Wiek
        {
            get { return wiek; }
            set
            {
                if (value < 0)
                    wiek = 0;
                else
                    wiek = value;
            }
        }

        public string Pesel
        {
            get { return pesel; }
        }

        public string PrzedstawSie()
        {
            return $"Nazywam się {imie} {nazwisko} i mam {wiek} lat.";
        }
    }
    public class Licz
    {
        private int wartosc;

        public Licz(int poczatkowaWartosc)
        {
            wartosc = poczatkowaWartosc;
        }

        public void DodajLicz(int liczba)
        {
            wartosc += liczba;
        }

        public void OdejmijLicz(int liczba)
        {
            wartosc -= liczba;
        }

        public void WypiszStan()
        {
            Console.WriteLine($"Aktualny stan: {wartosc}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Osoba osoba = new Osoba("Jan", "Kowalski", 30, "12345678901");
            Console.WriteLine(osoba.PrzedstawSie());
            osoba.Wiek = -5; // Próba ustawienia ujemnego wieku
            Console.WriteLine($"Poprawiony wiek: {osoba.Wiek}");
            Console.WriteLine($"PESEL: {osoba.Pesel}");
            
            Licz licznik = new Licz(10);
            licznik.WypiszStan();
            licznik.DodajLicz(5);
            licznik.WypiszStan();
            licznik.OdejmijLicz(3);
            licznik.WypiszStan();
            
            int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Sumator sumator = new Sumator(liczby);
            Console.WriteLine($"Suma: {sumator.Suma()}");
            Console.WriteLine($"Suma podzielnych przez 3: {sumator.SumaPodziel3()}");
            Console.WriteLine($"Ilość elementów: {sumator.IleElementow()}");
            sumator.WypiszElementy();
            sumator.WypiszElementyWZakresie(2, 6);
            sumator.WypiszElementyWZakresie(-1, 12);
        }
    }

    class Sumator
    {
        private int[] licz;

        public Sumator(int[] licz)
        {
            this.licz = licz;
        }

        public int Suma()
        {
            int suma = 0;
            foreach (int licznik in licz)
            {
                suma += licznik;
            }
            return suma;
        }

        public int SumaPodziel3()
        {
            int suma = 0;
            foreach (int licznik in licz)
            {
                if (licznik % 3 == 0)
                {
                    suma += licznik;
                }
            }

            return suma;
        }

        public int IleElementow()
        {
            return licz.Length;
        }

        public void WypiszElementy()
        { 
            Console.Write("Elementy tablicy:" + string.Join(", ", licz));
        }
        public void WypiszElementyWZakresie(int lowIndex, int highIndex)
        {
            for (int i = Math.Max(0, lowIndex); i <= Math.Min(highIndex, licz.Length - 1); i++)
            {
                Console.WriteLine($"Element[{i}] = {licz[i]}");
            }
        }
    }
    
}
