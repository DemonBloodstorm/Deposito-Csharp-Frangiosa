using System;

class Program
{
    public static void Main(string[] args)
    {
        char carattere;
        string frase;

        Console.WriteLine("Inserisci una frase:");
        frase = Console.ReadLine();
        Console.WriteLine("Inserisci un carattere:");
        carattere = char.Parse(Console.ReadLine());
        Analizza(frase, carattere);
        Analizza(frase, true);
        Analizza(frase, false);
        Analizza(frase);
    }

    public static void Analizza(string frase)
    {
        string fraseSenzaSpazi = frase.Replace(" ", "");
        fraseSenzaSpazi = fraseSenzaSpazi.ToLower();
        int lunghezza = fraseSenzaSpazi.Length;
        Console.WriteLine("La frase senza spazi è lunga: " + lunghezza);
    }

    public static void Analizza(string testo, char carattere)
    {
        int QuantitaCarattere = 0;
        for (int i = 0; i < testo.Length; i++)
        {
            if (testo[i] == carattere)
            {
                QuantitaCarattere++;
            }
        }
        Console.WriteLine("Il carattere '" + carattere + "' appare " + QuantitaCarattere + " volte nella stringa.");
    }
    
    public static void Analizza(string testo, bool contaVocali)
{
    int quantita = 0;
    string vocali = "aeiou";
    string consonanti = "bcdfghjklmnpqrstvwxyz";

    testo = testo.ToLower();
    for (int i = 0; i < testo.Length; i++)
    {
        char c = testo[i];
        if (contaVocali)
        {
            if (vocali.Contains(c))
                quantita++;
        }
        else
        {
            if (consonanti.Contains(c))
                quantita++;
        }
    }
    if (contaVocali)
        Console.WriteLine("Il numero di vocali è: " + quantita);
    else
        Console.WriteLine("Il numero di consonanti è: " + quantita);
}

}
