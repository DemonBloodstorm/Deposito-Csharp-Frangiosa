using System;

public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Printer
{
    public ILogger Logger { get; set; }  // Setter Injection
}

public class Program
{
    public static void Main(string[] args)
    {
        var printer = new Printer();
        printer.Logger = new ConsoleLogger();
        printer.Logger.Log("Questo è un Setter Injection!");
    }
}