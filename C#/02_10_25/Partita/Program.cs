using System;

class Program
{
    static void Main()
    {
        int punteggioCorrente = 0, totale = 0;
        double media = 0.0;

        AggiornaPunteggio(ref punteggioCorrente, 10, 1, out totale);

        AggiornaPunteggio(ref punteggioCorrente, 15, 2, out totale);

        AggiornaPunteggio(ref punteggioCorrente, 20, 3, out totale, out media);

        Console.WriteLine("Punteggio totale dopo 3 turni: " + totale);
        Console.WriteLine("Punteggio medio sui 3 turni: " + media);
    }

    static void AggiornaPunteggio(ref int punteggioCorrente, int bonus, int turno, out int totale, out double media)
    {
        punteggioCorrente += bonus;

        if (turno == 3)
        {
            totale = punteggioCorrente;
            media = totale / 3.0;
        }
        else
        {
            totale = 0;
            media = 0.0;
        }

        Console.WriteLine($"Turno {turno}: punteggio corrente = {punteggioCorrente}");
    }
}
