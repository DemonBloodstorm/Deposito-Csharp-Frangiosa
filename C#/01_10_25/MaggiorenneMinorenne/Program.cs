using System;

class Program
{
    public static void Main(string[] args)
    {
        int eta;
        const int etaMaggiorenne = 18;
        Console.WriteLine("Inserire eta'");
        eta = int.Parse(Console.ReadLine());
        double etaDouble = eta;
        if (eta >= etaMaggiorenne)
        {
            Console.WriteLine("sei maggiorenne");
        }
        else
        {
            Console.WriteLine("sei minorenne");
        }
    }
}