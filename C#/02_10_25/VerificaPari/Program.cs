using System;

class Program
{
    public static void VerificaPari(int numero)
    {
        if (numero % 2 == 0)
        {
            Console.WriteLine(numero + " è pari!");
        }
        else
        {
            Console.WriteLine(numero + " è dispari!");
        }
    }
    public static void Main(string[] args)
    {
        int numero;
        Console.WriteLine("Inserisci un numero intero:");
        numero = int.Parse(Console.ReadLine());
        VerificaPari(numero);
        
    }
}
