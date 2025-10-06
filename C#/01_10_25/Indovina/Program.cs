using System;

using System;

class Program
{
    public static void Main(string[] args)
    {
        const int NUMERO_SEGRETO = 15;
        int tentativo = -1;

        while (tentativo != NUMERO_SEGRETO)
        {
            Console.Write("Indovina il numero segreto (0-100): ");
            tentativo = int.Parse(Console.ReadLine());

            if (tentativo < NUMERO_SEGRETO)
            {
                Console.WriteLine("Il numero segreto è maggiore di " + tentativo);
            }
            else if (tentativo > NUMERO_SEGRETO)
            {
                Console.WriteLine("Il numero segreto è minore di " + tentativo);
            }
        }

        Console.WriteLine("Hai indovinato il numero segreto!");
    }
}

