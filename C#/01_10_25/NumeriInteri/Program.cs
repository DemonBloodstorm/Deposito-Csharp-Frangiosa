using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero = 0, somma = 0;
        while (true)
        {
            Console.WriteLine("Inserisci un numero intero: ");
            numero = int.Parse(Console.ReadLine());
            if (numero < 0)
            {
                break;
            }
            else
            {
                somma += numero;
            }
        }
        Console.WriteLine("La somma dei numeri inseriti è: " + somma);
    }
}