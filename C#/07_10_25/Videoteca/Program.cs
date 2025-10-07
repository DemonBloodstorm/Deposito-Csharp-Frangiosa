using System;

public class film
{
    List<string> Film = new List<string>();
    public string titolo, regista, genere;
    public int annoPubblicazione;

    public void creaFilm(string titolo, string regista, string genere, int annoPubblicazione)
    {
        this.titolo = titolo;
        this.regista = regista;
        this.genere = genere;
        this.annoPubblicazione = annoPubblicazione;
        Film.Add(titolo + " " + regista + " " + genere + " " + annoPubblicazione);
    }

    public void stampaFilm()
    {
        foreach (string f in Film)
        {
            Console.WriteLine(f);
        }
    }

    public void cercaFilm(string genere)
    {
        foreach (string f in Film)
        {
            if (f.Contains(genere))
            {
                Console.WriteLine(f);
            }
        }
    }
}
public class menu
{
    public void stampaMenu()
    {
        Console.WriteLine("1. Crea film");
        Console.WriteLine("2. Stampa film");
        Console.WriteLine("3. Cerca film");
        Console.WriteLine("4. Esci");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        menu m = new menu();
        film f = new film();
        int scelta = 0;

        while (true)
        {
            m.stampaMenu();
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il titolo del film");
                    string titolo = Console.ReadLine();
                    Console.WriteLine("Inserisci il regista del film");
                    string regista = Console.ReadLine();
                    Console.WriteLine("Inserisci il genere del film");
                    string genere = Console.ReadLine();
                    Console.WriteLine("Inserisci l'anno di pubblicazione del film");
                    int annoPubblicazione = int.Parse(Console.ReadLine());
                    f.creaFilm(titolo, regista, genere, annoPubblicazione);
                    break;
                case 2:
                    f.stampaFilm();
                    break;
                case 3:
                    Console.WriteLine("Inserisci il genere del film da cercare");
                    string genereCercato = Console.ReadLine();
                    f.cercaFilm(genereCercato);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }
    }
}