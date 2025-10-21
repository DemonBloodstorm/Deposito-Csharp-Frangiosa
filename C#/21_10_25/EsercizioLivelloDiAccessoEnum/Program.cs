using System;

public class Accesso
{
    public LivelloAccesso livelloAccesso { get; set; } // Proprietà pubblica per impostare il livello di accesso

    public enum LivelloAccesso // Enumerazione per i livelli di accesso
    {
        Ospite,
        Utente,
        Amministratore
    }

    public void Livello() // Metodo per determinare il livello di accesso
    {
        switch (livelloAccesso) // Switch per determinare il livello di accesso
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
        var accesso = new Accesso(); // Crea un'istanza della classe Accesso
        accesso.livelloAccesso = Accesso.LivelloAccesso.Ospite; // Imposta il livello di accesso come ospite
        accesso.Livello();
        Console.WriteLine($"\n");
        
        accesso.livelloAccesso = Accesso.LivelloAccesso.Utente; // Imposta il livello di accesso come utente
        accesso.Livello();
        Console.WriteLine($"\n");

        accesso.livelloAccesso = Accesso.LivelloAccesso.Amministratore; // Imposta il livello di accesso come amministratore
        accesso.Livello();
    }
}
