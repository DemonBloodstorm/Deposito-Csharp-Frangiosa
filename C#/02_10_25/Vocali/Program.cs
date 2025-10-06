using System;

class Program
{
    public static void Main(string[] args)
    {
        string frase;
        int contatore = 0;

        Console.WriteLine("Inserisci una frase:");
        frase = Console.ReadLine();
        frase = frase.ToLower();

        foreach (char c in frase)
        {
            if ("aeiou".Contains(c))
            {
                contatore++;
            }
        }

        Console.WriteLine("Le vocali sono: " + contatore);
    }
}
