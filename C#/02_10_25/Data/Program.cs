using System;

class Program
{
    public static void Main(string[] args)
    {
        int giorno = 32, mese = 12, anno = 2023;
        AggiustaData(ref giorno, ref mese, ref anno);
        Console.WriteLine("Data corretta: " + giorno + "/" + mese + "/" + anno);
    }
    static void AggiustaData(ref int giorno, ref int mese, ref int anno)
    {
        if (giorno < 1 || giorno > 31)
        {
            giorno = 1;
            mese++;
        }
        if (mese < 1 || mese > 12)
        {
            mese = 1;
            anno++;
        }
        if (anno < 1)
        {
            anno = 1;
        }
    }
}