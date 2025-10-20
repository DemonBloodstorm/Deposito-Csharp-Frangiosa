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
            Console.WriteLine($"Inserisci nome contatto {i + 1}:");
            nome = Console.ReadLine()?.Trim();

            Console.WriteLine($"Inserisci numero di telefono per {nome}:");
            numero = Console.ReadLine()?.Trim();

            // Controlli di validità
            if (contatti.Count >= 16)
            {
                Console.WriteLine("Errore: la rubrica è piena (massimo 16 contatti).");
                break;
            }

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(numero))
            {
                Console.WriteLine("Errore: nome o numero non possono essere vuoti.");
                continue;
            }

            if (numero.Length < 5)
            {
                Console.WriteLine("Errore: il numero di telefono è troppo corto.");
                continue;
            }

            if (contatti.ContainsKey(nome))
            {
                Console.WriteLine($"Errore: il nome '{nome}' è già presente nella rubrica.");
                continue;
            }

        // Se tutti i controlli passano, aggiungi il contatto alla rubrica
        contatti.Add(nome, numero);
        Console.WriteLine($"Contatto '{nome}' aggiunto con successo!");
    }

    Console.WriteLine($"\nTotale contatti in rubrica: {contatti.Count}");
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

public class QuanteParole // Classe che conta quante volte appare ogni parola in una frase
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

#region terzo esercizio

public class MostraMenu
    {
        void Menu(){
            Console.WriteLine($"1. Aggiungi prodotto");
            Console.WriteLine($"2. Rimuovi prodotto");
            Console.WriteLine($"3. Visualizza prodotti");
            Console.WriteLine($"4. Esci");
        }
    }

    

#endregion terzo esercizio



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
