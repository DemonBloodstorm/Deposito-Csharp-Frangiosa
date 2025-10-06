using System;

class Program
{
    public static void Main(string[] args)
    {
        Random ran = new Random();
        int[,] matrice1 = new int[4, 4];
        int[,] matrice2 = new int[4, 4];
        int[] somma1 = new int[4];
        int[] somma2 = new int[4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrice1[i, j] = ran.Next(1, 51);
            }
        }
        Console.WriteLine($"La prima matrice è: ");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(matrice1[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrice2[i, j] = ran.Next(1, 51);
            }
        }

        Console.WriteLine($"La seconda matrice è: ");
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(matrice2[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                somma1[i] += matrice1[i, j];
                somma2[i] += matrice2[i, j];
            }
            if (somma1[i] > somma2[i])
            {
                Console.WriteLine($"La riga {i+1} della prima matrice ha una somma maggiore della riga {i+1} della seconda matrice.");
            }
            else if (somma1[i] < somma2[i])
            {
                Console.WriteLine($"La riga {i+1} della prima matrice ha una somma minore della riga {i+1} della seconda matrice.");
            }
            else
            {
                Console.WriteLine($"La riga {i+1} della prima matrice ha la stessa somma della riga {i+1} della seconda matrice.");
            }
        }
    }
}