using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        List<int> lista = new List<int>();
        Random ran = new Random();
        int carica = 0;

        for (int i = 0; i < 15; i++)
        {
            lista.Add(ran.Next(1, 21));
        }

        Console.WriteLine("\nLa lista è:");
        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }

        for (int i = 0; i < lista.Count; i++)
        {
            for (int j = i + 1; j < lista.Count; j++)
            {
                if (lista[i] == lista[j])
                {
                    lista.RemoveAt(j);
                    j--;
                }
            }
        }

        lista.Sort();

        // for (int i = 0; i < lista.Count; i++)
        // {
        //     for (int j = i + 1; j < lista.Count; j++)
        //     {
        //         if (lista[i] > lista[j])
        //         {
        //             carica = lista[i];
        //             lista[i] = lista[j];
        //             lista[j] = carica;
        //         }
        //     }
        // }

        Console.WriteLine("\nLa lista ordinata è:");
        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
}