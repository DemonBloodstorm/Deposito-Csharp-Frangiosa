using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Inserisci una password:");
        string password = Console.ReadLine();

        if (password.Length < 8)
        {
            Console.WriteLine("Password troppo corta");
            return;
        }

        if (password.Trim().Length != password.Length)
        {
            Console.WriteLine("Password contiene spazi all'inizio o alla fine");
            return;
        }

        bool hasUpper = false;
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUpper = true;
                break;
            }
        }
        if (!hasUpper)
        {
            Console.WriteLine("Password non contiene maiuscole");
            return;
        }

        bool hasDigit = false;
        foreach (char c in password)
        {
            if (char.IsDigit(c))
            {
                hasDigit = true;
                break;
            }
        }
        if (!hasDigit)
        {
            Console.WriteLine("Password non contiene numeri");
            return;
        }

        Console.WriteLine("Password valida!");
    }
}
