using System;

public class Accesso
{
    // Proprietà pubblica per impostare il livello di accesso
    public LivelloAccesso livelloAccesso { get; set; }

    public enum LivelloAccesso
    {
        Ospite,
        Utente,
        Amministratore
    }

    public void Livello()
    {
        switch (livelloAccesso)
        {
            case LivelloAccesso.Ospite:
                Console.WriteLine("Sei un ospite, puoi visualizzare ma non interagire con altri");
                break;

            case LivelloAccesso.Utente:
                Console.WriteLine("Sei un utente, puoi visualizzare e interagire con altri");
                break;

            case LivelloAccesso.Amministratore:
                Console.WriteLine("Sei un amministratore, puoi visualizzare, interagire con altri e modificare la pagina");
                break;

            default:
                Console.WriteLine("ERRORE: Livello di accesso non valido");
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var accesso = new Accesso();
        accesso.livelloAccesso = Accesso.LivelloAccesso.Ospite;
        accesso.Livello();
        Console.WriteLine($"\n");
        
        accesso.livelloAccesso = Accesso.LivelloAccesso.Utente;
        accesso.Livello();
        Console.WriteLine($"\n");

        accesso.livelloAccesso = Accesso.LivelloAccesso.Amministratore;
        accesso.Livello();
    }
}
