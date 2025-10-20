using System;
using System.Collections.Generic;

#region menù
public class MostraMenu
{
    public void Menu()
    {
        Console.WriteLine("Benvenuto cosa vuole fare?");
        Console.WriteLine("1. Aggiungi cliente");
        Console.WriteLine("2. Apri uno nuovo conto");
        Console.WriteLine("3. Deposita denaro");
        Console.WriteLine("4. Preleva denaro");
        Console.WriteLine("5. Visualizza saldo");
        Console.WriteLine("6. Cambia valuta di un conto");
        Console.WriteLine("7. Esci");
    }
}
#endregion menù

#region cliente
public class Cliente
{
    private int _id;
    public int Id { get; private set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public Cliente(string nome, string email)
    {
        Id = ++_id;
        Nome = nome;
        Email = email;
    }

    public override string ToString() => $"{Id}: {Nome} ({Email})";
}
#endregion cliente

#region conto
public abstract class Conto
{
    private readonly int _idConto;
    public int IdConto { get; private set; }
    public int IdCliente { get; set; }
    public decimal Saldo { get; set; }
    protected ICalcoloInteressi strategiaInteressi;
    public string Valuta {get; private set;}

    public Conto(int idConto, int idCliente, ICalcoloInteressi strategia)
    {

        IdConto = ++_idConto;
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

    public void CambiaValuta(string nuovaValuta)
    {
        ApplicaInteressi();
        Valuta = nuovaValuta;
        BankContext.Instance.NotificaObservers($"Conto {IdConto} cambiato in valuta {Valuta}.");
    }

    public override string ToString()
    {
        return $"Conto {IdConto} - Cliente {IdCliente} - Saldo: {Saldo:C} - Valuta: {Valuta}";
    }
}

public class ContoCorrente : Conto
{
    public ContoCorrente(int idConto, int idCliente, ICalcoloInteressi strategia)
        : base(idConto, idCliente, strategia) { }
}

public class ContoPremium : Conto
{
    public ContoPremium(int idConto, int idCliente, ICalcoloInteressi strategia)
        : base(idConto, idCliente, strategia) { }
}
#endregion conto

#region Interessi-Strategy
public interface ICalcoloInteressi
{
    decimal Calcola(decimal saldo);
}

public class InteressiBase : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => saldo * 0.01m;
}

public class InteressiPremium : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => saldo * 0.03m;
}

public class NessunInteresse : ICalcoloInteressi
{
    public decimal Calcola(decimal saldo) => 0m;
}
#endregion Interessi-Strategy

#region Creazione conti - Factory Method
public interface IContiFactory
{
    Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia);
}

public class ContoCorrenteFactory : IContiFactory
{
    public Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia)
        => new ContoCorrente(idConto, idCliente, strategia);
}

public class ContoPremiumFactory : IContiFactory
{
    public Conto CreaConto(int idConto, int idCliente, ICalcoloInteressi strategia)
        => new ContoPremium(idConto, idCliente, strategia);
}
#endregion Creazione conti - Factory Method

#region BankContext- Singleton 
public sealed class BankContext
{
    private static readonly object _lock = new object();
    private static BankContext? _instance;

    public Dictionary<int, Cliente> Clienti { get; private set; }
    public Dictionary<int, Conto> Conti { get; private set; }
    public Dictionary<int, List<Operazione>> Operazioni { get; private set; }

    public string Valuta { get; private set; }
    public decimal TassoBase { get; private set; }
    public decimal TassoPremium { get; private set; }
    public string NomeBanca { get; private set; }
    public BankNotifier Notificatore { get; private set; }

    public static BankContext Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new BankContext();
                }
            }
            return _instance;
        }
    }

    private BankContext()
    {
        Clienti = new Dictionary<int, Cliente>();
        Conti = new Dictionary<int, Conto>();
        Operazioni = new Dictionary<int, List<Operazione>>();
        Valuta = "EUR";
        TassoBase = 0.01m;
        TassoPremium = 0.03m;
        NomeBanca = "Banca di Frangiosa";
        Notificatore = new BankNotifier();
    }

    public void NotificaObservers(string message)
    {
        Notificatore.Notifica(message);
    }
}
#endregion BankContext

