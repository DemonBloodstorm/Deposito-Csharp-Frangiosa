using System;
using System.Collections.Generic;

namespace DeleagteExtra
{
    public class MostraMenu
    {
        delegate int Operazione(int a, int b);
        public static string nome;
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
            nome = Console.ReadLine();
            Console.WriteLine($"Benvenuto {nome}");
        }
        public static void menuOperazioni()
        {
            Console.WriteLine($"Cosa vuoi fare {nome}?");
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
    public class Program
    {
        public static void Main(string[] args)
        {
            MostraMenu.Utente();
            MostraMenu.menuOperazioni();
            MostraMenu.SceltaOperazione();
        }
    }
}