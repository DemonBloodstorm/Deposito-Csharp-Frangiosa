using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

interface ISoggetto
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string message);
}

public class centroMeteo : ISoggetto
{
    private List<IObserver> observers = new List<IObserver>();
    public string nome{get; private set;}
    private string _dati;
    public string Dati
    {
        get { return _dati; }
        set
        {
            _dati = value;
            Notifica(_dati);
        }
    }
    
    public void Registra(IObserver observer)
    {
        observers.Add(observer);
    }
    public void Rimuovi(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void Notifica(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
    public centroMeteo(string nome)
    {
        this.nome = nome;
    }

    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine($"Meteo aggiornato in {dati} alle ore {DateTime.Now.Hour}:{DateTime.Now.Minute}");
        Notifica(dati);
    }
}

public class DisplayConsole : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Dati raccolti dal centro: meteo {message}");
    }
}

public class DisplayMobile : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Il centro ha registrato: meteo {message}");
    }
}
// public class Menu
//     {
//         public void  MostraMenu()
//         {
//             Console.WriteLine("1. Registra nuovo centro meteo");
//             Console.WriteLine("2. Rimuovi centro meteo");
//             Console.WriteLine("3. Aggiorna meteo");
//             Console.WriteLine("4. Crea nuovo Display");
//             Console.WriteLine("5. Rimuovi Display");
//             Console.WriteLine($"6. Esci");
            
//         }
//     }

public class Program
{
    public static void Main(string[] args)
    {
        List<centroMeteo> centriMeteo = new List<centroMeteo>();
        //centroMeteo centro = new centroMeteo();
        Menu menu = new Menu();
        int scelta;
        string nome;
        DisplayConsole console = new DisplayConsole();
        DisplayMobile mobile = new DisplayMobile();
        string input;
        centro.Registra(console);
        centro.Registra(mobile);
        Console.WriteLine($"Inserisci meteo attuale(soleggiato, nuvoloso, pioggia):");
        input = Console.ReadLine();
        centro.AggiornaMeteo(input);
        
    }
}