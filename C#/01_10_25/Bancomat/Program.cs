using System;

class Program
{
    public static void Main(string[] args)
    {
        int scelta = -1;
        double saldo = 0, prelievo, deposito;
        while (scelta != 4)
        {
            Console.WriteLine("1. Visualizza saldo");
            Console.WriteLine("2. Deposita denaro");
            Console.WriteLine("3. Preleva denaro");
            Console.WriteLine("4. Esci");
            Console.Write("Scelta: ");
            scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    {
                        Console.WriteLine("Il tuo saldo corrente è: " + saldo);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Quanto vuoi depositare? ");
                        deposito = double.Parse(Console.ReadLine());
                        saldo += deposito;
                        Console.WriteLine("Hai depositato: " + deposito);
                        Console.WriteLine("Il tuo nuovo saldo è: " + saldo);
                        break;
                    }
                case 3:
                    {
                        Console.Write("Quanto vuoi prelevare? ");
                        prelievo = double.Parse(Console.ReadLine());
                        if (prelievo > saldo)
                        {
                            Console.WriteLine("Non hai abbastanza denaro!");
                        }
                        else
                        {
                            saldo -= prelievo;
                            Console.WriteLine("Hai prelevato: " + prelievo);
                            Console.WriteLine("Il tuo nuovo saldo è: " + saldo);
                        }
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Grazie per aver utilizzato il nostro bancomat!");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Scelta non valida!");
                        break;
                    }
            }
        }
    }
}