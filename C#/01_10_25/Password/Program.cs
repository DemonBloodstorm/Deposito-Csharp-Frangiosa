using System;

class Program
{
    public static void Main(string[] args)
    {
        const int password = 123456789;
        int passwordInserita;
        Console.WriteLine("Inserire password: ");
        passwordInserita = int.Parse(Console.ReadLine());
        if (passwordInserita == password)
        {
            Console.WriteLine("Accesso consentito.");
            Console.WriteLine("Benvenuto!.");
        }
        else
        {
            Console.WriteLine("Password errata");
            Console.WriteLine("Ritenta!");
        }
    }
}