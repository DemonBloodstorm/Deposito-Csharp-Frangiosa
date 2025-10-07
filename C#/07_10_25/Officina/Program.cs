using System;

public class Macchina
{
    public string motore;
    public int sospensioni, nmModifiche = 0;
    public float velocitaMac;

    public Macchina(string motore, int sospensioni, int nmModifiche, float velocitaMac)
    {
        this.motore = motore;
        this.sospensioni = sospensioni;
        this.nmModifiche = nmModifiche;
        this.velocitaMac = velocitaMac;
    }

    public void Modifica(Utente utente)
    {
        Console.WriteLine("Cosa vuoi modificare? (motore/sospensioni/velocita)");
        string modifica = Console.ReadLine()?.ToLower();

        if (modifica == "motore")
        {
            Console.Write("Inserisci nuovo motore: ");
            this.motore = Console.ReadLine();
            nmModifiche++;
            utente.credito -= 100;
        }
        else if (modifica == "sospensioni")
        {
            Console.Write("Inserisci nuovo livello sospensioni: ");
            this.sospensioni = int.Parse(Console.ReadLine());
            nmModifiche++;
            utente.credito -= 100;
        }
        else if (modifica == "velocita")
        {
            this.velocitaMac += 10;
            nmModifiche++;
            utente.credito -= 100;
        }

        Console.WriteLine($"Modifica eseguita! Totale modifiche: {nmModifiche}");
        Console.WriteLine($"Credito residuo: {utente.credito}");
    }
}

public class Utente
{
    public List<Macchina> macchine = new List<Macchina>();
    public string nome;
    public int credito;


    public Utente(string nome, int credito)
    {
        this.nome = nome;
        this.credito = credito;
    }

    public void listaMacchine()
    {
        for (int i = 0; i < macchine.Count; i++)
        {
            Console.WriteLine($"Macchina {i}: {macchine[i].motore}, {macchine[i].sospensioni}, {macchine[i].nmModifiche}, {macchine[i].velocitaMac}");
        }
    }
}

public class Officina
{
    public static void Main(string[] args)
    {
        Console.Write("Inserisci il tuo nome: ");
        string nomeUtente = Console.ReadLine();
        Utente utente = new Utente(nomeUtente, 500);

        utente.macchine.Add(new Macchina("diesel", 2, 1, 120.5f));
        utente.macchine.Add(new Macchina("benzina", 3, 2, 130.0f));
        utente.macchine.Add(new Macchina("benzina", 3, 3, 110.0f));

        Console.WriteLine($"\nBenvenuto in Officina, {utente.nome}");

        while (true)
        {
            Console.WriteLine($"Hai {utente.credito} crediti");
            Console.WriteLine("Vuoi modificare la macchina? (si/no)");
            string risposta = Console.ReadLine()?.ToLower();

            if (risposta == "si")
            {
                Console.WriteLine("Ecco l'elenco delle tue macchine:");
                utente.listaMacchine();

                Console.Write("Inserisci il numero della macchina da modificare: ");
                if (int.TryParse(Console.ReadLine(), out int scelta) && scelta >= 0 && scelta < utente.macchine.Count)
                {
                    utente.macchine[scelta].Modifica(utente);
                }
                else
                {
                    Console.WriteLine("Scelta non valida.");
                }
            }
            else if (risposta == "no")
            {
                Console.WriteLine("Vuoi modificare un'altra macchina? (si/no)");
                string risposta2 = Console.ReadLine()?.ToLower();

                if (risposta2 == "si")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Ok, grazie per aver utilizzato il nostro servizio.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Risposta non valida, riprova.");
            }
        }
    }
}
