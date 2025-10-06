using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
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

            Console.WriteLine($"Vuoi un altro gusto? (sì/no)");
            risposta = Console.ReadLine().ToLower();
            try
            {
                if (risposta != "sì" && risposta != "no")
                {
                    Console.WriteLine("Risposta non valida!");
                    continue;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Risposta non valida inserire sì o no!");
                continue;
            }
            
            totale += Utils.CalcolaTotale(scelta, quantita);
            Console.WriteLine($"Il totale è: {totale}€");

            
        }
    }
}