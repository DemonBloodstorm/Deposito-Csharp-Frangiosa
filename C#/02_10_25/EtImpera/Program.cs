using System;

class Program
{
    public static void Main(string[] args)
    {
        int dividendo = 0, divisore = 0, quoziente = 0;
        Console.WriteLine("Inserisci il dividendo:");
        dividendo = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il divisore:");
        divisore = int.Parse(Console.ReadLine());
        Dividi(dividendo, divisore, out quoziente);
        Console.WriteLine("Il quoziente è " + quoziente);
    }

    static void Dividi(int dividendo, int divisore, out int quoziente)
    {
        quoziente = dividendo / divisore;
    }
}