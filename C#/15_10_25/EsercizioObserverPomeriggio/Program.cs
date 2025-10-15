using System;
using System.Collections.Generic;

interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

interface ISubject
{
    void Aggiungi(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string nomeUtente);
}

public class gestoreCreazioneUtente : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    public void Aggiungi(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void Rimuovi(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void Notifica(string nomeUtente)
    {
        foreach(var observer in _observers){
            observer.NotificaCreazione(nomeUtente);
        }
    }
    public void CreaUtente(string nome)
    {
        
        Notifica(nome);
    }
}
public class Utente
{
    public string Nome{get;set;}
    public override string ToString()
    {
        return $"Nome utente: {Nome}";
    }
}
public class UserFactory
{
    private static UserFactory? _instanza;
    private static readonly object _lock = new object();
    public static UserFactory Istanza{
        get{
            if(_instanza == null)
            lock(_lock){
                if(_instanza == null)
                _instanza = new UserFactory();
            }
            return _instanza;
        }
    }
    public static Utente Crea(string nome)
    {
        return new Utente{Nome = nome};
    }
}

public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Utente {nomeUtente} creato");
    }
}
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Invio email di marketing a {nomeUtente}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}