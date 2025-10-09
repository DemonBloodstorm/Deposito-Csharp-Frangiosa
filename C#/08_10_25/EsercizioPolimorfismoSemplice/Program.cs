using System;
using System.Collections.Generic;

public class Veicolo
{
    public string Targa { get; set; }
    public virtual void Ripara()
    {
        Console.WriteLine("Il veicolo viene controllato.");
    }
}

public class Auto : Veicolo
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo olio, freni e motore dell'auto.");
    }
}

public class Moto : Auto
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo catena, freni e gomme della moto.");
    }
}

public class Camion : Auto
{
    public override void Ripara()
    {
        Console.WriteLine("Controllo sospensioni, freni rinforzati e carico del camion.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>
        {
            new Auto { Targa = "ABC123" },
            new Moto { Targa = "XYZ789" },
            new Camion { Targa = "LMN456" }
        };

        foreach (Veicolo v in veicoli)
        {
            Console.WriteLine("Targa: " + v.Targa);
            v.Ripara();
        }
    }
}
