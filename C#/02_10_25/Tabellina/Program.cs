using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero;
        Console.Write("Inserisci un numero: ");
        numero = int.Parse(Console.ReadLine());
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine(numero + " x " + i + " = " + (numero * i));
        }
    }
}