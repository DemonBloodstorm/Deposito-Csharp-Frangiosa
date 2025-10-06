using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero, contatore;
        double somma = 0;
        Console.WriteLine("Quanti numeri vuoi sommare e fare la media?");
        contatore = int.Parse(Console.ReadLine());
        for (int i = 0; i < contatore; i++)
        {
            Console.WriteLine("Inserisci il numero " + (i + 1));
            numero = int.Parse(Console.ReadLine());
            somma += numero;
        }
        Console.WriteLine("La media è: " + (somma / contatore));
    }
}