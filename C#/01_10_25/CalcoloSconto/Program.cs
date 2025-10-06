using System;

class Program
{
    static void Main(string[] args)
    {
        double prezzo = 100;
        int sconto = 10;
        double prezzoScontato = prezzo - (prezzo * sconto / 100);
        Console.WriteLine(prezzoScontato);
    }
}
