using System;

public class Volo
{
    public string CodiceVolo { get; set; }
    public int MaxPosti { get; set; }

    public Volo(string codiceVolo, int maxPosti)
    {
        CodiceVolo = codiceVolo;
        MaxPosti = maxPosti;
    }
}

public class VoloAereo : Volo
{
    private int postiOccupati;

    public VoloAereo(string codiceVolo, int maxPosti = 150) : base(codiceVolo, maxPosti) { }

    public int PostiOccupati => postiOccupati;
    public int PostiLiberi => MaxPosti - postiOccupati;

    public void EffettuaPrenotazione(int postiDaPrenotare)
    {
        if (postiDaPrenotare <= PostiLiberi)
        {
            postiOccupati += postiDaPrenotare;
        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti liberi");
        }
    }

    public void AnnullaPrenotazione(int postiDaAnnullare)
    {
        if (postiDaAnnullare <= PostiOccupati)
        {
            postiOccupati -= postiDaAnnullare;
        }
        else
        {
            Console.WriteLine("Non ci sono abbastanza posti occupati");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Codice Volo: {CodiceVolo}");
        Console.WriteLine($"Posti occupati: {PostiOccupati}");
        Console.WriteLine($"Posti liberi: {PostiLiberi}");
    }
}

public class Menu
{
    public int VisualizzaMenu()
    {
        Console.WriteLine("1. Effettua prenotazione");
        Console.WriteLine("2. Annulla prenotazione");
        Console.WriteLine("3. Visualizza stato");
        Console.WriteLine("4. Esci");
        Console.WriteLine("Scegli un'opzione:");
        int scelta = int.Parse(Console.ReadLine());
        return scelta;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string codice;
        int scelta;
        Menu menu = new Menu();
        
        Console.WriteLine("Inserisci il codice del volo:");
        codice = Console.ReadLine();
        VoloAereo voloAereo = new VoloAereo(codice);

        while (true)
        {
            scelta = menu.VisualizzaMenu();

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il numero di posti da prenotare:");
                    int postiDaPrenotare = int.Parse(Console.ReadLine());
                    voloAereo.EffettuaPrenotazione(postiDaPrenotare);
                    voloAereo.VisualizzaStato();
                    break;
                case 2:
                    Console.WriteLine("Inserisci il numero di posti da annullare:");
                    int postiDaAnnullare = int.Parse(Console.ReadLine());
                    voloAereo.AnnullaPrenotazione(postiDaAnnullare);
                    voloAereo.VisualizzaStato();
                    break;
                case 3:
                    voloAereo.VisualizzaStato();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }
    }
}
