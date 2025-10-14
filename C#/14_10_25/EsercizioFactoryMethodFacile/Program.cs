using System;

public interface IVeicolo
{
    void Accendi();
    void MostraTipo();
}

public interface INave
{
    void Accendi();
    void MostraTipo();
}

public class Auto : IVeicolo
{
    public void Accendi()
    {
        Console.WriteLine("Avvio dell'auto");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

public class Moto : IVeicolo
{
    public void Accendi()
    {
        Console.WriteLine("Avvio della moto");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

public class Camion : IVeicolo
{
    public void Accendi()
    {
        Console.WriteLine("Avvio del camion");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

public class Motoscafo : INave
{
    public void Accendi()
    {
        Console.WriteLine("Avvio della motoscafo");
    }
    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Motoscafo");
    }
}

public abstract class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        return new Auto();
    }
}
public abstract class NaveFactory
{
    public static INave CreaVeicolo(string tipo)
    {
        return new Motoscafo();
    }
}

public class AutoFactory : VeicoloFactory
{
    public static IVeicolo CreaVeicolo() => new Auto();
}

public class MotoFactory : VeicoloFactory
{
    public static IVeicolo CreaVeicolo() => new Moto();
}

public class CamionFactory : VeicoloFactory
{
    public static IVeicolo CreaVeicolo() => new Camion();
}
public class MotoscafoFactory : NaveFactory
{
    public static INave CreaVeicolo() => new Motoscafo();
}

public class Program
{
    public static void Main(string[] args)
    {
        string tipo;
        Console.WriteLine($"Quale veicolo vuoi creare (Auto, Moto, Camion, Motoscafo)?");
        tipo = Console.ReadLine();
        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo);
        switch (tipo.ToLower().Trim())
        {
            case "auto":
                veicolo = AutoFactory.CreaVeicolo();
                veicolo.Accendi();
                veicolo.MostraTipo();
                break;
            case "moto":
                veicolo = MotoFactory.CreaVeicolo();
                veicolo.Accendi();
                veicolo.MostraTipo();
                break;
            case "camion":
                veicolo = CamionFactory.CreaVeicolo();
                veicolo.Accendi();
                veicolo.MostraTipo();
                break;
            case "nave":
                INave nave = MotoscafoFactory.CreaVeicolo();
                nave.Accendi();
                nave.MostraTipo();
                break;
            default:
                Console.WriteLine($"Tipo di veicolo non valido: {tipo}");
                break;
        }
    }
}