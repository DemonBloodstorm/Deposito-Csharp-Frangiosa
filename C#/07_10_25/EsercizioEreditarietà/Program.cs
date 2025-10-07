using System;
using System.Collections.Generic;

public class Veicolo
{
    public string Marca;
    public string Modello;

    public override string ToString()
    {
        return $"{Marca} {Modello}";
    }
}

public class Auto : Veicolo
{
    public int NumeroPorte;

    public override string ToString()
    {
        return $"{base.ToString()} con {NumeroPorte} porte";
    }
}

public class Moto : Veicolo
{
    public string TipoManubrio;

    public override string ToString()
    {
        return $"{base.ToString()} con manubrio {TipoManubrio}";
    }
}

public class Menu
{
    public string MostraMenu()
    {
        Console.WriteLine("Cosa vuoi fare?");
        Console.WriteLine("1. Aggiungi auto");
        Console.WriteLine("2. Aggiungi moto");
        Console.WriteLine("3. Visualizza veicoli");
        Console.WriteLine("4. Esci");
        return Console.ReadLine();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        //List<Veicolo> veicoli = new List<Veicolo>();
        string[][] veicoli = new string[10][];
        Menu menu = new Menu();
        Moto nuovaMoto = new Moto();
        Auto nuovaAuto = new Auto();

        while (true)
        {
            string scelta = menu.MostraMenu();

            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Inserisci marca dell'auto:");
                    string marca = Console.ReadLine();

                    Console.WriteLine("Inserisci modello dell'auto:");
                    string modello = Console.ReadLine();

                    Console.WriteLine("Inserisci numero porte:");
                    int porte = int.Parse(Console.ReadLine());


                    nuovaAuto.Marca = marca;
                    nuovaAuto.Modello = modello;
                    nuovaAuto.NumeroPorte = porte;
                    //veicoli.Add(nuovaAuto);
                    for (int i = 0; i < veicoli.Length; i++)
                    {
                        if (veicoli[i] == null)
                        {
                            veicoli[i] = new string[] { marca, modello, porte.ToString() };
                            break;
                        }
                    }

                    break;

                case "2":
                    Console.WriteLine("Inserisci marca della moto:");
                    marca = Console.ReadLine();

                    Console.WriteLine("Inserisci modello della moto:");
                    modello = Console.ReadLine();

                    Console.WriteLine("Inserisci tipo di manubrio:");
                    string manubrio = Console.ReadLine();


                    nuovaMoto.Marca = marca;
                    nuovaMoto.Modello = modello;
                    nuovaMoto.TipoManubrio = manubrio;
                    //veicoli.Add(nuovaMoto);
                    for (int i = 0; i < veicoli.Length; i++)
                    {
                        if (veicoli[i] == null)
                        {
                            veicoli[i] = new string[] { marca, modello, manubrio };
                            break;
                        }
                    }
                    break;

                case "3":
                    if (veicoli.Length == 0)
                        Console.WriteLine("Nessun veicolo registrato.");
                    else
                        // foreach (Veicolo v in veicoli)
                        //     Console.WriteLine(v);
                        for (int i = 0; i < veicoli.Length; i++)
                        {
                            if (veicoli[i] != null)
                            {
                                Console.Write(veicoli[i][0] + " " + veicoli[i][1]);
                                if (int.TryParse(veicoli[i][2], out int nPorte))
                                    Console.WriteLine($" con {nPorte} porte");
                                else
                                    Console.WriteLine($" con manubrio {veicoli[i][2]}");
                            }
                        }
                    break;

                case "4":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
        }
    }
}
