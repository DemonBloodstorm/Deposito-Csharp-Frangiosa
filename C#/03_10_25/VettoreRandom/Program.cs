using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Random ran = new Random();
        int[] vettore = new int[9];
        int max = -1, min = 101;
        for (int i = 0; i < vettore.Length; i++)
        {
            vettore[i] = ran.Next(1, 101);
            Console.WriteLine($"{vettore[i]}");
            if (vettore[i] > max)
            {
                max = vettore[i];
            }
            if (vettore[i] < min)
            {
                min = vettore[i];
            }
        }
        Console.WriteLine($"Il numero più grande è: {max}");
        Console.WriteLine($"Il numero più piccolo è: {min}");
    }
}