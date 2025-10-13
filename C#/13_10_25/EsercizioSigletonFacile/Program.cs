using System;

public class Logger
{
    private static Logger? _instance;

    private Logger()
    {
        Console.WriteLine("Logger instance created");
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
        Console.WriteLine(message);
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

public class Program
{
    public static void Main(string[] args)
    {
        Utente utente1 = new Utente("Alice");
        Utente utente2 = new Utente("Bob");

        utente2.EseguiAzione("login");
        utente1.EseguiAzione("login");
        utente2.EseguiAzione("invio messaggio");
        utente1.EseguiAzione("logout");
        utente2.EseguiAzione("logout");

        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("Tutti gli utenti usano la stessa istanza di Logger!");
        }


        // logger.ScriviMessaggio("Hello, Cruel World!");
        // logger.ScriviMessaggio("Ciao mondo crudele");

        // if (object.ReferenceEquals(logger, logger2))
        // {
        //     Console.WriteLine("logger e logger2 sono la stessa istanza");
        // }
        // else
        // {
        //     Console.WriteLine("logger1 e logger2 sono istanze diverse");
        // }


    }
}