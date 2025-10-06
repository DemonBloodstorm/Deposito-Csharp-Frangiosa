using System;

class Program
{
    public static void Main(string[] args)
    {
        double primoNumero, secondoNumero;
        string operatore;

        Console.Write("Inserisci il primo numero: ");
        primoNumero = double.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        secondoNumero = double.Parse(Console.ReadLine());

        Console.Write("Inserisci l'operatore (+ o -): ");
        operatore = Console.ReadLine();

        double risultato = 0; // variabile per il risultato

        if (operatore == "+")
        {
            risultato = primoNumero + secondoNumero;
            Console.WriteLine("Risultato: " + risultato);
        }
        else if (operatore == "-")
        {
            risultato = primoNumero - secondoNumero;
            Console.WriteLine("Risultato: " + risultato);
        }
        else
        {
            Console.WriteLine("Operatore non valido!");
        }
    }
}
