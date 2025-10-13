using System;
using System.Collections.Generic;

sealed class Logger
{
    private List<string> messaggi = new List<string>();
    private static Logger? _instance;

    private Logger()
    {
        Console.WriteLine("Ci sono anche io, il Singleton");
    }

    public static Logger GetInstance()
    {
        if (_instance == null)
            _instance = new Logger();
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
        messaggi.Add(message);
    }

    public List<string> Messaggi()
    {
        return messaggi;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();

        logger.Log("Inizio");
        Console.WriteLine(" ");
        logger.Log("Fine");

        foreach (var messaggio in logger.Messaggi())
            Console.WriteLine(messaggio);
    }
}
