using System;

class Program
{
    public static void Main(string[] args)
    {
        string frase;
        int n_parole = 0, lettere = 0, spazi = 0, punteggiatura = 0;

        Console.WriteLine("Inserisci una frase:");
        frase = Console.ReadLine();
        frase = frase.ToLower();

        foreach (char c in frase)
        {
            if (char.IsWhiteSpace(c))
            {
                spazi++;
            }
        }

        string[] parole = frase.Split(' ');
        foreach (string p in parole)
        {
            if (p.Length > 0)
            {
                n_parole++;
            }
        }

        foreach (char c in frase)
        {
            if (char.IsLetter(c))
            {
                lettere++;
            }
        }

        foreach (char c in frase)
        {
            if (char.IsPunctuation(c))
            {
                punteggiatura++;
            }
        }

        Console.WriteLine("La frase contiene " + n_parole + " parole. ");
        Console.WriteLine("La frase contiene " + lettere + " lettere.");
        Console.WriteLine("La frase contiene " + spazi + " spazi.");
        Console.WriteLine("La frase contiene " + punteggiatura + " caratteri di punteggiatura.");
    }
}