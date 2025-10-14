using System;
using System.Collections.Generic;

public interface IVeicolo
{
    public void Avvia();
    public void MostraTipo();
}

public class Auto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("L'auto sta avviando.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Il veicolo è una auto.");
    }
}
public class Moto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("La moto si sta avviando.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Il veicolo è una moto.");
    }
}
public class Camion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Il camion si sta avviando.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Il veicolo è una camion.");
    }
}


public sealed class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "auto":
                return new Auto();
            case "moto":
                return new Moto();
            case "camion":
                return new Camion();
            default:
                Console.WriteLine("Tipo di veicolo non riconosciuto.");
                return null;
        }
    }
}

public sealed class RegistroVeicoli
{
    private static readonly RegistroVeicoli _instance = new RegistroVeicoli();
    private List<IVeicolo> _veicoliCreati = new List<IVeicolo>();

    private RegistroVeicoli()
    {
        _veicoliCreati = new List<IVeicolo>();
    }

    public static RegistroVeicoli Istanza
    {
        get
        {
            return _instance;
        }
    }
    public void RegistraVeicolo(IVeicolo veicolo)
    {
        if (veicolo != null)
        _veicoliCreati.Add(veicolo);
    }

    public void StampaTuttiVeicoli()
    {
        if (_veicoliCreati.Count == 0)
        {
            Console.WriteLine("Nessun veicolo registrato.");
            return;
        }else{
            foreach (IVeicolo veicolo in _veicoliCreati)
            {
                veicolo.MostraTipo();
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool continua = true;
        string risposta;
        string tipo;

            Console.WriteLine("=== Gestione Veicoli (Factory + Singleton) ===\n");

            while (continua)
            {
                Console.Write("Inserisci il tipo di veicolo da creare (Auto/Moto/Camion): ");
                tipo = Console.ReadLine();

                try
                {
                IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo);
                    if (veicolo != null)
                    {
                        veicolo.Avvia();
                        RegistroVeicoli.Istanza.RegistraVeicolo(veicolo);
                        RegistroVeicoli.Istanza.StampaTuttiVeicoli();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: Tipo di veicolo non riconosciuto.");
                }

                Console.Write("Vuoi creare un altro veicolo? (s/n): ");
                risposta = Console.ReadLine().ToLower();
                if (risposta != "s")
                    continua = false;

                Console.WriteLine();
            }

            Console.WriteLine("Programma terminato. Arrivederci!");
    }
}

