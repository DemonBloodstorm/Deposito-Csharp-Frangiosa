using System;

class Utils
{
    static string[] gusti = { "Chocolate", "Vanilla", "Strawberry", "Mint", "Raspberry" };
    static double[] prezzi = { 2.50, 3.00, 3.50, 4.00, 4.50 };
    public static void StampaMenu()
    {
        for (int i = 0; i < gusti.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {gusti[i]} - {prezzi[i]}€");
        }
    }

    public static double CalcolaTotale(int scelta, int quantita)
    {
        if (scelta < 1 || scelta > prezzi.Length)
        {
            Console.WriteLine("Scelta non valida!");
            return 0;
        }

        return prezzi[scelta - 1] * quantita;
    }

}

