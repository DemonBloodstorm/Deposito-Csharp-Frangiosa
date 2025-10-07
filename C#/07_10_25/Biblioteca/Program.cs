using System;

public class Libro
{
    public string Titolo { get; }
    public string Autore { get; }
    public int AnnoPubblicazione { get; }

    public Libro(string titolo, string autore, int annoPubblicazione)
    {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = annoPubblicazione;
    }

    public override string ToString()
    {
        return $"{Titolo}, di {Autore}, {AnnoPubblicazione}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        Libro other = obj as Libro;
        if (other == null)
        {
            return false;
        }
        return this.Titolo == other.Titolo && this.Autore == other.Autore && this.AnnoPubblicazione == other.AnnoPubblicazione;
    }

    public override int GetHashCode()
    {
        return this.Titolo.GetHashCode() ^ this.Autore.GetHashCode();
    }
}

public class Biblioteca
{
    public static void Main(string[] args)
    {
        Libro l = null;
        Libro l2 = null;
        string risposta, autore, titolo;
        int annoPubblicazione;

        while (true)
        {
            Console.WriteLine("Vuoi creare un libro? (si/no)");
            risposta = Console.ReadLine()?.ToLower();

            if (risposta == "si")
            {
                Console.WriteLine("Inserisci il titolo del libro:");
                titolo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(titolo))
                {
                    Console.WriteLine("Titolo non valido.");
                    continue;
                }

                Console.WriteLine("Inserisci l'autore del libro:");
                autore = Console.ReadLine();

                Console.WriteLine("Inserisci l'anno di pubblicazione del libro:");
                if (!int.TryParse(Console.ReadLine(), out annoPubblicazione))
                {
                    Console.WriteLine("Anno non valido.");
                    continue;
                }

                l = new Libro(titolo, autore, annoPubblicazione);
                l2 = new Libro(titolo, autore, annoPubblicazione);
            }
            else if (risposta == "no")
            {
                break;
            }
            else
            {
                Console.WriteLine("Risposta non valida.");
            }
        }

        if (l != null)
        {
            Console.WriteLine(l.ToString());
            Console.WriteLine($"{l.Equals(l2)}");
            Console.WriteLine($"{l.GetHashCode()} {l2.GetHashCode()}");
        }
        else
        {
            Console.WriteLine("Nessun libro creato.");
        }
    }
}
