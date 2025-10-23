using System;
using System.Collections.Generic;

namespace DeleagteExtra
{
    public class Menu
    {
        delegate int Operazione(int a, int b);
        public static string nomeUtente;
        public static string nomeOperazione;
        public static int somma(int a, int b)
        {
            return a + b;
        }

        public static int moltiplicazione(int a, int b)
        {
            return a * b;
        }
        public static void Utente()
        {
            Console.WriteLine($"Inserisci nome utente: ");
            nomeUtente = Console.ReadLine();
            Console.WriteLine($"Benvenuto {nomeUtente}");
        }
        public static void Operazioni()
        {
            Console.WriteLine($"Cosa vuoi fare {nomeUtente}?");
            Console.WriteLine("1. Somma");
            Console.WriteLine("2. Moltiplicazione");
        }
        public static void SceltaOperazione()
        {
            Console.WriteLine($"Inserisci la tua scelta: ");
            int scelta = int.Parse(Console.ReadLine());
            if (scelta == 1)
            {
                Console.WriteLine($"Hai scelto la somma");
                Operazione op = somma;
                nomeOperazione = "somma";
                Console.WriteLine($"Inserisci il primo numero: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine($"Inserisci il secondo numero: ");
                int b = int.Parse(Console.ReadLine());
                int risultato = op(a, b);
                Console.WriteLine($"Il risultato della somma è: {risultato}");
            }
            else if (scelta == 2)
            {
                Console.WriteLine($"Hai scelto la moltiplicazione");
                Operazione op = moltiplicazione;
                nomeOperazione = "moltiplicazione";
                Console.WriteLine($"Inserisci il primo numero: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine($"Inserisci il secondo numero: ");
                int b = int.Parse(Console.ReadLine());
                int risultato = op(a, b);
                Console.WriteLine($"Il risultato della moltiplicazione è: {risultato}");

            }
            else
            {
                Console.WriteLine($"Scelta non valida");
            }
        }
    }
    public class DelegateLogger
    {
        public delegate void Logger(string message);
        private static Logger logger;
        public static void Log(string message)
        {
            if (logger != null)
            {
                logger(message);
            }
        }
        public static void SetLogger(Logger log)
        {
            logger = log;
        }
        public static void StampaSuConsole(string message)
        {
            Console.WriteLine(message);
        }
        public static void StampaSuFile(string message)
        {
            using (StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine(message);
                sw.Close();
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu.Utente();
            Menu.Operazioni();
            Menu.SceltaOperazione();
            var (nomeUtente, nomeOperazione) = (Menu.nomeUtente, Menu.nomeOperazione);
            DelegateLogger.Logger logger = DelegateLogger.StampaSuConsole;
            logger += DelegateLogger.StampaSuFile;
            DelegateLogger.SetLogger(logger);
            DelegateLogger.Log($"{nomeUtente}, hai eseguito l'operazione {nomeOperazione}");
            
        }
    }
}