using System;

class Program
{
    public static void Main(string[] args)
    {
        double primoNumero, secondoNumero, risultato;
        char operazione, continuare;
        do
        {
            Console.Write("Inserisci il primo numero: ");
            primoNumero = double.Parse(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            secondoNumero = double.Parse(Console.ReadLine());
            Console.Write("Inserisci l'operazione (+, -, *, /): ");
            operazione = char.Parse(Console.ReadLine());
            switch (operazione)
            {
                case '+':
                    risultato = primoNumero + secondoNumero;
                    break;
                case '-':
                    risultato = primoNumero - secondoNumero;
                    break;
                case '*':
                    risultato = primoNumero * secondoNumero;
                    break;
                case '/':
                    risultato = primoNumero / secondoNumero;
                    break;
                default:
                    Console.WriteLine("Operazione non valida!");
                    return;
            }
            Console.WriteLine("Il risultato è: " + risultato);
            Console.WriteLine("Vuoi continuare? (Inserisci 'q' o 'Q' per uscire)");
            continuare = char.Parse(Console.ReadLine());
        } while (continuare != 'q' && continuare != 'Q');
    }
}