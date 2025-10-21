using System;

#region interfaccia INotifier + Classi concrete EamilNotifier, SMSNotifier e PushNotifier
public interface INotifier // Interfaccia per il notificatore
{
    void Invia(string message);
}
public class EmailNotifier : INotifier // Implementazione del notificatore per le email
{
    public void Invia(string message)
    {
        Console.WriteLine($"Email inviata: {message}");
    }
}
public class SMSNotifier : INotifier // Implementazione del notificatore per gli SMS
{
    public void Invia(string message)
    {
        Console.WriteLine($"SMS inviato: {message}");
    }
}
public class PushNotifier : INotifier // Implementazione del notificatore per le notifiche push
{
    public void Invia(string message)
    {
        Console.WriteLine($"Notifica di push inviata: {message}");
    }
}
#endregion

#region Enum + Factory
public class Notifica // Classe per la gestione delle notifiche
{
    public enum TipoNotifica // Enumerazione per i tipi di notifica
    {
        email,
        sms,
        push
    }
}

public class NotificaFactory // Factory per la creazione dei notificatori
{
    public static NotificaFactory Instance { get; private set; } // Istanza singleton della factory
    static NotificaFactory() // Costruttore statico per inizializzare l'istanza della factory
    {
        Instance = new NotificaFactory(); // Inizializza l'istanza della factory
    }
    public INotifier CreateNotifier(Notifica.TipoNotifica tipo) // Crea un notificatore basato sul tipo specificato
    {
        switch (tipo)
        {
            case Notifica.TipoNotifica.email: // Se il tipo è email
                return new EmailNotifier(); // Crea un notificatore per le email
            case Notifica.TipoNotifica.sms: // Se il tipo è SMS
                return new SMSNotifier(); // Crea un notificatore per gli SMS
            case Notifica.TipoNotifica.push: // Se il tipo è push
                return new PushNotifier(); // Crea un notificatore per le notifiche push
            default:
                throw new ArgumentException("Tipo notifica non valido"); // Lancia un'eccezione se il tipo non è valido
        }
    }
}

#endregion Enum + Factory

#region MessaggioService con Dependency Injection tramite costruttore

public class MessaggioService // Servizio per la gestione dei messaggi
{
    private readonly INotifier _notifier; // Notificatore utilizzato per inviare i messaggi
    public MessaggioService(INotifier notifier) // Costruttore del Dependency Injection
    {
        _notifier = notifier; // Inizializza il notificatore
    }
    public void InviaMessaggio(string message) // Invia un messaggio utilizzando il notificatore
    {
        _notifier.Invia(message);
    }
}

#endregion 

#region Main

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Salve, che tipo di notifica vuole inviare oggi?");
        Console.WriteLine("Email, SMS o Push?");
        string tipoNotifica = Console.ReadLine().Trim().ToLower();
        if (Enum.TryParse<Notifica.TipoNotifica>(tipoNotifica, true, out var tipoNotificaEnum))
        {
            INotifier notifier = NotificaFactory.Instance.CreateNotifier(tipoNotificaEnum);
            var messaggioService = new MessaggioService(notifier);

            Console.WriteLine("Va bene, che cosa vuoi scrivere nella notifica?");
            string messaggio = Console.ReadLine().Trim();
            messaggioService.InviaMessaggio(messaggio);
        }
        else
        {
            Console.WriteLine($"Tipo di notifica '{tipoNotifica}' non valido.");
        }
    }
}

#endregion
