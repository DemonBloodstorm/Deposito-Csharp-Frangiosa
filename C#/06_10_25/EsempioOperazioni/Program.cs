using System;

class Operazioni
{
    public int Somma(int a, int b) // somma due numeri
    {
        return a + b;
    }

    public int Moltiplica(int a, int b) // moltiplica due numeri
    {
        return a * b;
    }

    public void StampaRisultato(int risultato) // stampa il risultato
    {
        Console.WriteLine($"Il risultato è: {risultato}");
    }
}

public class EsempioOperazioni
{
    public static void Main(string[] args)
    {
        // crea un'istanza della classe Operazioni
        Operazioni op = new Operazioni();

        // inizializza le variabili
        int numero, numero2;
        
        // inserisci due numeri 
        Console.WriteLine($"Inserisci primo numero");
        numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"Inserisci secondo numero");
        numero2 = int.Parse(Console.ReadLine());

        // calcola la somma e la moltiplicazione
        int somma = op.Somma(numero, numero2);
        op.StampaRisultato(somma);
        int moltiplicazione = op.Moltiplica(numero2, numero2);
        op.StampaRisultato(moltiplicazione);
        
        
    }
}