using System;

class Program
{
    public static void Main(string[] args)
    {
        int[,] matrice;
        int numero = 0;
        int[] sommaRighe;
        int[] sommaColonne;

        Console.WriteLine($"Inserisci la grandezza x della matrice:");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine($"Inserisci la grandezza y della matrice:");
        int y = int.Parse(Console.ReadLine());
        matrice = new int[x, y];
        sommaRighe = new int[x];
        sommaColonne = new int[y];

        for (int i = 0; i < x; i++)
        {
            Console.WriteLine($"Inserisci la riga {i + 1} della matrice: ");
            for (int j = 0; j < y; j++)
            {
                matrice[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine($"La matrice inserita è:");
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Console.Write(matrice[i, j] + " ");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                sommaRighe[i] += matrice[i, j];
            }
        }
        for (int j = 0; j < y; j++)
        {
            for (int i = 0; i < x; i++)
            {
                sommaColonne[j] += matrice[i, j];
            }
        }
        Console.WriteLine($"Le somme delle righe sono:");
        for (int i = 0; i < x; i++)
        {
            Console.WriteLine($"Riga {i + 1}: {sommaRighe[i]}");
        }
        Console.WriteLine($"Le somme delle colonne sono:");
        for (int j = 0; j < y; j++)
        {
            Console.WriteLine($"Colonna {j + 1}: {sommaColonne[j]}");
        }
    }
}