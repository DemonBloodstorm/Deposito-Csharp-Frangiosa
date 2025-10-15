using System;
using System.Collections.Generic;

public interface IBevanda 
{
    string Descrizione();
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione()
    {
        return "Caffè";
    }
    public double Costo()
    {
        return 1.5;
    }
}
public class Te : IBevanda
{
    public string Descrizione()
    {
        return "Te'";
    }
    public double Costo()
    {
        return 2.0;
    }
}

public abstract class DecoratoreBevanda : IBevanda //Anche detto barista
{
    protected IBevanda _bevanda;
    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }
    public virtual string Descrizione()
    {
        return _bevanda.Descrizione();
    }

    public virtual double Costo()
    {
        return _bevanda.Costo();
    }

} 

class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda)
    {
    }
    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con latte"))
        {
            return base.Descrizione();
        }
        return _bevanda.Descrizione() + " con latte";
    }
    public override double Costo()
    {
        return _bevanda.Costo() + 0.2;
    }
}

class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda)
    {
    }
    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con panna"))
        {
            return base.Descrizione();
        }
        return base.Descrizione() + " con panna";
    }
    public override double Costo()
    {
        if (base.Descrizione().Contains("con panna"))
        {
            return base.Costo();
        }
        return base.Costo() + 0.5;
    }
}
class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda)
    { 
    }
    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con cioccolato"))
        {
            return base.Descrizione();
        }
        return base.Descrizione() + " con cioccolato";
    }
    public override double Costo()
    {
        if (base.Descrizione().Contains("con cioccolato"))
        {
            return base.Costo();
        }
        return base.Costo() + 1.0;
    }
}

public class MostraMenu{
    public void SceltaCaffeOTe(){
        Console.WriteLine($"Quale bevanda vuoi ordinare?");
        Console.WriteLine($"1. Caffè");
        Console.WriteLine($"2. Te'");
    }
    public void SceltaDecorazione()
    {
        Console.WriteLine($"Quale decorazione vuoi aggiungere?");
        Console.WriteLine($"1. Latte");
        Console.WriteLine($"2. Panna");
        Console.WriteLine($"3. Cioccolato");
    }
}

public class Program{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        IBevanda bevanda = null;
        int scelta;

        while (true)
        {
            menu.SceltaCaffeOTe();
            if (int.TryParse(Console.ReadLine(), out scelta))
            {
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Hai scelto il caffè\n");
                        bevanda = new Caffe();
                        break;
                    case 2:
                        Console.WriteLine("Hai scelto il te'\n");
                        bevanda = new Te();
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        continue;
                }
            }
            else
            {
                Console.WriteLine("Input non valido.");
                continue;
            }

            while (true)
            {
                menu.SceltaDecorazione();
                Console.WriteLine("4. Fine ordine");

                if (int.TryParse(Console.ReadLine(), out scelta))
                {
                    if (scelta == 4)
                    {
                        break;
                    }

                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("Hai scelto il latte");
                            bevanda = new ConLatte(bevanda);
                            break;
                        case 2:
                            Console.WriteLine("Hai scelto la panna");
                            bevanda = new ConPanna(bevanda);
                            break;
                        case 3:
                            Console.WriteLine("Hai scelto il cioccolato");
                            bevanda = new ConCioccolato(bevanda);
                            break;
                        default:
                            Console.WriteLine("Scelta non valida");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Input non valido.");
                }
            }

            Console.WriteLine($"Riepilogo ordine: {bevanda.Descrizione()}");
            Console.WriteLine($"Costo totale: {bevanda.Costo()}");
            Console.WriteLine("\nNuovo ordine:");
        }
    }
}