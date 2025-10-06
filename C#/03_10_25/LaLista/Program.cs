using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<int> lista = new List<int>();
        string scelta;

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Inserisci il numero {i + 1}:");
            lista.Add(int.Parse(Console.ReadLine()));
        }

        Console.WriteLine($"Quali numeri vuoi eliminare dalla lista?");
        scelta = Console.ReadLine();
        string[] numeriDaEliminare = scelta.Split(' ');
        foreach (string numero in numeriDaEliminare)
        {
            if (int.TryParse(numero, out int numeroDaEliminare))
            {
                lista.Remove(numeroDaEliminare);
            }
        }
        

        Console.WriteLine("I numeri inseriti sono:");
        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
}