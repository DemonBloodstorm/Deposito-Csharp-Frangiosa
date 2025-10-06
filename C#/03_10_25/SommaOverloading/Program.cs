using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero1, numero2, numero3;
        double numero4, numero5;
        Console.WriteLine("Cosa vuoi fare?");
        Console.WriteLine("1. Sommare due numeri interi");
        Console.WriteLine("2. Sommare due numeri decimali");
        Console.WriteLine("3. Sommare tre numeri interi");
        int scelta = int.Parse(Console.ReadLine());
        switch (scelta)
        {
            case 1:
                Console.WriteLine("Inserisci due numeri interi:");
                numero1 = int.Parse(Console.ReadLine());
                numero2 = int.Parse(Console.ReadLine());
                Console.WriteLine("La somma dei due numeri è: " + Somma(numero1, numero2));
                break;
            case 2:
                Console.WriteLine("Inserisci due numeri decimali:");
                numero4 = double.Parse(Console.ReadLine());
                numero5 = double.Parse(Console.ReadLine());
                Console.WriteLine("La somma dei due numeri è: " + Somma(numero4, numero5));
                break;
            case 3:
                Console.WriteLine("Inserisci tre numeri interi:");
                numero1 = int.Parse(Console.ReadLine());
                numero2 = int.Parse(Console.ReadLine());
                numero3 = int.Parse(Console.ReadLine());
                Console.WriteLine("La somma dei tre numeri è: " + Somma(numero1, numero2, numero3));
                break;
            default:
                Console.WriteLine("Scelta non valida");
                break;
        }
    }

    public static int Somma(int x, int y)
    {
        return x + y;
    }

    public static double Somma(double x, double y)
    {
        return x + y;
    }

    public static int Somma(int x, int y, int z)
    {
        return x + y + z;
    }
}