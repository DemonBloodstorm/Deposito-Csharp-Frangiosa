using System;
using System.Collections.Generic;


public class Operatore // Classe base per tutti gli operatori
{   
    // Inizializzazione delle proprietà
    private string turno;

    public string Nome { get; set; }

    public string Turno
    {
        get { return turno; }// Restituisce il turno dell'operatore
        set
        {
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")// Controllo se il turno è valido
                turno = value.ToLower();
            else
                Console.WriteLine("Turno non valido! Usa 'giorno' o 'notte'.");// Se il turno non è valido, mostro un messaggio di errore
        }
    }

    public virtual void EseguiCompito()// Metodo virtuale per eseguire il compito dell'operatore
    {
        Console.WriteLine("Operatore generico in servizio.");
    }

    public override string ToString()// Override del metodo ToString per restituire una rappresentazione testuale dell'operatore
    {
        return $"{Nome} - {GetType().Name} - Turno: {Turno}";
    }
}

public class OperatoreEmergenza : Operatore // Classe per gli operatori di emergenza
{
    private int livelloUrgenza;
    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }// Restituisce il livello di urgenza dell'operatore di emergenza
        set
        {
            if (value >= 1 && value <= 5)// Controllo se il livello di urgenza è valido (compreso tra 1 e 5)
                livelloUrgenza = value;
            else
                Console.WriteLine("Il livello di urgenza deve essere compreso tra 1 e 5!");// Se il livello di urgenza non è valido, mostro un messaggio di errore
        }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Gestione emergenza di livello {LivelloUrgenza}");// Esegue il compito di gestione emergenza con il livello specificato
    }
}

public class OperatoreSicurezza : Operatore // Classe per gli operatori di sicurezza
{
    public string AreaSorvegliata { get; set; } // Area di sorveglianza dell'operatore di sicurezza

    public override void EseguiCompito()
    {
        Console.WriteLine($"Sorveglianza dell'area {AreaSorvegliata}");// Esegue il compito di sorveglianza dell'area specificata
    }
}

public class OperatoreLogistica : Operatore // Classe per gli operatori di logistica
{
    private int numeroConsegne;
    public int NumeroConsegne
    {
        get => numeroConsegne;
        set
        {
            if (value >= 0)// Controllo se il numero di consegne è valido (>= 0)
                numeroConsegne = value;
            else
                Console.WriteLine("Il numero di consegne deve essere >= 0!");// Se il numero di consegne non è valido, mostro un messaggio di errore
        }
    }

    public override void EseguiCompito()// Esegue il compito di coordinamento di consegne con il numero specificato 
    {
        Console.WriteLine($"Coordinamento di {NumeroConsegne} consegne");
    }
}

public class GestoreOperatori // Classe per gestire gli operatori
{
    private List<Operatore> operatori = new List<Operatore>(); // Lista per memorizzare gli operatori

    public void Aggiungi(Operatore op)// Aggiunge un operatore alla lista
    {
        if (op != null)
            operatori.Add(op);// Se l'operatore non è null, lo aggiungo alla lista
    }

    public void Stampa()// Stampa tutti gli operatori presenti nella lista
    {
        if (operatori.Count == 0)
        {
            Console.WriteLine("Nessun operatore presente.");
            return;
        }

        Console.WriteLine("\n--- Elenco operatori ---");// Stampa l'intestazione per l'elenco degli operatori
        foreach (var op in operatori)
            Console.WriteLine(op);// Stampa ogni operatore presente nella lista
    }

    public void EseguiTutti()// Esegue il compito di ogni operatore presente nella lista
    {
        if (operatori.Count == 0)
        {
            Console.WriteLine("Nessun operatore ");
            return;
        }
        foreach (var op in operatori)// Lo so che non dovevo fare un foreach ma non mi viene in mente come farlo
            op.EseguiCompito();// Chiamo il metodo EseguiCompito per ogni operatore presente nella lista
    }
}

public class Program
{
    static void Main()
    {
        GestoreOperatori gestore = new GestoreOperatori();

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("a. Aggiungere un nuovo operatore");
            Console.WriteLine("b. Stampare tutti gli operatori");
            Console.WriteLine("c. Eseguire compito di tutti (binding dinamico)");
            Console.WriteLine("d. Uscire");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine().ToLower();

            switch (scelta)// Switch per gestire le diverse scelte dell'utente
            {
                case "a":
                    gestore.Aggiungi(CreaOperatore());// Chiamo il metodo CreaOperatore per creare un nuovo operatore e aggiungerlo alla lista
                    break;

                case "b":
                    gestore.Stampa();// Chiamo il metodo Stampa per stampare tutti gli operatori presenti nella lista
                    break;

                case "c":
                    gestore.EseguiTutti();// Chiamo il metodo EseguiTutti per eseguire il compito di ogni operatore presente nella lista
                    break;

                case "d":
                    Environment.Exit(0);// Uscita dal programma
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");// Messaggio di errore per scelte non valide
                    break;
            }
        }
    }

    static Operatore CreaOperatore()// Non so bene come, ma sono riuscito a farlo funzionare grazie a copilot
    {
        Console.WriteLine("Tipo operatore (1=Emergenza, 2=Sicurezza, 3=Logistica): ");// Chiedo all'utente di inserire il tipo di operatore
        string tipo = Console.ReadLine();
        Operatore op = null;// Inizializzo l'operatore come null

        Console.Write("Nome: ");// Chiedo all'utente di inserire il nome dell'operatore
        string nome = Console.ReadLine();

        Console.Write("Turno (giorno/notte): ");// Chiedo all'utente di inserire il turno dell'operatore
        string turno = Console.ReadLine();

        switch (tipo)
        {
            case "1":
                op = new OperatoreEmergenza();// Creo un nuovo operatore di emergenza
                Console.Write("Livello urgenza (1-5): ");// Chiedo all'utente di inserire il livello di urgenza
                ((OperatoreEmergenza)op).LivelloUrgenza = int.Parse(Console.ReadLine());// Assegno il livello di urgenza all'operatore
                break;

            case "2":
                op = new OperatoreSicurezza();// Creo un nuovo operatore di sicurezza
                Console.Write("Area sorvegliata: ");// Chiedo all'utente di inserire l'area sorvegliata
                ((OperatoreSicurezza)op).AreaSorvegliata = Console.ReadLine();// Assegno l'area sorvegliata all'operatore
                break;

            case "3":
                op = new OperatoreLogistica();// Creo un nuovo operatore di logistica
                Console.Write("Numero consegne: ");// Chiedo all'utente di inserire il numero di consegne
                ((OperatoreLogistica)op).NumeroConsegne = int.Parse(Console.ReadLine());// Assegno il numero di consegne all'operatore
                break;

            default:
                Console.WriteLine("Tipo non valido!");// Messaggio di errore per tipi non validi
                return null;
        }

        op.Nome = nome;// Assegno il nome all'operatore
        op.Turno = turno;// Assegno il turno all'operatore

        Console.WriteLine("Operatore aggiunto con successo!");// Messaggio di conferma per operatore aggiunto con successo
        return op;// Restituisco l'operatore aggiunto
    }
}

