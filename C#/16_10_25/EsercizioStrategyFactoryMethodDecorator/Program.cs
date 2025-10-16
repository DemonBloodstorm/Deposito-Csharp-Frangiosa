using System;


public interface IPiatto // Interfaccia per i piatti
{
    string Descrizione();
    string Prepara();
}


public class Pizza : IPiatto // Classe concreta per la pizza che implementa IPiatto
{
    public string Descrizione()
    {
        return "Pizza";
    }
    public string Prepara()
    {
        return "Preparo la pizza";
    }
}
public class Hamburger : IPiatto // Classe concreta per il hamburger che implementa IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
    public string Prepara()
    {
        return "Preparo il hamburger";
    }
}
public class Insalata : IPiatto // Classe concreta per l'insalata che implementa IPiatto
{
    public string Descrizione()
    {
        return "Insalata";
    }
    public string Prepara()
    {
        return "Preparo l'insalata";
    }
}

public abstract class IngredienteExtra : IPiatto // Classe astratta per gli ingredienti extra che implementa IPiatto
{
    protected IPiatto _piatto; // Campo per memorizzare il piatto a cui aggiungere l'ingrediente extra
    public IngredienteExtra(IPiatto piatto) // Costruttore per inizializzare il piatto a cui aggiungere l'ingrediente extra
    {
        _piatto = piatto;
    }
    public virtual string Descrizione() // Metodo virtuale per ottenere la descrizione del piatto con l'ingrediente extra
    {
        return _piatto.Descrizione();
    }
    public virtual string Prepara() // Metodo virtuale per ottenere il preparo del piatto con l'ingrediente extra
    {
        return _piatto.Prepara();
    }
}

public class ConFormaggio : IngredienteExtra // Classe concreta per aggiungere formaggio al piatto
{
    // Costruttore per inizializzare il piatto a cui aggiungere formaggio
    public ConFormaggio(IPiatto piatto) : base(piatto) 
    {
    }

    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con formaggio"))
        {
            return $"{_piatto.Descrizione()}";
        }
        else
        {
            return $"{_piatto.Descrizione()} con formaggio";
        }
    }
    public override string Prepara()
    {
        if (base.Descrizione().Contains("con formaggio"))
        {
            return $"{_piatto.Prepara()} aggiungendo ulteriore formaggio";
        }
        else
        {
            return $"{_piatto.Prepara()} aggiungendo formaggio";
        }
    }
}
public class ConBacon : IngredienteExtra // Classe concreta per aggiungere bacon al piatto
{
    // Costruttore per inizializzare il piatto a cui aggiungere bacon
    public ConBacon(IPiatto piatto) : base(piatto) 
    {
    }

    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con bacon"))
        {
            return $"{_piatto.Descrizione()}";
        }
        else
        {
            return $"{_piatto.Descrizione()} con bacon";
        }
    }
    public override string Prepara()
    {
        if (base.Descrizione().Contains("con bacon"))
        {
            return $"{_piatto.Prepara()} aggiungendo ulteriore bacon";
        }
        else
        {
            return $"{_piatto.Prepara()} aggiungendo bacon";
        }
    }
}
public class ConSalsa : IngredienteExtra // Classe concreta per aggiungere salsa al piatto
{
    // Costruttore per inizializzare il piatto a cui aggiungere salsa
    public ConSalsa(IPiatto piatto) : base(piatto) 
    {
    }
    public override string Descrizione()
    {
        if (base.Descrizione().Contains("con salsa"))
        {
            return $"{_piatto.Descrizione()}";
        }
        else
        {
            return $"{_piatto.Descrizione()} con salsa";
        }
    }
    public override string Prepara()
    {
        if (base.Descrizione().Contains("con salsa"))
        {
            return $"{_piatto.Prepara()} aggiungendo ulteriore salsa";
        }
        else
        {
            return $"{_piatto.Prepara()} aggiungendo salsa";
        }
    }
}

public static class PiattoFactory // Classe factory per creare piatti
{

    // Metodo factory per creare piatti in base al tipo specificato
    public static IPiatto CreaPiatto(string tipo)
    {
        switch (tipo.ToLower().Trim())
        {
            case "pizza":
                return new Pizza();
            case "hamburger":
                return new Hamburger();
            case "insalata":
                return new Insalata();
            default:
                throw new ArgumentException("Tipo di piatto non valido");
        }
    }
}

public interface IPreparazioneStrategia // Interfaccia per le strategie di preparazione
{
    string Prepara(string descrizione); // Metodo per preparare il piatto in base alla strategia
}

