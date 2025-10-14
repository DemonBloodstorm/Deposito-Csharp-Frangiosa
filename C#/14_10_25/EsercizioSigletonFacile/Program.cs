using System;


public sealed class ConfigurazioneSistema
{
    private static ConfigurazioneSistema instance;
    private static readonly object _lock = new object();
    Dictionary<string, string> _properties = new Dictionary<string, string>();

    private ConfigurazioneSistema()
    {
        Console.WriteLine("Welcome to the matrix");
    }

    public static ConfigurazioneSistema Instance
    {
        get
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurazioneSistema();
                    }
                }
            }
            return instance;
        }
    }
    public void Imposta(string key, string value)
    {
        _properties[key] = value;
    }
    public string Leggi(string key)
    {
        return _properties[key];
    }
    public void StampaTutte()
    {
        foreach (var item in _properties)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ConfigurazioneSistema config = ConfigurazioneSistema.Instance;
        ConfigurazioneSistema config2 = ConfigurazioneSistema.Instance;
        config.Imposta("Risoluzione", "1920x1080");
        config2.Imposta("Volume", "50");
        config.StampaTutte();
        Console.WriteLine(config == config2);

    }
}