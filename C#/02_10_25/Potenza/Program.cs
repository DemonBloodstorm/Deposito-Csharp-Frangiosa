using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Inserisci la base:");
        int baseNum = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci l'esponente:");
        int esponente = int.Parse(Console.ReadLine());

        int risultato = Potenza(baseNum, esponente);

        Console.WriteLine(baseNum + " elevato a " + esponente + " è uguale a " + risultato);
    }

    public static int Potenza(int baseNum, int esponente)
    {
        int risultato = 1;
        for (int i = 0; i < esponente; i++)
        {
            risultato *= baseNum;
        }
        return risultato;
    }
}
