using System;
using System.Collections.Generic;

#region menù
public class MostraMenu
{
    public void Menu()
    {
        Console.WriteLine("1. Apri uno nuovo conto");
        Console.WriteLine("2. Deposita denaro");
        Console.WriteLine("3. Preleva denaro");
        Console.WriteLine("4. Visualizza saldo");
        Console.WriteLine("5. Esci");
    }
    
}

#endregion menù

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
public abstract class Conto
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
    public Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia);
}

public class ContoCorrenteFactory : IContiFactory
{
    public Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia) => new ContoCorrente(idConto, idCliente, strategia);
}

public class ContoPremiumFactory : IContiFactory
{
    public Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia) => new ContoPremium(idConto, idCliente, strategia);
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
    public BankNotifier Notificatore { get; private set; }


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

    private BankContext(){
        Clienti = new Dictionary<int, Cliente>();
        Conti = new Dictionary<int, Conti>();
        Operazioni = new Dictionary<int, List<Operazioni>>();
        Valuta = "EUR";
        TassoBase = 0.3m;
        TassoPremium = 0.5m;
        NomeBanca = "Banca di Frangiosa";
        Modificatore = new ModificatoreConto();
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

public class BankNotifier : ISoggetto
{
    private readonly List<IObserver> _observers = new();

    public void Registra(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Rimuovi(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notifica(string message)
    {
        foreach (var obs in _observers)
            obs.Update(message);
    }
}

#endregion Observer

public class Program
{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        int scelta;

        do
        {
            menu.Menu();
            try
            {
                scelta = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Input non valido. Inserisci un numero.");
                continue;
            }
            switch (scelta)
            {
                case 1:
                    AggiungiCliente(banca);
                    break;
                case 2:
                    ApriConto(banca);
                    break;
                case 3:
                    Deposita(banca);
                    break;
                case 4:
                    Preleva(banca);
                    break;
                case 5:
                    VisualizzaSaldi(banca);
                    break;
                case 6:
                    Console.WriteLine("Uscita dal sistema...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
        }while(scelta != 6);
    }
    
    private static void AggiungiCliente(Banca banca)
    {
        Console.WriteLine("Inserisci il nome del cliente:");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome del cliente:");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci l'indirizzo email del cliente:");
        string email = Console.ReadLine();
        Cliente cliente = new Cliente(nome, cognome, telefono, email);
        banca.AggiungiCliente(cliente);
        Console.WriteLine($"Cliente {cliente.Nome} {cliente.Cognome} aggiunto con successo!");
    }
    private static void ApriConto(Banca banca)
    {
        Console.Write("ID conto: ");
        int idConto = int.Parse(Console.ReadLine()!);
        Console.Write("ID cliente: ");
        int idCliente = int.Parse(Console.ReadLine()!);
        Console.Write("Tipo conto (1=Base, 2=Premium): ");
        int tipo = int.Parse(Console.ReadLine()!);

        IContiFactory factory = tipo == 2
            ? new ContoPremiumFactory()
            : new ContoCorrenteFactory();

        banca.Conti[idConto] = factory.CreaConto(idConto, idCliente);
        banca.Notificatore.Notifica($"Aperto conto {idConto} per cliente {idCliente}");
    }
}





