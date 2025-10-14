using System;
using System.Collections.Generic;

namespace EsercizioDuePattern2
{
    public sealed class ConfigurazioneSistema
    {
        private Dictionary<string, string> _configurazioni = new Dictionary<string, string>();
        private static ConfigurazioneSistema _instance = null;

        private ConfigurazioneSistema()
        {
            _configurazioni = new Dictionary<string, string>();
        }

        public static ConfigurazioneSistema Istanza
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurazioneSistema();
                }
                return _instance;
            }
        }

        public void Imposta(string chiave, string valore)
        {
            _configurazioni[chiave] = valore;
        }

        public string Leggi(string chiave)
        {
            if (_configurazioni.ContainsKey(chiave))
            {
                return _configurazioni[chiave];
            }
            return null;
        }

        public void StampaTutte()
        {
            foreach (var item in _configurazioni)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }

    public interface IDispositivo
    {
        public void Avvia();
        public void MostraTipo();
    }

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

    public static class DispositivoFactory
    {
        public static IDispositivo CreaDispositivo(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "computer":
                    return new Computer();
                case "stampante":
                    return new Stampante();
                default:
                    Console.WriteLine("Tipo di dispositivo non valido.");
                    return null;
            }
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            ConfigurazioneSistema ModuloA = ConfigurazioneSistema.Istanza;
            ModuloA.Imposta("Nome", "PC123");
            ModuloA.Imposta("Memoria", "16GB");

            IDispositivo computer1 = DispositivoFactory.CreaDispositivo("computer");

            IDispositivo stampante1 = DispositivoFactory.CreaDispositivo("stampante");


            ConfigurazioneSistema ModuloB = ConfigurazioneSistema.Istanza;
            ModuloB.Imposta("Nome", "PC456");
            ModuloB.Imposta("Memoria", "8GB");

            IDispositivo computer2 = DispositivoFactory.CreaDispositivo("computer");

            IDispositivo stampante2 = DispositivoFactory.CreaDispositivo("stampante");


            if (object.ReferenceEquals(ModuloB, ModuloA))
            {
                Console.WriteLine("ModuloA e ModuloB fanno riferimento allo stesso oggetto.");
            }
            else
            {
                Console.WriteLine("ModuloA e ModuloB fanno riferimento a oggetti diversi.");
            }

            ModuloB.StampaTutte();

            Console.WriteLine();

            ModuloA.StampaTutte();

            Console.WriteLine();

            computer1.Avvia();
            computer1.MostraTipo();

            Console.WriteLine();

            stampante1.Avvia();
            stampante1.MostraTipo();


            Console.WriteLine();

            computer2.Avvia();
            computer2.MostraTipo();

            Console.WriteLine();

            stampante2.Avvia();
            stampante2.MostraTipo();
        }
    }
}