using System;

public interface IGreeter
{
    void Greet(string name);
}

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"System: {message}");
    }
}
public class ConsoleGreeter : IGreeter
{
    public void Greet(string name)
    {
        Console.WriteLine($"Hi, I am {name}!");
    }
}

public class GreetingService
{
    private readonly IGreeter _greeter;

    public GreetingService(IGreeter greeter)
    {
        _greeter = greeter;
    }

    public void Greet(string name)
    {
        _greeter.Greet(name);
    }
    private readonly ILogger _logger;

    public GreetingService(ILogger logger)
    {
        _logger = logger;
    }
    public void Log(string message)
    {
        _logger.Log(message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IGreeter greeter = new ConsoleGreeter();
        GreetingService greetingService = new GreetingService(greeter);
        greetingService.Greet("Gabriele Frangiosa");
        ILogger logger = new ConsoleLogger();
        GreetingService loggerServices = new GreetingService(logger);
        loggerServices.Log("Hello There!");
    }
}
