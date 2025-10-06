using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero = 0;
        Console.WriteLine("Inserisci un numero intero positvo:");
        numero = int.Parse(Console.ReadLine());
        if (numero < 0)
        {
            Console.WriteLine("Non inserire numeri negativi!");
        }
        else
        {
            double fattoriale = 1;
            for (int i = 1; i <= numero; i++)
            {
                fattoriale *= i;
            }
            Console.WriteLine("Il fattoriale di " + numero + " è: " + fattoriale);
        }
    }
}