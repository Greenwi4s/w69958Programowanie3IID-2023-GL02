using System;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Sprawdź, czy liczba jest parzysta czy nieparzysta");
            Console.WriteLine("2. Wypisz wszystkie parzyste liczby od 1 do N");
            Console.WriteLine("3. Oblicz silnię z liczby");
            Console.WriteLine("4. Gra w zgadywanie liczby");
            Console.WriteLine("5. Wyjście");

            Console.Write("Wybierz opcję (1-5): ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    ParzystaNieparzysta();
                    break;
                case "2":
                    ParzysteLiczby();
                    break;
                case "3":
                    SilniaProgram();
                    break;
                case "4":
                    GraWZgadywanie();
                    break;
                case "5":
                    Console.WriteLine("Wyjście z programu.");
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void ParzystaNieparzysta()
    {
        Console.Write("Podaj liczbę: ");
        int liczba = int.Parse(Console.ReadLine());
        if (liczba % 2 == 0)
        {
            Console.WriteLine($"Liczba {liczba} jest parzysta.");
        }
        else
        {
            Console.WriteLine($"Liczba {liczba} jest nieparzysta.");
        }
    }

    static void ParzysteLiczby()
    {
        Console.Write("Podaj liczbę N: ");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine($"Parzyste liczby od 1 do {N}:");
        for (int i = 1; i <= N; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }

    static int Silnia(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        return n * Silnia(n - 1);
    }

    static void SilniaProgram()
    {
        Console.Write("Podaj liczbę do obliczenia silni: ");
        int liczba = int.Parse(Console.ReadLine());
        int wynik = Silnia(liczba);
        Console.WriteLine($"Silnia z {liczba} to {wynik}.");
    }

    static void GraWZgadywanie()
    {
        Random random = new Random();
        int liczbaDoOdgadniecia = random.Next(1, 101);
        int proby = 0;
        int proba = 0;

        Console.WriteLine("Odgadnij liczbę (od 1 do 100):");

        while (proba != liczbaDoOdgadniecia)
        {
            proba = int.Parse(Console.ReadLine());
            proby++;

            if (proba < liczbaDoOdgadniecia)
            {
                Console.WriteLine("Za mało! Spróbuj ponownie.");
            }
            else if (proba > liczbaDoOdgadniecia)
            {
                Console.WriteLine("Za dużo! Spróbuj ponownie.");
            }
        }

        Console.WriteLine($"Gratulacje! Zgadłeś liczbę {liczbaDoOdgadniecia} za {proby} razem.");
    }
}
