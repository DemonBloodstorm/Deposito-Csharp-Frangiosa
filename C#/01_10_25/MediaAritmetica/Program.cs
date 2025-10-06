using System;

class Program
{
    public static void Main(string[] args)
    {
        int voto1, voto2, voto3;
        double media = 0;

        Console.WriteLine("Inserire voto");
        voto1 = int.Parse(Console.ReadLine());
        media += voto1;
        voto2 = int.Parse(Console.ReadLine());
        media += voto2;
        voto3 = int.Parse(Console.ReadLine());
        media += voto3;
        media = media / 3;
        if (media > 60)
        {
            Console.WriteLine("Hai superato la prova!");
            Console.WriteLine("Voto finale: " + media);
        }
        else
        {
            Console.WriteLine("Prova fallita.");
            Console.WriteLine("Voto finale: " + media);
        }
    }
}