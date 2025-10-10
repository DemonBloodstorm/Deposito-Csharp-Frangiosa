using System;
using System.Collections.Generic;

public abstract class DispositivoElettronico // Classe astratta base per dispositivi elettronici
{
    public string Modello { get; set; }

    public DispositivoElettronico(string modello) // Costruttore base per dispositivi elettronici
    {
        Modello = modello;
    }

    public abstract void Accendi(); // Metodo astratto per accendere il dispositivo
    public abstract void Spegni(); // Metodo astratto per spegnere il dispositivo
    public abstract void MostraInfo(); // Metodo astratto per mostrare le informazioni del dispositivo
}

public class Computer : DispositivoElettronico // Classe derivata Computer che eredita da DispositivoElettronico
{
    public Computer(string modello) : base(modello) { } // Costruttore per Computer che chiama il costruttore base

    public override void Accendi()
    {
        Console.WriteLine("Il computer si avvia..."); // Implementazione del metodo astratto Accendi per Computer
    }

    public override void Spegni()
    {
        Console.WriteLine("Il computer si spegne."); // Implementazione del metodo astratto Spegni per Computer
    }

    public override void MostraInfo() // Implementazione del metodo astratto MostraInfo per Computer
    {
        Console.WriteLine($"Computer modello: {Modello}");
    }
}

public class Stampante : DispositivoElettronico // Classe derivata Stampante che eredita da DispositivoElettronico
{
    public Stampante(string modello) : base(modello) { } // Costruttore per Stampante che chiama il costruttore base

    public override void Accendi()
    {
        Console.WriteLine("La stampante si accende."); // Implementazione del metodo astratto Accendi per Stampante
    }

    public override void Spegni()
    {
        Console.WriteLine("La stampante va in standby"); // Implementazione del metodo astratto Spegni per Stampante
    }

    public override void MostraInfo()
    {
        Console.WriteLine($"Stampante modello: {Modello}"); // Implementazione del metodo astratto MostraInfo per Stampante
    }
}

public class Program
{
    public static void MetodoPolimorfico(DispositivoElettronico dispositivo) // Metodo polimorfico che accetta dispositivi elettronici
    {
        dispositivo.MostraInfo(); // Chiama il metodo MostraInfo del dispositivo specifico
        dispositivo.Accendi(); // Chiama il metodo Accendi del dispositivo specifico
        dispositivo.Spegni(); // Chiama il metodo Spegni del dispositivo specifico
        Console.WriteLine(); // Spazio tra le righe
    }

    public static void Main(string[] args)
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>(); // Lista di dispositivi elettronici
        dispositivi.Add(new Computer("Dell XPS")); // Aggiunge un computer alla lista
        dispositivi.Add(new Stampante("HP LaserJet")); // Aggiunge una stampante alla lista

        MetodoPolimorfico(dispositivi[0]); // Chiama MetodoPolimorfico per il computer
        MetodoPolimorfico(dispositivi[1]); // Chiama MetodoPolimorfico per la stampante
    }
}
