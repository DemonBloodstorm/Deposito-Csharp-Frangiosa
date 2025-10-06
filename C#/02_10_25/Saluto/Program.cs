using System;


class Program
{
    public static void StampaSaluto(String nome)
    {
        Console.WriteLine("Ciao, " + nome + "! Come stai?");
    }
    public static void Main(string[] args)
    {
        String nome;
        Console.WriteLine("Inserisci il tuo nome:");
        nome = Console.ReadLine();
        StampaSaluto(nome);
    }
}