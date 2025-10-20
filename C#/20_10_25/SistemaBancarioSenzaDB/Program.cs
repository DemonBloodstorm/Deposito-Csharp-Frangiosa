using System;
using System.Collections.Generic;

public class MostraMenu
{
    public void Menu()
    {
        Console.WriteLine("2. Apri uno nuovo conto");
        Console.WriteLine("3. Deposita denaro");
        Console.WriteLine("4. Preleva denaro");
        Console.WriteLine("5. Visualizza saldo");
        Console.WriteLine("6. Esci");
    }
}

#region cliente
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public override string ToString() => $"{Id}: {Nome} ({Email})";
}

#endregion cliente

#region conto
public abstract class Conti
{
    public int IdConto { get; set;}
    public int IdCliente { get; set; }
    public decimal Saldo{ get; set; }

    public Conto(int idConto, int idCliente, ICalcoloInteressi strategia)
    {
        IdConto = idConto;
        IdCliente = idCliente;
        strategiaInteressi = strategia;
    }

    public void Deposita(decimal importo)
    {
        Saldo += importo;
        BankContext.Instance.NotificaObservers($"Deposito di {importo:C} su conto {IdConto}");
    }

    public bool Preleva(decimal importo)
    {
        if (Saldo >= importo)
        {
            Saldo -= importo;
            BankContext.Instance.NotificaObservers($"Prelievo di {importo:C} da conto {IdConto}");
            return true;
        }
        else
        {
            BankContext.Instance.NotificaObservers($"Errore: saldo insufficiente per prelievo da conto {IdConto}");
            return false;
        }
    }

    public void ApplicaInteressi()
    {
        decimal interessi = strategiaInteressi.Calcola(Saldo);
        Saldo += interessi;
        BankContext.Instance.NotificaObservers($"Interessi di {interessi:C} applicati a conto {IdConto}");
    }

    public override string ToString() => $"Conto {IdConto} - Cliente {IdCliente} - Saldo: {Saldo:C}";
}

#endregion conto

#region Interessi-Strategy

public interface ICalcoloInteressi
{
    decimal Calcola(decimal saldo);
}

public class InteressiBase : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => saldo * 0.01m; // 1%
}

public class InteressiPremium : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => saldo * 0.03m; // 3%
}

public class NessunInteresse : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => 0m;
}

#endregion Interessi

#region Creazione conti - Factory Method

public interface IContiFactory
{
    public Conti CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia);
}

public class ContoCorrenteFactory : IContiFactory
{
    public Conti CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia) => new ContoCorrente(idConto, idCliente, strategia);
}

public class ContoPremiumFactory : IContiFactory
{
    public Conti CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia) => new ContoPremium(idConto, idCliente, strategia);
}

#endregion Creazione conti - Factory Method

#region BankContext- Singleton 
public sealed class BankContext
{
    Dictionary<int, Cliente> _clienti {get; private set;}
    Dictionary<int, Conti> _conti {get; private set;}
    Dictionary<int, List<Operazioni>> _operazioni {get; private set;}
    private static BankContext? _instance;
    public string Valuta { get; private set; }
    public decimal TassoBase { get; private set; }
    public decimal TassoPremium { get; private set; }
    public string NomeBanca { get; private set; }

    private BankContext()
    {
        Console.WriteLine($"BankContext inizializzato");
    }

    public static BankContext GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new BankContext();
                }
            }
        }
        return _instance;
    }

    public void Messaggio(string message)
    {
        Console.WriteLine($"Messaggio: {message}");
    }

    private BankContext(){
        Clienti = new Dictionary<int, Cliente>();
        Conti = new Dictionary<int, Conti>();
        Operazioni = new Dictionary<int, List<Operazioni>>();
        Valuta = "EUR";
        TassoBase = 0.3m;
        TassoPremium = 0.5m;
        NomeBanca = "Banca di Frangiosa";
    }

    public void ConfigurazioneConto(string valuta, decimal TassoBase, decimal TassoPremium)
    {
        Valuta = valuta;
        TassoBase = TassoBase;
        TassoPremium = TassoPremium;
    }
}

#endregion BankContext

#region Observer

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

public class NuovoConto : ISoggetto
{
    private List<IObserver> NuovoConto = new List<IObserver>();

    public void Registra(IObserver observer)
    {
        NuovoConto.Add(observer);
    }
    public void Rimuovi(IObserver observer)
    {
        NuovoConto.Remove(observer);
    }
    public void Notifica(string message)
    {
        foreach (var observer in NuovoConto)
        {
            observer.Update(message);
        }
    }
    

}

#endregion Observer

public class Program
{
    public static void Main(string[] args)
    {
        
    }
}





