using System;

class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int[,] matrice = new int[5, 5];
        int sommaDiagonale = 0, sommaDiagonaleSecondaria = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrice[i, j] = random.Next(1, 21);
                Console.Write(matrice[i, j] + " ");
            }
            Console.WriteLine();
        }


        for (int i = 0; i < 5; i++)
        {
            sommaDiagonale += matrice[i, i];
        }
        for (int i = 0; i < 5; i++)
        {
            sommaDiagonaleSecondaria += matrice[i, 4 - i];
        }

        if (sommaDiagonale > sommaDiagonaleSecondaria)
        {
            Console.WriteLine("La somma della diagonale principale è maggiore della somma della diagonale secondaria");
        }
        else if (sommaDiagonale < sommaDiagonaleSecondaria)
        {
            Console.WriteLine("La somma della diagonale secondaria è maggiore alla somma della diagonale principale");
        }
        else
        {
            Console.WriteLine("Le somme delle due diagonali sono uguali");
        }
    }
} 