public class Fritto : IPreparazioneStrategia // Classe concreta per la strategia di preparazione fritto
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} fritto";
    }
}
public class AlForno : IPreparazioneStrategia // Classe concreta per la strategia di preparazione al forno
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} al forno";
    }
}
public class AllaGriglia : IPreparazioneStrategia // Classe concreta per la strategia di preparazione alla griglia
{
    public string Prepara(string descrizione)
    {
        return $"{descrizione} alla griglia";
    }
}

public class Chef // Classe concreta per il chef che prepara i piatti
{
    IPreparazioneStrategia _strategia;
    public Chef(IPreparazioneStrategia strategia)
    {
        _strategia = strategia;
    }
    public string PreparaPiatto(string descrizione)
    {
        return _strategia.Prepara(descrizione);
    }
}

public class MostraMenu // Classe concreta per mostrare il menu dei piatti
{
    public void MenuPiattoBase()
    {
        Console.WriteLine($"Benvenuto, cosa vuole ordinare?\n");
        Console.WriteLine("Menu piatto base:");
        Console.WriteLine("1. Pizza");
        Console.WriteLine("2. Hamburger");
        Console.WriteLine("3. Insalata");
        Console.WriteLine("4. Esci");
        
    }
    public void MenuIngredienteExtra()
    {
        Console.WriteLine($"Vuole aggiungere un ingrediente?\n");
        Console.WriteLine("Menu ingrediente extra:");
        Console.WriteLine("1. Con formaggio");
        Console.WriteLine("2. Con bacon");
        Console.WriteLine("3. Con salsa");
        Console.WriteLine("4. Nessun ingrediente");
        
    }
    public void MenuPreparazione()
    {
        Console.WriteLine($"Come vuole la cottura del piatto?\n");
        Console.WriteLine("Menu preparazione:");
        Console.WriteLine("1. Fritto");
        Console.WriteLine("2. Al forno");
        Console.WriteLine("3. Alla griglia");
    }
}

public class Program{
    public static void Main(string[] args)
    {
        MostraMenu menu = new MostraMenu();
        Chef chef;
        IPiatto piatto = null;
        int scelta;

        while (true) // Ciclo principale per l'ordinazione dei piatti
        {

            menu.MenuPiattoBase(); // Mostra il menu dei piatti base
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    piatto = PiattoFactory.CreaPiatto("Pizza"); // Crea una nuova pizza
                    menu.MenuIngredienteExtra();
                    scelta = int.Parse(Console.ReadLine());
                    switch (scelta)
                    {
                        case 1:
                            piatto = new ConFormaggio(piatto); // Aggiunge formaggio al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 2:
                            piatto = new ConBacon(piatto); // Aggiunge bacon al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 3:
                            piatto = new ConSalsa(piatto); // Aggiunge salsa al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 4:
                            menu.MenuPreparazione(); 
                            scelta = int.Parse(Console.ReadLine()); // Scelta della strategia di preparazione
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    piatto = PiattoFactory.CreaPiatto("Hamburger"); // Crea il piatto Hamburger
                    menu.MenuIngredienteExtra();
                    scelta = int.Parse(Console.ReadLine());
                    switch (scelta)
                    {
                        case 1:
                            piatto = new ConFormaggio(piatto); // Aggiunge formaggio al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 2:
                            piatto = new ConBacon(piatto); // Aggiunge bacon al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 3:
                            piatto = new ConSalsa(piatto); // Aggiunge salsa al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                    }
                    break;
                case 3:
                    piatto = PiattoFactory.CreaPiatto("Insalata"); // Crea il piatto Insalata
                    menu.MenuIngredienteExtra();
                    scelta = int.Parse(Console.ReadLine());
                    switch (scelta)
                    {
                        case 1:
                            piatto = new ConFormaggio(piatto); // Aggiunge formaggio al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 2:
                            piatto = new ConBacon(piatto); // Aggiunge bacon al piatto
                            menu.MenuPreparazione();
                            scelta = int.Parse(Console.ReadLine());
                            switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                        case 3:
                            piatto = new ConSalsa(piatto); // Aggiunge salsa al piatto
                        menu.MenuPreparazione();
                        scelta = int.Parse(Console.ReadLine());
                        switch (scelta)
                            {
                                case 1:
                                    chef = new Chef(new Fritto()); // Imposta la strategia di preparazione fritto
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 2:
                                    chef = new Chef(new AlForno()); // Imposta la strategia di preparazione al forno
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                                case 3:
                                    chef = new Chef(new AllaGriglia()); // Imposta la strategia di preparazione alla griglia
                                    Console.WriteLine(chef.PreparaPiatto(piatto.Descrizione()));
                                    break;
                            }
                            break;
                    }
                    break;
                case 4: // Esci dal programma
                { 
                    Console.WriteLine("Arrivederci!");
                    return; // Esce dal programma
                }
                default:
                Console.WriteLine("Scelta non valida!");
                break;
            }
        }
    }
}