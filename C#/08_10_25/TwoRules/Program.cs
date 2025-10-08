using System;
using System.Collections.Generic;

public class Esercito
{
    public string NomeEsercito { get; set; }
    public string Comandante { get; set; }

    public virtual void Stato()
    {
        Console.WriteLine($"Esercito: {NomeEsercito}, Comandante: {Comandante}");
    }
}
public class Soldato : Esercito
{
    private string nome, grado;
    private int anniServizio;
    public string Nome { get; set; }
    public string Grado { get; set; }
    public int AnniServizio
    {
        get { return anniServizio; }
        set
        {
            if (value >= 0)
            {
                anniServizio = value;
            }
        }
    }
    public virtual string Descrizione()
    {
        return $"Soldato {Nome} di grado {Grado} con {AnniServizio} anni di servizio per {NomeEsercito} sotto il comando di {Comandante}";

    }
}

public class Fante : Soldato
{
    private string arma;
    public string Arma { get; set; }

    public override string Descrizione()
    {
        return $"Fante: {Nome} {Grado} con {AnniServizio} anni di servizio e come arma {Arma} per l'esercito: {NomeEsercito} sotto il comando di {Comandante}";
    }
}

public class Artigliere : Soldato
{
    private int calibro;
    public int Calibro
    {
        get { return calibro; }
        set { calibro = value >= 0 ? value : 0; }
    }

    public override string Descrizione()
    {
        return $"Artigliere: {Nome} {Grado} con {AnniServizio} anni di servizio e un calibro {Calibro} per {NomeEsercito} sotto il comando di {Comandante}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Soldato> soldati = new List<Soldato>();
        string scelta, nome, grado, arma, nomeEsercito, comandante;
        int anniServizio, calibro;
        Console.WriteLine("Inserisci il nome dell'esercito");
        nomeEsercito = Console.ReadLine();
        Console.WriteLine("Chi è il loro comandante?");
        comandante = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("a. Aggiungi un fante");
            Console.WriteLine("b. Aggiungi un artigliere");
            Console.WriteLine("c. Visualizza tutti i soldati");
            Console.WriteLine("d. Esci");

            scelta = Console.ReadLine().ToLower();
            switch (scelta)
            {
                case "a":
                    Console.WriteLine("Inserisci il nome del fante");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci il grado del fante");
                    grado = Console.ReadLine();
                    Console.WriteLine("Inserisci gli anni di servizio del fante");
                    anniServizio = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci l'arma del fante");
                    arma = Console.ReadLine();
                    soldati.Add(new Fante { Nome = nome, Grado = grado, AnniServizio = anniServizio, Arma = arma, NomeEsercito = nomeEsercito, Comandante = comandante });
                    break;
                case "b":
                    Console.WriteLine("Inserisci il nome dell'artigliere");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci il grado dell'artigliere");
                    grado = Console.ReadLine();
                    Console.WriteLine("Inserisci gli anni di servizio dell'artigliere");
                    anniServizio = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il calibro dell'artigliere");
                    calibro = int.Parse(Console.ReadLine());
                    soldati.Add(new Artigliere { Nome = nome, Grado = grado, AnniServizio = anniServizio, Calibro = calibro, NomeEsercito = nomeEsercito, Comandante = comandante });
                    break;
                case "c":
                    foreach (Soldato soldato in soldati)
                    {
                        Console.WriteLine(soldato.Descrizione());
                    }
                    break;
                case "d":
                    Console.WriteLine($"Buona giornata!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }
    }
}
