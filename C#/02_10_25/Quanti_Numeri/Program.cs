using System;

class Program
{
    public static void Main(string[] args)
    {
        string frase;
        int contatore = 0;

        Console.WriteLine("Inserisci una frase:");
        frase = Console.ReadLine();
        foreach (char c in frase)
        {
            if (char.IsDigit(c))
            {
                contatore++;
            }
        }
        Console.WriteLine("La frase contiene " + contatore + " numeri.");
    }
}
