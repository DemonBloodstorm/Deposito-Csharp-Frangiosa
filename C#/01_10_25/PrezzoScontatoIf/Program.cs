using System;

class Program
{
    public static void Main(string[] args)
    {
        float prezzo;
        Console.WriteLine("Inserire prezzo");
        prezzo = float.Parse(Console.ReadLine());
        if (prezzo >= 100)
        {
            Console.WriteLine("Prezzo scontato: " + prezzo * 0.9);
        }
        else
        {
            Console.WriteLine("Prezzo: " + prezzo);
        }
    }
}