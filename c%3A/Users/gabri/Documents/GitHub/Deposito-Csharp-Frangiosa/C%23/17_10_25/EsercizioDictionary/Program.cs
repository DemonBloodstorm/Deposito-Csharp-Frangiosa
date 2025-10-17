using System;
using System.Collections.Generic;
using System.Linq;

// --- MODELLO DATI ---

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ActionLog
{
    public DateTime Timestamp { get; set; }
    public string ActionType { get; set; }
    public string Metadata { get; set; }
    public int UserId { get; set; }
}

// --- LOGICA DI GESTIONE E DIMOSTRAZIONE ---

public class Program
{
    // Dizionari che fungono da database in-memory
    static Dictionary<int, User> users = new Dictionary<int, User>();
    static Dictionary<int, List<ActionLog>> actionsByUser = new Dictionary<int, List<ActionLog>>();
    static int nextUserId = 1;

    /// <summary>
    /// Crea un nuovo utente e lo aggiunge al dizionario.
    /// </summary>
    public static User CreateUser(string username, string email)
    {
        if (users.Values.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Errore: Username '{username}' già in uso.");
            return null;
        }

        var user = new User
        {
            Id = nextUserId,
            Username = username,
            Email = email,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        users.Add(user.Id, user);
        actionsByUser.Add(user.Id, new List<ActionLog>()); // Inizializza la lista di azioni per l'utente
        LogAction(user.Id, "CREATE", $"Utente creato con username: {username}");
        
        nextUserId++;
        return user;
    }

    /// <summary>
    /// Autentica un utente in base allo username.
    /// </summary>
    public static User AuthenticateUser(string username)
    {
        var user = users.Values.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        if (user != null && user.IsActive)
        {
            LogAction(user.Id, "LOGIN", "Autenticazione riuscita.");
            return user;
        }
        return null;
    }

    /// <summary>
    /// Registra un'azione per un utente specifico.
    /// </summary>
    public static void LogAction(int userId, string actionType, string metadata)
    {
        if (!users.ContainsKey(userId)) return;

        var log = new ActionLog
        {
            Timestamp = DateTime.UtcNow,
            ActionType = actionType.ToUpper(),
            Metadata = metadata,
            UserId = userId
        };
        actionsByUser[userId].Add(log);
    }

    /// <summary>
    /// Interroga lo storico delle azioni con un filtro opzionale.
    /// </summary>
    public static List<ActionLog> GetActionHistory(int userId, string filterByType = null)
    {
        if (!actionsByUser.ContainsKey(userId))
        {
            return new List<ActionLog>();
        }

        var userActions = actionsByUser[userId];

        if (!string.IsNullOrWhiteSpace(filterByType))
        {
            return userActions.Where(a => a.ActionType.Equals(filterByType, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        return userActions;
    }

    // --- DIMOSTRAZIONE ---

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Creazione Utenti ---");
        var user1 = CreateUser("admin", "admin@example.com");
        var user2 = CreateUser("gabri", "gabri@example.com");
        Console.WriteLine($"Creato utente: {user1.Username} (ID: {user1.Id})");
        Console.WriteLine($"Creato utente: {user2.Username} (ID: {user2.Id})");
        
        Console.WriteLine("\n--- Tentativo di creare utente duplicato ---");
        CreateUser("admin", "another@email.com");

        Console.WriteLine("\n--- Autenticazione Utente ---");
        var authenticatedUser = AuthenticateUser("gabri");
        if (authenticatedUser != null)
        {
            Console.WriteLine($"Benvenuto, {authenticatedUser.Username}!");

            // Registrazione di alcune azioni
            LogAction(authenticatedUser.Id, "VIEW", "Ha visualizzato la dashboard.");
            LogAction(authenticatedUser.Id, "UPDATE", "Ha modificato il suo profilo.");
            
            Console.WriteLine("\n--- Storico completo delle azioni per 'gabri' ---");
            var allActions = GetActionHistory(authenticatedUser.Id);
            foreach (var action in allActions)
            {
                Console.WriteLine($"- [{action.Timestamp:T}] [{action.ActionType}] {action.Metadata}");
            }

            Console.WriteLine("\n--- Storico filtrato per azioni di tipo 'LOGIN' ---");
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