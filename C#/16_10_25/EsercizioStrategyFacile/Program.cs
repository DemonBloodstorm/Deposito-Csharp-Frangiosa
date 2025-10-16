using System;

interface IStrategiaOperazione
{
    double Calcola(double x, double y);
}

class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double x, double y)
    {
        return x + y;
    }
}
class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double x, double y)
    {
        return x - y;
    }
}
class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double x, double y)
    {
        return x * y;
    }
}
class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double x, double y)
    {
        return x / y;
    }
}

class Calcolatrice
{
    private IStrategiaOperazione _strategia;
    public void ImpostaStrategia(IStrategiaOperazione strategia)
    {
        _strategia = strategia;
    }
    public double EseguiOperazione(double x, double y)
    {
        return _strategia.Calcola(x, y);
    }
}

class MostraMenu
{
    public void Menu()
    {
        Console.WriteLine($"1. Somma");
        Console.WriteLine($"2. Sottrazione");
        Console.WriteLine($"3. Moltiplicazione");
        Console.WriteLine($"4. Divisione");
        Console.WriteLine($"0. Esci");
    }
}

class program
{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        Calcolatrice calcolatrice = new Calcolatrice();
        int scelta;
        bool loop = true;
        double x, y;
        while(loop == true)
        {
            menu.Menu();
            scelta = int.Parse(Console.ReadLine());
            switch(scelta)
            {
                case 0:
                    loop = false;
                    break;
                case 1:
                    calcolatrice.ImpostaStrategia(new SommaStrategia());
                    Console.WriteLine($"Inserisci il primo numero:");
                    x = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Inserisci il secondo numero:");
                    y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Il risultato è: {calcolatrice.EseguiOperazione(x, y)}");
                    break;
                case 2:
                    calcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                    Console.WriteLine($"Inserisci il primo numero:");
                    x = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Inserisci il secondo numero:");
                    y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Il risultato è: {calcolatrice.EseguiOperazione(x, y)}");
                    break;
                case 3:
                    calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                    Console.WriteLine($"Inserisci il primo numero:");
                    x = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Inserisci il secondo numero:");
                    y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Il risultato è: {calcolatrice.EseguiOperazione(x, y)}");
                    break;
                case 4:
                    calcolatrice.ImpostaStrategia(new DivisioneStrategia());
                    Console.WriteLine($"Inserisci il primo numero:");
                    x = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Inserisci il secondo numero:");
                    y = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Il risultato è: {calcolatrice.EseguiOperazione(x, y)}");
                    break;
            }
        }
    }
}















































