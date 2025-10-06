using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero;
        Console.WriteLine("Inserisci un numero intero:");
        numero = int.Parse(Console.ReadLine());

        Raddoppia(ref numero); // modifica direttamente "numero"

        Console.WriteLine("Il doppio è " + numero);
    }

    static void Raddoppia(ref int numero)
    {
        numero *= 2;
    }
}
