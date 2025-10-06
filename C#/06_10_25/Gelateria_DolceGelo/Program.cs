using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> gustiOrdinati = new List<int>();
        List<int> quantitaOrdinata = new List<int>();
        const double soglia_sconto = 10;
        double scontoApplicato = 0;
        const double sconto = 0.10;
        int scelta = 0;
        int quantita = 0;
        double totale = 0;
        string risposta = "";

        while (true)
        {
            Utils.StampaMenu();

            Console.WriteLine($"Quale gusto vuoi?");
            try
            {
                scelta = int.Parse(Console.ReadLine());
                if (scelta < 1 || scelta > 5)
                {
                    Console.WriteLine("Scelta non valida!");
                    continue;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Scelta non valida inserire un numero!");
                continue;
            }

            Console.WriteLine($"Quante palline vuoi?");
            try
            {
                quantita = int.Parse(Console.ReadLine());
                if (quantita <= 0)
                {
                    Console.WriteLine("Deve essere magiore di 0!");
                    continue;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Quantita non valida inserire un numero!");
                continue;
            }

            gustiOrdinati.Add(scelta - 1);
            quantitaOrdinata.Add(quantita);
            totale += Utils.CalcolaTotale(scelta, quantita);

            while (true)
            {
                Console.Write("Vuoi un altro gusto? (si/no): ");
                risposta = Console.ReadLine().Trim().ToLower();
                if (risposta == "si" || risposta == "no")
                    break;
                Console.WriteLine("Risposta non valida! Inserisci 'si' o 'no'.");
            }

            if (risposta == "no")
                break;

            
        }
        if (totale >= soglia_sconto)
        {
        scontoApplicato = totale * sconto;
        totale -= scontoApplicato;
        Console.WriteLine($"\nHai diritto a uno sconto del {sconto * 100}%! Risparmio: {scontoApplicato}€");
        }
        Console.WriteLine($"\nTotale finale da pagare: {totale}€");
    } 
}