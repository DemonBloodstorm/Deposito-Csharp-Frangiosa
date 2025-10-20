using System;

public sealed class AppConfig
{
    private static AppConfig _instance;
    private static readonly object _lock = new object();
    public string NomeApp { get; private set; }
    public string Valuta { get; private set; }
    public string AliquotaIVA { get; private set; }

    public static AppConfig GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AppConfig("Prototype", "EUR", "22");
                }
            }
        }
        return _instance;
    }
    public AppConfig(string nomeapp, string valuta, string aliquotaIVA)
    {
        this.NomeApp = nomeapp;
        this.Valuta = valuta;
        this.AliquotaIVA = aliquotaIVA;
    }
}

public interface ILogger
{
    void Log(string message);
}

public class OrderService
{
    private readonly ILogger _logger;

    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreaOrdine(string cliente, double importo)
    {
        _logger.Log($"Ordine creato per {cliente}, importo: {importo} {AppConfig.GetInstance().Valuta}");
    }
}

public class LoggerServices : ILogger
{
    private AppConfig _config;
    public LoggerServices(AppConfig config)
    {
        _config = config;
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{_config.NomeApp}] {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var config = AppConfig.GetInstance();
        ILogger logger = new LoggerServices(config);
        var orderService = new OrderService(logger);

        orderService.CreaOrdine("Mario Rossi", 100.0);
    }
}