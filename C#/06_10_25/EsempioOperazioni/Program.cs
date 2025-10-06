using System;

class Operazioni
{
    public int Somma(int a, int b)
    {
        return a + b;
    }

    public int Moltiplica(int a, int b)
    {
        return a * b;
    }

    public void StampaRisultato(int risultato)
    {
        Console.WriteLine($"Il risultato è: {risultato}");
    }
}

public class EsempioOperazioni
{
    public static void Main(string[] args)
    {
        int numero, numero2;
        Operazioni op = new Operazioni();
        Console.WriteLine($"Inserisci primo numero");
        numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"Inserisci secondo numero");
        numero2 = int.Parse(Console.ReadLine());
        
        int somma = op.Somma(numero, numero2);
        op.StampaRisultato(somma);
        int moltiplicazione = op.Moltiplica(numero2, numero2);
        op.StampaRisultato(moltiplicazione);
        
        
    }
}