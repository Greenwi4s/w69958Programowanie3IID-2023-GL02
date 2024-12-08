using System;
using System.Collections.Generic;


class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape.");
    }
}

class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle.");
    }
}

class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a triangle.");
    }
}

class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle.");
    }
}


class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public void UstawImie(string imie) => Imie = imie;
    public void UstawNazwisko(string nazwisko) => Nazwisko = nazwisko;
    public void UstawPesel(string pesel) => Pesel = pesel;

    public int PobierzWiek()
    {
        int year = int.Parse(Pesel.Substring(0, 2));
        int month = int.Parse(Pesel.Substring(2, 2));

        year += (month > 20) ? 2000 : 1900;
        month %= 20;

        DateTime BirthDate = new DateTime(year, month, int.Parse(Pesel.Substring(4, 2)));
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.DayOfYear < BirthDate.DayOfYear) age--;

        return age;
    }

    public string PobierzPlec() => (Pesel[9] % 2 == 0) ? "Kobieta" : "Mezczyzna";

    public virtual string PobierzInformacjeOEdukacji() => "Brak informacji o edukacji.";
    public virtual bool CzyMozeSamWrocicDoDomu() => false;

    public string PobierzPelneImieNazwisko() => $"{Imie} {Nazwisko}";
}


class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWrocicDoDomu { get; set; }

    public void UstawSzkole(string szkola) => Szkola = szkola;
    public void ZmienSzkole(string nowaSzkola) => Szkola = nowaSzkola;

    public string Informacja()
    {
        return PobierzWiek() < 12 && !MozeSamWrocicDoDomu
            ? "Uczeń nie może wracać samodzielnie."
            : "Uczeń może wracać samодzielnie.";
    }

    public override string PobierzInformacjeOEdukacji() => $"Uczeń w szkole: {Szkola}";

    public override bool CzyMozeSamWrocicDoDomu()
    {
        return PobierzWiek() >= 12 || MozeSamWrocicDoDomu;
    }
}


class Nauczyciel : Osoba
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> UczniowieKlasy { get; set; } = new List<Uczen>();

    public void DodajUcznia(Uczen uczen) => UczniowieKlasy.Add(uczen);

    public List<string> KtorzyUcziowieMogaWrocicSamodzielnie()
    {
        var wyniki = new List<string>();
        foreach (var uczen in UczniowieKlasy)
        {
            string decyzja = uczen.CzyMozeSamWrocicDoDomu() ? "Tak" : "Nie";
            wyniki.Add($"{uczen.PobierzPelneImieNazwisko()} - {uczen.PobierzPlec()} - {decyzja}");
        }
        return wyniki;
    }

    public void PodsumowanieKlasy(DateTime data)
    {
        Console.WriteLine($"Dnia: {data:dd.MM.yyyy}");
        Console.WriteLine($"Nauczyciel: {TytulNaukowy} {Imie} {Nazwisko}");
        Console.WriteLine("Lista studentów:");
        int lp = 1;
        foreach (var uczen in UczniowieKlasy)
        {
            string decyzja = uczen.CzyMozeSamWrocicDoDomu() ? "Może" : "Nie może";
            Console.WriteLine($"{lp}. {uczen.Imie} {uczen.Nazwisko} - {uczen.PobierzPlec()} - {decyzja}");
            lp++;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Rectangle());
        shapes.Add(new Triangle());
        shapes.Add(new Circle());

        foreach (var shape in shapes)
        {
            shape.Draw();
        }


        var nauczyciel = new Nauczyciel
        {
            Imie = "Jan",
            Nazwisko = "Kowalski",
            TytulNaukowy = "Dr"
        };

        var uczen1 = new Uczen
        {
            Imie = "Anna",
            Nazwisko = "Nowak",
            Pesel = "12345678901",
            Szkola = "SP1",
            MozeSamWrocicDoDomu = true
        };

        var uczen2 = new Uczen
        {
            Imie = "Piotr",
            Nazwisko = "Zielinski",
            Pesel = "02341234567",
            Szkola = "SP1",
            MozeSamWrocicDoDomu = false
        };

        nauczyciel.DodajUcznia(uczen1);
        nauczyciel.DodajUcznia(uczen2);

        Console.WriteLine("\nKtorzyUcziowieMogaWrocicSamodzielni:");
        foreach (var wynik in nauczyciel.KtorzyUcziowieMogaWrocicSamodzielnie())
        {
            Console.WriteLine(wynik);
        }

        Console.WriteLine("\nPodsumowanie");
        nauczyciel.PodsumowanieKlasy(DateTime.Now);
    }
}
