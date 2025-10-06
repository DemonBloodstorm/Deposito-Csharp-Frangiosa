using System;

class Program
{
    public static void Main(string[] args)
    {
        int numero;
        Console.WriteLine("Inserire numero");
        numero = int.Parse(Console.ReadLine());
        if (numero % 2 == 0)
        {
            Console.WriteLine("Il numero è pari");
        }
        else
        {
            Console.WriteLine("Il numero è dispari");
        }
    }
}