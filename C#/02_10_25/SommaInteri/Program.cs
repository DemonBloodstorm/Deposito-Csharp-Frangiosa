using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero, somma = 0, contatore = 0;
        do
        {
            Console.Write("Inserisci un numero: ");
            numero = int.Parse(Console.ReadLine());
            somma += numero;
            if (numero != 0)
            {
                contatore++;
            }
        } while (numero != 0);
        Console.WriteLine("La somma dei numeri inseriti è: " + somma);
        Console.WriteLine("Hai inserito " + contatore + " numeri.");
    }
}