#region Observer
public interface IObserver
{
    void Update(string message);
}

public interface ISoggetto
{
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string message);
}

public class BankNotifier : ISoggetto
{
    private readonly List<IObserver> _observers = new();

    public void Registra(IObserver observer) => _observers.Add(observer);
    public void Rimuovi(IObserver observer) => _observers.Remove(observer);

    public void Notifica(string message)
    {
        foreach (var obs in _observers)
            obs.Update(message);
    }
}
#endregion Observer

#region Operazioni
public class Operazione
{
    public DateTime Data { get; private set; }
    public string Tipo { get; private set; }
    public decimal Importo { get; private set; }
    public string Descrizione { get; private set; }

    public Operazione(string tipo, decimal importo, string descrizione)
    {
        Data = DateTime.Now;
        Tipo = tipo;
        Importo = importo;
        Descrizione = descrizione;
    }

    public override string ToString() =>
        $"{Data:G} | {Tipo,-12} | {Importo,8:C} | {Descrizione}";
}
#endregion Operazioni

#region Main
public class Program
{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        BankContext banca = BankContext.Instance;
        int scelta = 0;

        do
        {
            menu.Menu();
            Console.Write("Scelta: ");
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
                    CambiaValuta(banca);
                    break;
                case 7:
                    Console.WriteLine("Uscita dal sistema...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

        } while (scelta != 7);
    }

    private static void AggiungiCliente(BankContext banca)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Cliente cliente = new Cliente(nome, email);
        banca.Clienti[cliente.Id] = cliente;

        Console.WriteLine($"Cliente {cliente.Nome} aggiunto con successo! ID: {cliente.Id}");
    }

    private static void ApriConto(BankContext banca)
    {
        Console.Write("ID cliente: ");
        int idCliente = int.Parse(Console.ReadLine()!);
        if (!banca.Clienti.ContainsKey(idCliente))
        {
            Console.WriteLine($"Cliente inesistente");
        }else{
            Console.Write("Tipo conto (1=Base, 2=Premium): ");
            int tipo = int.Parse(Console.ReadLine()!);
            if (tipo != 1 && tipo != 2)
            {
                Console.WriteLine($"Tipo di conto non valido");
            }
            else
            {
                ICalcoloInteressi strategia = tipo == 2 ? new InteressiPremium() : new InteressiBase();
                IContiFactory factory = tipo == 2 ? new ContoPremiumFactory() : new ContoCorrenteFactory();
                

                Conto nuovoConto = factory.CreaConto(idCliente, idCliente, strategia);
                banca.Conti[nuovoConto.IdConto] = nuovoConto;

                banca.NotificaObservers($"Aperto conto {nuovoConto.IdConto} per cliente {idCliente}");
            }
            
        }
        
    }

    private static void Deposita(BankContext banca)
    {
        Console.Write("ID conto: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"Quanto vuoi deposita?");
        decimal importo = decimal.Parse(Console.ReadLine()!);

        if (banca.Conti.ContainsKey(id))
            banca.Conti[id].Deposita(importo);
        else
            Console.WriteLine("Conto non trovato!");
    }

    private static void Preleva(BankContext banca)
    {
        Console.Write("ID conto: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine($"Quanto vuoi prelevare?");
        decimal importo = decimal.Parse(Console.ReadLine()!);

        if (banca.Conti.ContainsKey(id))
            banca.Conti[id].Preleva(importo);
        else
            Console.WriteLine("Conto non trovato!");
        
    }

    private static void CambiaValuta(BankContext banca)
    {
    Console.Write("ID conto: ");
    int id = int.Parse(Console.ReadLine()!);

    Console.Write("In che valuta vuoi cambiare? ");
    string nuovaValuta = Console.ReadLine()!;

    if (banca.Conti.ContainsKey(id))
        banca.Conti[id].CambiaValuta(nuovaValuta);
    else
        Console.WriteLine("Conto non trovato!");
    }
    private static void VisualizzaSaldi(BankContext banca)
    {
        Console.WriteLine("Saldo attuale: ");
        foreach (var conto in banca.Conti.Values)
            Console.WriteLine(conto);
    }
}
#endregion Main
