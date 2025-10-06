using System;

class Program
{
    public static void Main(string[] args)
    {
        const int PASSWORD = 123456;
        int passwordUtente = -1, tentativi = 0;
        do
        {
            Console.Write("Inserisci la password: ");
            passwordUtente = int.Parse(Console.ReadLine());
            if (passwordUtente == PASSWORD)
            {
                Console.WriteLine("Password corretta!");
                Console.WriteLine("Benvenuto!");
            }
            else
            {
                Console.WriteLine("Password errata!");
            }
            tentativi++;
        } while (passwordUtente != PASSWORD && tentativi < 3);
    }
}