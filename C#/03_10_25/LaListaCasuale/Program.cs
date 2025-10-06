using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<int> lista = new List<int>();
        Random ran = new Random();
        int numeroDaTrovare, pari = 0;
        bool trovato = false;

        for (int i = 0; i < 10; i++)
        {
            lista.Add(ran.Next(1, 101));
        }

        Console.WriteLine("\nLa lista è:");
        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }

        Console.WriteLine($"\nQuale numero vuoi trovare nella lista?");
        numeroDaTrovare = int.Parse(Console.ReadLine());
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == numeroDaTrovare)
            {
                Console.WriteLine($"\nIl numero {numeroDaTrovare} è presente nella lista all'indice {i + 1}.\n");
                trovato = true;
                break;
            }
        }
        if (!trovato)
        {
            Console.WriteLine($"Il numero {numeroDaTrovare} non è presente nella lista.\n");
        }

        foreach (int numero in lista)
        {
            if (numero % 2 == 0)
            {
                Console.WriteLine($"Il numero {numero} è pari.");
                pari++;
            }
        }

        Console.WriteLine($"\nCi sono {pari} numeri pari nella lista.");
    }
}