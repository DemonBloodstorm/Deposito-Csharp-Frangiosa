using System;

class Program
{
    public static void Main(string[] args)
    {
        string frase, parola = null;
        int contatore = 0;
        Console.WriteLine("Inserisci una frase:");
        frase = Console.ReadLine();
        foreach (char c in frase)
        {
            if (char.IsLetter(c))
            {
                contatore++;
                parola += c;
            }
        }
        Console.WriteLine("La parola senza spazi è: " + parola);
    }
}