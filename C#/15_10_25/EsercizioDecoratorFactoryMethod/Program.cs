using System;

public interface ITorta // Interfaccia per le torte
{
    string Descrizione();
}

class TortaCioccolato : ITorta // Classe concreta per la torta al cioccolato
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
}

class TortaVaniglia : ITorta // Classe concreta per la torta alla vaniglia
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}

class TortaFrutta : ITorta // Classe concreta per la torta alla frutta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}

public abstract class DecoratoreTorta : ITorta // Classe astratta per i decoratori di torta
{
    protected ITorta _baseTorta;

    protected DecoratoreTorta(ITorta baseTorta)
    {
        _baseTorta = baseTorta;
    }

    public virtual string Descrizione()
    {
        return _baseTorta.Descrizione();
    }
}

static class TortaFactory // Classe factory per la creazione di torte
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo)
        {
            case "cioccolato":
                return new TortaCioccolato();
            case "vaniglia":
                return new TortaVaniglia();
            case "frutta":
                return new TortaFrutta();
            default:
                throw new ArgumentException("Tipo torta non valido");
        }
    }
}

class ConPanna : DecoratoreTorta // Classe concreta per il decoratore di panna
{
    public ConPanna(ITorta baseTorta) : base(baseTorta)
    {
    }

    public override string Descrizione()
    {
        string descrizioneBase = base.Descrizione();
        if (descrizioneBase.Contains("+ panna")) // Verifica se la torta ha già il decoratore di panna
        {
            return descrizioneBase;
        }
        else
        {
            return descrizioneBase + " + panna";
        }
    }
}

class ConFragole : DecoratoreTorta // Classe concreta per il decoratore di fragole
{
    public ConFragole(ITorta baseTorta) : base(baseTorta)
    {
    }

    public override string Descrizione()
    {
        string descrizioneBase = base.Descrizione();
        if (descrizioneBase.Contains("+ fragole")) // Verifica se la torta ha già il decoratore di fragole
        {
            return descrizioneBase;
        }
        else
        {
            return descrizioneBase + " + fragole";
        }
    }
}

class ConGlassa : DecoratoreTorta // Classe concreta per il decoratore di glassa
{
    public ConGlassa(ITorta baseTorta) : base(baseTorta)
    {
    }

    public override string Descrizione()
    {
        string descrizioneBase = base.Descrizione();
        if (descrizioneBase.Contains("+ glassa")) // Verifica se la torta ha già il decoratore di glassa
        {
            return descrizioneBase;
        }
        else
        {
            return descrizioneBase + " + glassa";
        }
    }
}

public class Program 
{
    public static void Main(string[] args) 
    {
        ITorta torta = TortaFactory.CreaTortaBase("frutta"); // Crea una torta alla frutta
        Console.WriteLine(torta.Descrizione());
        
        torta = new ConPanna(torta); // Aggiunge la panna alla torta
        Console.WriteLine(torta.Descrizione());
        
        torta = new ConFragole(torta); // Aggiunge le fragole alla torta
        Console.WriteLine(torta.Descrizione());
        
        torta = new ConGlassa(torta); // Aggiunge la glassa alla torta
        Console.WriteLine(torta.Descrizione());
    }
}