using System;
using System.Collections.Generic;

namespace EsercizioDuePattern2
{
    // La classe ConfigurazioneSistema implementa il pattern Singleton.
    // Questo pattern assicura che esista una sola istanza di questa classe
    // in tutto il programma e fornisce un punto di accesso globale a tale istanza.
    // La classe è 'sealed' per prevenire l'ereditarietà, che potrebbe compromettere il pattern.
    public sealed class ConfigurazioneSistema
    {
        // Dizionario privato per memorizzare le impostazioni di configurazione.
        private Dictionary<string, string> _configurazioni = new Dictionary<string, string>();
    
        // L'unica istanza della classe. È statica e privata.
        private static ConfigurazioneSistema _instance = null;
    
        // Il costruttore è privato per impedire la creazione di istanze
        // dall'esterno della classe.
        private ConfigurazioneSistema()
        {
            _configurazioni = new Dictionary<string, string>();
        }
    
        // Proprietà statica pubblica per accedere all'unica istanza della classe.
        // Questo è il punto di accesso globale del Singleton.
        public static ConfigurazioneSistema Istanza
        {
            get
            {
                // Se l'istanza non è ancora stata creata, la crea.
                // Questo approccio è chiamato "lazy initialization".
                if (_instance == null)
                {
                    _instance = new ConfigurazioneSistema();
                }
                return _instance;
            }
        }
    
        // Metodo per impostare una configurazione.
        public void Imposta(string chiave, string valore)
        {
            _configurazioni[chiave] = valore;
        }
    
        // Metodo per leggere una configurazione.
        public string Leggi(string chiave)
        {
            if (_configurazioni.ContainsKey(chiave))
            {
                return _configurazioni[chiave];
            }
            return null;
        }
    
        // Metodo per stampare tutte le configurazioni.
        public void StampaTutte()
        {
            foreach (var item in _configurazioni)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }

    // Interfaccia IDispositivo che definisce il contratto per tutti i dispositivi.
    // Qualsiasi classe che implementa questa interfaccia dovrà fornire
    // un'implementazione per i metodi Avvia() e MostraTipo().
    public interface IDispositivo
    {
        public void Avvia();
        public void MostraTipo();
    }

    // Classe concreta che implementa l'interfaccia IDispositivo.
    // Rappresenta un tipo specifico di dispositivo: il Computer.
    public class Computer : IDispositivo
    {
        public void Avvia()
        {
            Console.WriteLine("Avvio del computer.");
        }
    
        public void MostraTipo()
        {
            Console.WriteLine("Tipo: Computer");
        }
    }
    // Classe concreta che implementa l'interfaccia IDispositivo.
    // Rappresenta un tipo specifico di dispositivo: la Stampante.
    public class Stampante : IDispositivo
    {
        public void Avvia()
        {
            Console.WriteLine("Avvio della stampante.");
        }
    
        public void MostraTipo()
        {
            Console.WriteLine("Tipo: Stampante");
        }
    }

    // La classe DispositivoFactory implementa il pattern Factory.
    // Questo pattern fornisce un'interfaccia per creare oggetti in una superclasse,
    // ma permette alle sottoclassi di alterare il tipo di oggetti che verranno creati.
    // In questo caso, centralizza la logica di creazione dei dispositivi.
    public class DispositivoFactory
    {
        // Il metodo CreaDispositivo si occupa di istanziare la classe corretta
        // in base al tipo richiesto come stringa.
        public IDispositivo CreaDispositivo(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "computer":
                    return new Computer();
                case "stampante":
                    return new Stampante();
                default:
                    // Se il tipo non è riconosciuto, restituisce null e stampa un messaggio.
                    Console.WriteLine("Tipo di dispositivo non valido.");
                    return null;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Si ottiene l'istanza del Singleton per il ModuloA.
            ConfigurazioneSistema ModuloA = ConfigurazioneSistema.Istanza;
            // Si impostano delle configurazioni.
            ModuloA.Imposta("Nome", "PC123");
            ModuloA.Imposta("Memoria", "16GB");
    
            // Si utilizza la factory per creare i dispositivi.
            // Il client (in questo caso il Main) non ha bisogno di sapere come
            // vengono create le istanze concrete di Computer o Stampante.
            DispositivoFactory factory = new DispositivoFactory();
            IDispositivo computer1 = factory.CreaDispositivo("computer");
    
            IDispositivo stampante1 = factory.CreaDispositivo("stampante");
    
    
            // Si ottiene nuovamente l'istanza del Singleton per il ModuloB.
            // Poiché è un Singleton, ModuloB sarà lo stesso oggetto di ModuloA.
            ConfigurazioneSistema ModuloB = ConfigurazioneSistema.Istanza;
            // Si modificano le configurazioni. Queste modifiche si rifletteranno
            // anche su ModuloA, perché sono lo stesso oggetto.
            ModuloB.Imposta("Nome", "PC456");
            ModuloB.Imposta("Memoria", "8GB");
    
            // Si creano altri dispositivi con la stessa factory.
            IDispositivo computer2 = factory.CreaDispositivo("computer");
    
            IDispositivo stampante2 = factory.CreaDispositivo("stampante");
    
    
            // Si verifica che ModuloA e ModuloB siano effettivamente la stessa istanza.
            // object.ReferenceEquals confronta i riferimenti in memoria degli oggetti.
            if (object.ReferenceEquals(ModuloA, ModuloB))
            {
                Console.WriteLine("ModuloA e ModuloB fanno riferimento allo stesso oggetto.");
            }
            else
            {
                Console.WriteLine("ModuloA e ModuloB fanno riferimento a oggetti diversi.");
            }
    
            // Si stampano le configurazioni da entrambi i "moduli".
            // L'output sarà identico, dimostrando che le modifiche fatte su ModuloB
            // sono visibili anche da ModuloA.
            ModuloB.StampaTutte();
            ModuloA.StampaTutte();
    
            // Si utilizzano i dispositivi creati.
            computer1.Avvia();
            computer1.MostraTipo();
            stampante1.Avvia();
            stampante1.MostraTipo();
            computer2.Avvia();
            computer2.MostraTipo();
            stampante2.Avvia();
            stampante2.MostraTipo();
    
    
        }
    }
}