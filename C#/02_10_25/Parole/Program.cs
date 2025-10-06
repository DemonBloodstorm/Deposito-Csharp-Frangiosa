using System;

class Program
{
    public static void Main(string[] args)
    {
        string parola;
        int vocali = 0, consonanti = 0, spazi = 0;
        Console.WriteLine("Inserisci una frase:");
        parola = Console.ReadLine();
        AnalizzaParola(parola, out vocali, out consonanti, out spazi);
        Console.WriteLine("La frase contiene " + vocali + " vocali, " + consonanti + " consonanti e " + spazi + " spazi.");
    }

    static void AnalizzaParola(string parola, out int vocali, out int consonanti, out int spazi)
    {
        vocali = 0;
        consonanti = 0;
        spazi = 0;
        foreach (char carattere in parola)
        {
            if (char.IsLetter(carattere).Trim() == ' ')
            {
                if ("aeiouAEIOU".Contains(carattere))
                {
                    vocali++;
                }
                else
                {
                    consonanti++;
                }
            }
            else if (char.IsWhiteSpace(carattere))
            {
                spazi++;
            }
        }
    }
}