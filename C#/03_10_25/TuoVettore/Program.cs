using System;

class Program
{
    public static void Main(string[] args)
    {
        int n, somma = 0;
        int[] numeri;

        Console.WriteLine("Inserisci il numero di elementi che vuoi nel vettore: ");
        n = int.Parse(Console.ReadLine());
        numeri = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Inserisci il valore intero per l'elemento {i+1}:");
            numeri[i] = int.Parse(Console.ReadLine());
            somma += numeri[i];
        }
        Console.WriteLine($"La somma dei valori inseriti è: {somma}");
    }
}