using System;
using System.Collections.Generic;

#region primo esercizio
public class Rubrica // Classe che rappresenta una rubrica telefonica
{
    public Dictionary<string, string> contatti = new Dictionary<string, string>(); // Dizionario che contiene i contatti, con chiave nome e valore numero di telefono
    string nome, numero;
    public void AggiungiContatto() // Metodo per aggiungere un contatto alla rubrica
    {   
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Inserisci nome contatto {i + 1}");
            nome = Console.ReadLine();
            Console.WriteLine($"Inserisci numero di telefono per {nome}");
            numero = Console.ReadLine().Trim();
            if (contatti.ContainsKey(nome))
            {
                Console.WriteLine($"Errore: Nome '{nome}' già presente nella rubrica.");
                return;
            }
            else
            {
                if (contatti.Count < 16 && !string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(numero) && contatti.Count > 14)
                {
                    contatti.Add(nome, numero);
                }
                else
                {
                    Console.WriteLine($"Errore: Rubrica piena, nome/numero vuoti o numero troppo corto");
                    continue;
                }
            }
        }
    }
    public void RimuoviContatto() // Metodo per rimuovere un contatto dalla rubrica
    {
        Console.WriteLine($"Inserisci il nome del contatto da rimuovere");
        nome = Console.ReadLine();
        if (contatti.ContainsKey(nome))
        {
            contatti.Remove(nome);
            Console.WriteLine($"Contatto {nome} rimosso con successo.");
        }
        else
        {
            Console.WriteLine($"Errore: Nome '{nome}' non trovato nella rubrica.");
        }
    }
    public void VisualizzaContatti() // Metodo per visualizzare tutti i contatti presenti nella rubrica
    {
        Console.WriteLine("Elenco dei contatti:");
        foreach (var contatto in contatti)
        {
            Console.WriteLine($"{contatto.Key}: {contatto.Value}");
        }
    }
}

#endregion primo esercizio

#region secondo esercizio

public class QuanteParole
{
    Dictionary<string, int> parole;
    private string frase;

    public void contaParole()
    {
        Console.WriteLine($"Scrivi qualcosa: ");
        frase = Console.ReadLine();
        
        parole = new Dictionary<string, int>();
        foreach (var parola in frase.Split(' '))
        {
            if (parole.ContainsKey(parola))
            {
                parole[parola]++;
            }
            else
            {
                parole.Add(parola, 1);
            }
        }
        foreach (var parola in parole)
        {
            Console.WriteLine($"{parola.Key}: {parola.Value}");
        }
    }
}

#endregion secondo esercizio





public class Program
{
    public static void Main(string[] args)
    {
        QuanteParole parole = new QuanteParole();
        Rubrica telefono = new Rubrica();
        parole.contaParole();
        telefono.AggiungiContatto();
        telefono.VisualizzaContatti();
        telefono.RimuoviContatto();
    }
}
