using System;
using System.Collections.Generic;



class Veicolo
{
    private string nome;
    private string modello;
    private double prezzo;

    public Veicolo(string nome, string modello, double prezzo)
    {
        this.nome = nome;
        this.modello = modello;
        this.prezzo = prezzo;
    }

    public string Nome { get; set; }

    public string Modello { get; set; }
    public double Prezzo { get; set; }

    public virtual void VisualizzaInfo()
    {
        Console.WriteLine($"Veicolo: {nome}, Modello: {modello}, Prezzo: {prezzo}€");
    }

    public virtual double CalcolaPrezzoScontato()
    {
        return Prezzo;
    }
}

class Auto : Veicolo
{
    public int NumeroPorte { get; set; }

    public Auto(string nome, string modello, double prezzo, int porte)
        : base(nome, modello, prezzo)
    {
        NumeroPorte = porte;
    }

    public override void VisualizzaInfo()
    {
        Console.WriteLine($"Auto: {Nome}, Modello: {Modello}, Prezzo: {Prezzo}€, Porte: {NumeroPorte}");
    }

    public override double CalcolaPrezzoScontato()
    {
        return Prezzo * 0.9;
    }
}

class Moto : Veicolo
{
    public bool HaSidecar { get; set; }

    public Moto(string nome, string modello, double prezzo, bool sidecar)
        : base(nome, modello, prezzo)
    {
        HaSidecar = sidecar;
    }

    public override void VisualizzaInfo()
    {
        string sidecar = HaSidecar ? "con sidecar" : "senza sidecar";
        Console.WriteLine($"Moto: {Nome}, Modello: {Modello}, Prezzo: {Prezzo}€, {sidecar}");
    }

    public override double CalcolaPrezzoScontato()
    {
        return Prezzo * 0.85;
    }
}

class Program
{
    static List<Veicolo> veicoli = new List<Veicolo>();

    static void Main(string[] args)
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- Menu Gestione Veicoli ---");
            Console.WriteLine("1. Inserisci un veicolo");
            Console.WriteLine("2. Mostra tutti i veicoli");
            Console.WriteLine("3. Mostra prezzi scontati");
            Console.WriteLine("4. Conta veicoli per tipo");
            Console.WriteLine("5. Esci");
            Console.Write("Scelta: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    InserisciVeicolo();
                    break;
                case "2":
                    MostraVeicoli();
                    break;
                case "3":
                    MostraPrezziScontati();
                    break;
                case "4":
                    ContaVeicoli();
                    break;
                case "5":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }
    }

    static void InserisciVeicolo()
    {
        Console.Write("Tipo (auto/moto): ");
        string tipo = Console.ReadLine().ToLower();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Modello: ");
        string modello = Console.ReadLine();

        Console.Write("Prezzo: ");
        double prezzo = double.Parse(Console.ReadLine());

        if (tipo == "auto")
        {
            Console.Write("Numero porte: ");
            int porte = int.Parse(Console.ReadLine());
            veicoli.Add(new Auto(nome, modello, prezzo, porte));
        }
        else if (tipo == "moto")
        {
            Console.Write("Ha sidecar (true/false): ");
            bool sidecar = bool.Parse(Console.ReadLine());
            veicoli.Add(new Moto(nome, modello, prezzo, sidecar));
        }
        else
        {
            Console.WriteLine("Tipo non valido!");
        }
    }

    static void MostraVeicoli()
    {
        Console.WriteLine("\n--- Elenco Veicoli ---");
        foreach (var v in veicoli)
        {
            v.VisualizzaInfo();
        }
    }

    static void MostraPrezziScontati()
    {
        Console.WriteLine("\n--- Prezzi Scontati ---");
        foreach (var v in veicoli)
        {
            Console.WriteLine($"{v.Nome} - Prezzo scontato: {v.CalcolaPrezzoScontato()}€");
        }
    }

    static void ContaVeicoli()
    {
        int autoCount = 0;
        int motoCount = 0;

        foreach (var v in veicoli)
        {
            if (v is Auto) autoCount++;
            if (v is Moto) motoCount++;
        }

        Console.WriteLine($"\nAuto: {autoCount}, Moto: {motoCount}");
    }
}

