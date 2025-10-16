using System;

interface IStrategiaOperazione // Interfaccia per le strategie di operazione
{
    double Calcola(double x, double y);
}

class SommaStrategia : IStrategiaOperazione // Strategia per la somma
{
    public double Calcola(double x, double y)
    {
        return x + y;
    }
}
class SottrazioneStrategia : IStrategiaOperazione // Strategia per la sottrazione
{
    public double Calcola(double x, double y)
    {
        return x - y;
    }
}
class MoltiplicazioneStrategia : IStrategiaOperazione // Strategia per la moltiplicazione
{
    public double Calcola(double x, double y)
    {
        return x * y;
    }
}
class DivisioneStrategia : IStrategiaOperazione // Strategia per la divisione
{
    public double Calcola(double x, double y)
    {
        if (y.Equals(0))
        {
            return double.PositiveInfinity; // Restituisce infinito se si tenta di dividere per zero
        }
        return x / y;
    }
}

class Calcolatrice
{
    private IStrategiaOperazione _strategia;
    private readonly Utente _utente;

    public Calcolatrice(Utente utente)
    {
        _utente = utente;
    }

    public void ImpostaStrategia(IStrategiaOperazione strategia)
    {
        _strategia = strategia;
        string nomeOperazione = strategia.GetType().Name.Replace("Strategia", "");
        _utente.EseguiAzione(nomeOperazione);
    }

    public double EseguiOperazione(double x, double y)
    {
        double risultato = _strategia.Calcola(x, y);
        _utente.EseguiAzione($"Il risultato è {risultato}");
        return risultato;
    }
}

public class Logger
{
    private static Logger? _instance;

    private Logger()
    {
        Console.WriteLine("Inizio del calcolo");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void ScriviMessaggio(string message)
    {
        Console.WriteLine($"{message}");
    }
}

public class Utente
{
    public string Nome { get; set; }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public void EseguiAzione(string azione)
    {
        Logger logger = Logger.GetInstance();
        logger.ScriviMessaggio($"{Nome} esegue: {azione}");
    }
}

class MostraMenu
{
    public void Menu()
    {
        Console.WriteLine("\nScegli un'operazione:");
        Console.WriteLine("1. Somma");
        Console.WriteLine("2. Sottrazione");
        Console.WriteLine("3. Moltiplicazione");
        Console.WriteLine("4. Divisione");
        Console.WriteLine("0. Esci");
    }
}

class program
{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        
        Console.WriteLine("Inserisci nome utente:");
        string nomeUtente = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nomeUtente))
        {
            nomeUtente = "Utente Anonimo";
        }
        Utente utente = new Utente(nomeUtente);
        
        Calcolatrice calcolatrice = new Calcolatrice(utente);

        bool loop = true;

        while(loop)
        {
            menu.Menu();
            
            if (int.TryParse(Console.ReadLine(), out int scelta))
            {
                switch(scelta)
                {
                    case 0:
                        loop = false;
                        utente.EseguiAzione("Uscita dal programma.");
                        break;
                    case 1:
                        calcolatrice.ImpostaStrategia(new SommaStrategia());
                        EseguiCalcolo(calcolatrice, utente);
                        break;
                    case 2:
                        calcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                        EseguiCalcolo(calcolatrice, utente);
                        break;
                    case 3:
                        calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                        EseguiCalcolo(calcolatrice, utente);
                        break;
                    case 4:
                        calcolatrice.ImpostaStrategia(new DivisioneStrategia());
                        EseguiCalcolo(calcolatrice, utente);
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        utente.EseguiAzione("Ha effettuato una scelta non valida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Input non valido.");
                utente.EseguiAzione("Ha inserito un input non valido per la scelta.");
            }
        }
    }

    static void EseguiCalcolo(Calcolatrice calcolatrice, Utente utente)
    {
        Console.WriteLine("Inserisci il primo numero:");
        if (!double.TryParse(Console.ReadLine(), out double x))
        {
            Console.WriteLine("Numero non valido.");
            utente.EseguiAzione("Ha inserito un primo numero non valido.");
            return;
        }

        Console.WriteLine("Inserisci il secondo numero:");
        if (!double.TryParse(Console.ReadLine(), out double y))
        {
            Console.WriteLine("Numero non valido.");
            utente.EseguiAzione("Ha inserito un secondo numero non valido.");
            return;
        }

        double risultato = calcolatrice.EseguiOperazione(x, y);

        if (double.IsInfinity(risultato))
        {
            Console.WriteLine("Errore: Impossibile dividere per zero.");
        }
        else
        {
            Console.WriteLine($"Il risultato è: {risultato}");
        }
    }
}