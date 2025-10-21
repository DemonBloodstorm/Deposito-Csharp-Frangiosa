using System;
using System.Collections.Generic;

public class Settimana
{
    public GiornoSettimana giorno;
    public enum GiornoSettimana
    {
        Lunedi,
        Martedi,
        Mercoledi,
        Giovedi,
        Venerdi,
        Sabato,
        Domenica
    }
    public void StampaGiorno()
    {
        switch (giorno)
        {
            case GiornoSettimana.Lunedi:
                Console.WriteLine("Lunedì: Tutto ricomincia");
                break;
            case GiornoSettimana.Martedi:
                Console.WriteLine("Martedì non è poi così male... è un segno che sono sopravvissuto al lunedì");
                break;
            case GiornoSettimana.Mercoledi:
                Console.WriteLine("Mercoledì: il punto in cui guardi avanti al weekend, ma ti rendi conto che c’è ancora tanto da fare");
                break;
            case GiornoSettimana.Giovedi:
                Console.WriteLine("Giovedì è come un preambolo: sei quasi lì, ma devi ancora dare il massimo");
                break;
            case GiornoSettimana.Venerdi:
                Console.WriteLine("È venerdì! Il mio secondo giorno preferito della settimana dopo ogni giorno in cui non lavoro");
                break;
            case GiornoSettimana.Sabato:
                Console.WriteLine("Il sabato è per le avventure");
                break;
            case GiornoSettimana.Domenica:
                Console.WriteLine("La domenica libera la mente e prepara l'anima per il lunedì");
                break;
            default:
                Console.WriteLine("Non hai scritto bene il giorno della settimana");
                break;
        }
    }

}
public class Program
{
    public static void Main(string[] args)
    {
        Settimana settimana = new Settimana();
        Console.WriteLine($"Quale giorno della settimana è oggi?");
        settimana.giorno = (Settimana.GiornoSettimana)Enum.Parse(typeof(Settimana.GiornoSettimana), Console.ReadLine());
        settimana.StampaGiorno();
    }
}