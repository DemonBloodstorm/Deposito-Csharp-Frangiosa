using System;

class Program
{
    static void Main(string[] args)
    {
        double voto1, voto2, bonus, media;

        Console.WriteLine("Inserisci il primo voto:");
        voto1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il secondo voto:");
        voto2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il bonus:");
        bonus = double.Parse(Console.ReadLine());

        bool haPassato = ElaboraStudente(ref voto1, ref voto2, bonus, out media);

        Console.WriteLine("La media del studente è:"+ media);

        if (haPassato)
            Console.WriteLine("Il studente ha passato!");
        else
            Console.WriteLine("Il studente non ha passato!");
    }

    static bool ElaboraStudente(ref double voto1, ref double voto2, double bonus, out double media)
    {
        voto1 = Math.Min(voto1 + bonus, 10);
        voto2 = Math.Min(voto2 + bonus, 10);

        media = (voto1 + voto2) / 2.0;

        return media >= 6.0;
    }
}
