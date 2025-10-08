using System;

public class PrenotazioneViaggio
{
    // Proprietà private per tenere traccia dei posti prenotati
    private int postiPrenotati = 0;
    private const int maxPosti = 20;

    // Proprietà pubblica per ottenere e impostare la destinazione
    public string Destinazione { get; set; } = "Bali";

    // Proprietà pubblica per ottenere il numero di posti disponibili
    public int PostiDisponibili => maxPosti - postiPrenotati;
    // Proprietà pubblica per ottenere il numero di posti prenotati
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    // Metodo pubblico per prenotare posti
    public void PrenotaPosti(int numero)
    {
        if (numero <= PostiDisponibili && numero > 0)
        {
            postiPrenotati += numero;
            Console.WriteLine($"Prenotati {numero} posti per {Destinazione}.");
        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti disponibili o numero non valido.");
        }
    }

    // Metodo pubblico per annullare prenotazioni
    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= postiPrenotati && numero > 0)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"Annullati {numero} posti per {Destinazione}.");
        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti prenotati o numero non valido.");
        }
    }
}

// Classe per mostrare il menu
public class mostraMenu
{
    public void VisualizzaMenu()
    {
        Console.WriteLine("1. Effettua prenotazione");
        Console.WriteLine("2. Annulla prenotazione");
        Console.WriteLine("3. Esci");
        Console.Write("Scegli un'opzione: ");
    }
}

public class Program
{
    public static void Main()
    {
        // Creazione di un'istanza della classe PrenotazioneViaggio
        PrenotazioneViaggio prenotazione = new PrenotazioneViaggio();

        // Ciclo infinito
        while (true)
        {
            // Visualizzazione del menu
            mostraMenu menu = new mostraMenu();
            menu.VisualizzaMenu();
            // Lettura della scelta dell'utente
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:// Prenotazione posti
                    Console.Write("Inserisci il numero di posti da prenotare: ");
                    int postiDaPrenotare = int.Parse(Console.ReadLine());
                    prenotazione.PrenotaPosti(postiDaPrenotare);
                    Console.WriteLine($"Posti disponibili: {prenotazione.PostiDisponibili}");
                    Console.WriteLine($"Posti prenotati: {prenotazione.PostiPrenotati}");
                    break;
                case 2:// Annullamento prenotazioni
                    Console.Write("Inserisci il numero di posti da annullare: ");
                    int postiDaAnnullare = int.Parse(Console.ReadLine());
                    prenotazione.AnnullaPrenotazione(postiDaAnnullare);
                    Console.WriteLine($"Posti disponibili: {prenotazione.PostiDisponibili}");
                    Console.WriteLine($"Posti prenotati: {prenotazione.PostiPrenotati}");
                    break;
                case 3:// Esci dal programma
                    Console.WriteLine("Arrivederci!");
                    return;
                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }

    }
}
