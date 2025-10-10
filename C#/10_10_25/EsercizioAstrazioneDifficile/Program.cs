using System;
using System.Collections.Generic;


// Classe astratta Corso
public abstract class Corso
{
    private string titolo;
    private int durataOre;
    private Docente docente;

    public string Titolo
    {
        get { return titolo; }
        set { if (!string.IsNullOrWhiteSpace(value)) titolo = value; }
    }

    public int DurataOre
    {
        get { return durataOre; }
        set { if (value > 0) durataOre = value; }
    }

    public Docente Docente
    {
        get { return docente; }
        set { docente = value; }
    }

    public abstract void ErogaCorso();
    public abstract void StampaDettagli();
}

// Corso in presenza
public class CorsoInPresenza : Corso
{
    private string aula;
    private int numeroPosti;

    public string Aula
    {
        get { return aula; }
        set { if (!string.IsNullOrWhiteSpace(value)) aula = value; }
    }

    public int NumeroPosti
    {
        get { return numeroPosti; }
        set { if (value > 0) numeroPosti = value; }
    }

    public override void ErogaCorso()
    {
        Console.WriteLine($"Il corso in presenza '{Titolo}' si svolge in aula {Aula} con docente {Docente?.Nome}.");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Corso in presenza: {Titolo}, Durata: {DurataOre} ore, Aula: {Aula}, Numero di posti: {NumeroPosti}, Docente: {Docente?.Nome}");
    }
}

// Corso online
public class CorsoOnline : Corso
{
    private string piattaforma;
    private string linkAccesso;

    public string Piattaforma
    {
        get { return piattaforma; }
        set { if (!string.IsNullOrWhiteSpace(value)) piattaforma = value; }
    }

    public string LinkAccesso
    {
        get { return linkAccesso; }
        set { if (!string.IsNullOrWhiteSpace(value)) linkAccesso = value; }
    }

    public override void ErogaCorso()
    {
        Console.WriteLine($"Il corso online '{Titolo}' è accessibile su {Piattaforma} al link {LinkAccesso} con docente {Docente?.Nome}.");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Corso online: {Titolo}, Durata: {DurataOre} ore, Piattaforma: {Piattaforma}, Link: {LinkAccesso}, Docente: {Docente?.Nome}");
    }
}

public class Docente
{
    private string _nome;
    private string _materia;

    public string Nome
    {
        get { return _nome; }
        set { if (!string.IsNullOrWhiteSpace(value)) _nome = value; }
    }

    public string Materia
    {
        get { return _materia; }
        set { if (!string.IsNullOrWhiteSpace(value)) _materia = value; }
    }

    public Docente(string nome, string materia)
    {
        Nome = nome;
        Materia = materia;
    }
}

public class GestoreCorsi
{
    public void GestisciCorso(Corso corso)
    {
        corso.StampaDettagli();
        corso.ErogaCorso();
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        List<Corso> corsi = new List<Corso>();
        GestoreCorsi gestore = new GestoreCorsi();

        while (true)
        {
            Console.WriteLine("MENU CORSI:");
            Console.WriteLine("1. Aggiungi corso in presenza");
            Console.WriteLine("2. Aggiungi corso online");
            Console.WriteLine("3. Visualizza tutti i corsi");
            Console.WriteLine("4. Esci");
            Console.Write("Seleziona un'opzione: ");
            string scelta = Console.ReadLine();

            if (scelta == "1")
            {
                // Corso in presenza
                CorsoInPresenza corsoPres = new CorsoInPresenza();

                Console.Write("Titolo corso: ");
                corsoPres.Titolo = Console.ReadLine();

                Console.Write("Durata ore: ");
                corsoPres.DurataOre = int.Parse(Console.ReadLine());

                Console.Write("Aula: ");
                corsoPres.Aula = Console.ReadLine();

                Console.Write("Numero posti: ");
                corsoPres.NumeroPosti = int.Parse(Console.ReadLine());

                // Docente
                Console.Write("Nome docente: ");
                string nomeDocente = Console.ReadLine();
                Console.Write("Materia docente: ");
                string materia = Console.ReadLine();
                corsoPres.Docente = new Docente(nomeDocente, materia);

                corsi.Add(corsoPres);
            }
            else if (scelta == "2")
            {
                // Corso online
                CorsoOnline corsoOn = new CorsoOnline();

                Console.Write("Titolo corso: ");
                corsoOn.Titolo = Console.ReadLine();

                Console.Write("Durata ore: ");
                corsoOn.DurataOre = int.Parse(Console.ReadLine());

                Console.Write("Piattaforma: ");
                corsoOn.Piattaforma = Console.ReadLine();

                Console.Write("Link accesso: ");
                corsoOn.LinkAccesso = Console.ReadLine();

                // Docente
                Console.Write("Nome docente: ");
                string nomeDocente = Console.ReadLine();
                Console.Write("Materia docente: ");
                string materia = Console.ReadLine();
                corsoOn.Docente = new Docente(nomeDocente, materia);

                corsi.Add(corsoOn);
            }
            else if (scelta == "3")
            {
                // Visualizza corsi polimorficamente
                if (corsi.Count == 0)
                {
                    Console.WriteLine("Nessun corso disponibile.\n");
                }
                else
                {
                    foreach (var corso in corsi)
                    {
                        gestore.GestisciCorso(corso);
                    }
                }
            }
            else if (scelta == "4")
            {
                Console.WriteLine("Uscita dal programma.");
                break;
            }
            else
            {
                Console.WriteLine("Opzione non valida.\n");
            }
        }
    }
}
