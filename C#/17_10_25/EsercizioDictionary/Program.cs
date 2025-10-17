using System;
using System.Collections.Generic;

public class User // Classe che rappresenta un utente
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ActionLog // Classe che rappresenta un log di azione
{
    public DateTime Timestamp { get; set; }
    public string ActionType { get; set; }
    public string Metadata { get; set; }
    public int UserId { get; set; }
}

public class Program
{
    static Dictionary<int, User> users = new Dictionary<int, User>(); // Dizionario che contiene gli utenti, con chiave ID e valore oggetto User
    static Dictionary<int, List<ActionLog>> actionsByUser = new Dictionary<int, List<ActionLog>>(); // Dizionario che contiene i log di azione per ogni utente, 
                                                                                                    //  con chiave ID utente e valore lista di oggetti ActionLog
    static int nextUserId = 1;

    public static User CreateUser(string username, string email) // Metodo per creare un nuovo utente
    {
        foreach (var u in users.Values)
        {
            if (u.Username.ToLower().Trim().Equals(username.ToLower().Trim()))
            {
                Console.WriteLine($"Errore: Username '{username}' già in uso.");
                return null;
            }
        }

        var user = new User // Crea un nuovo oggetto User
        {
            Id = nextUserId,
            Username = username,
            Email = email,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        users.Add(user.Id, user); // Aggiunge l'utente al dizionario users
        actionsByUser.Add(user.Id, new List<ActionLog>()); // Crea una nuova lista vuota per il log di azione dell'utente
        LogAction(user.Id, "CREATE", $"Utente creato con username: {username}"); // Registra l'azione di creazione dell'utente

        nextUserId++;
        return user;
    }

    public static User AuthenticateUser(string username) // Metodo per autenticare un utente
    {
        foreach (var u in users.Values) 
        {
            if (u.Username.ToLower() == username.ToLower() && u.IsActive)
            {
                LogAction(u.Id, "LOGIN", "Autenticazione riuscita.");
                return u;
            }
        }
        return null;
    }

    public static void LogAction(int userId, string actionType, string metadata) // Metodo per registrare un log di azione
    {
        if (!users.ContainsKey(userId)) return;

        var log = new ActionLog
        {
            Timestamp = DateTime.Now,
            ActionType = actionType.ToUpper(),
            Metadata = metadata,
            UserId = userId
        };
        actionsByUser[userId].Add(log);
    }

    public static List<ActionLog> GetActionHistory(int userId, string filterByType = null) // Metodo per ottenere l'istoria delle azioni di un utente
    {
        var result = new List<ActionLog>();

        if (!actionsByUser.ContainsKey(userId)) // Se l'utente non ha log di azione, restituisce una lista vuota
            return result;

        foreach (var action in actionsByUser[userId])
        {
            if (filterByType == null || action.ActionType.ToLower() == filterByType.ToLower()) // Se il filtro è nullo o corrisponde al tipo di azione, aggiunge l'azione alla lista result
            {
                result.Add(action);
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        var user1 = CreateUser("admin", "admin@example.com");
        var user2 = CreateUser("gabri", "gabri@example.com");
        Console.WriteLine($"Creato utente: {user1.Username} (ID: {user1.Id})");
        Console.WriteLine($"Creato utente: {user2.Username} (ID: {user2.Id})");


        CreateUser("admin", "another@email.com");

        var authenticatedUser = AuthenticateUser("gabri");
        if (authenticatedUser != null)
        {
            Console.WriteLine($"Benvenuto, {authenticatedUser.Username}!");

            LogAction(authenticatedUser.Id, "VIEW", "Ha visualizzato la dashboard.");
            LogAction(authenticatedUser.Id, "UPDATE", "Ha modificato il suo profilo.");

            Console.WriteLine("Tutte le azioni:");
            var allActions = GetActionHistory(authenticatedUser.Id);
            foreach (var action in allActions)
            {
                Console.WriteLine($"- [{action.Timestamp:T}] [{action.ActionType}] {action.Metadata}");
            }

            Console.WriteLine("Solo LOGIN:");
            var loginActions = GetActionHistory(authenticatedUser.Id, "LOGIN");
            foreach (var action in loginActions)
            {
                Console.WriteLine($"- [{action.Timestamp:T}] [{action.ActionType}] {action.Metadata}");
            }
        }
        else
        {
            Console.WriteLine("Autenticazione fallita.");
        }
    }
}
