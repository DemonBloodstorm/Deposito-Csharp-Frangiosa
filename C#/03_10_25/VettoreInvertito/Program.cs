using System;

class Program
{
    public static void Main(string[] args)
    {
        int grandezza, n_ricercato = 0, contatore = 0;
        int[] vettore;
        int[] vettoreInvertito;
        bool trovato = false;

        Console.WriteLine($"Quanti numeri interi vuoi inserire?");
        grandezza = int.Parse(Console.ReadLine());
        vettore = new int[grandezza];
        vettoreInvertito = new int[grandezza];

        for (int i = 0; i < vettore.Length; i++)
        {
            Console.WriteLine($"Inserisci il {i + 1} numero:");
            vettore[i] = int.Parse(Console.ReadLine());
        }

        for (int i = grandezza - 1; i >= 0; i--)
        {
            
            vettoreInvertito[contatore] = vettore[i];
            contatore++;
        }

        Console.WriteLine($"Quale numero vuoi cercare?");
        n_ricercato = int.Parse(Console.ReadLine());
        for (int i = 0; i < vettoreInvertito.Length; i++)
        {
            if (vettore[i] == n_ricercato)
            {
                Console.WriteLine($"Il numero {n_ricercato} è stato trovato all'indice {i + 1}");
                contatore++;
                trovato = true;
            }
        }
        if (trovato == false)
        {
            Console.WriteLine($"Il numero {n_ricercato} non è stato trovato");
        }

        Console.WriteLine($"Il vettore invertito è:");
        for (int i = 0; i < vettoreInvertito.Length; i++)
        {
            Console.WriteLine(vettoreInvertito[i]);
        }
    }
}