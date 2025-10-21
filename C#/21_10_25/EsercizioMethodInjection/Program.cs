using System;

public interface INotifier // Interfaccia per il notificatore
{
    void Notify(string message); // Metodo per inviare una notifica
}
public class SMSNotifier : INotifier // Implementazione del notificatore per SMS
{
    public void Notify(string message) // Metodo per inviare una notifica via SMS
    {
        Console.WriteLine($"Invio SMS: {message}"); // Stampa il messaggio SMS
    }
}

public class AlertService // Servizio per inviare avvisi tramite notificatore
{
    public void SendAlert(string message, INotifier notifier) // Metodo per inviare un avviso tramite notificatore
    {
        notifier.Notify(message); // Invia la notifica tramite il notificatore specificato
    }
}

public class AlertServiceSetter // Servizio per inviare avvisi tramite notificatore
{
    public INotifier notifier { get; set; } // Setter Injection per il notificatore
    public void SendAlert(string message) // Metodo per inviare un avviso tramite notificatore
    {
        notifier.Notify(message); // Invia la notifica tramite il notificatore specificato
    }
}

public class AlertServiceConstructor // Servizio per inviare avvisi tramite notificatore
{
    private readonly INotifier _notifier; // Campo privato per il notificatore
    public AlertServiceConstructor(INotifier notifier) // Costruttore per l'injection del notificatore
    {
        _notifier = notifier; // Assegna il notificatore passato come parametro
    }
    public void SendAlert(string message) // Metodo per inviare un avviso tramite notificatore
    {
        _notifier.Notify(message); // Invia la notifica tramite il notificatore specificato
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var alertService = new AlertService(); // Crea un'istanza del servizio di avviso
        var smsNotifier = new SMSNotifier(); // Crea un'istanza del notificatore per SMS
        alertService.SendAlert("Questo è un messaggio di avviso tramite method injection", smsNotifier); // Invia un avviso tramite SMS
        var alertServiceSetter = new AlertServiceSetter(); // Crea un'istanza del servizio di avviso con Setter Injection
        alertServiceSetter.notifier = smsNotifier; // Imposta il notificatore per SMS
        alertServiceSetter.SendAlert("Questo è un messaggio di avviso tramite setter injection"); // Invia un avviso tramite SMS
        var alertServiceConstructor = new AlertServiceConstructor(smsNotifier); // Crea un'istanza del servizio di avviso con Constructor Injection
        alertServiceConstructor.SendAlert("Questo è un messaggio di avviso tramite constructor injection"); // Invia un avviso tramite SMS
    }
}