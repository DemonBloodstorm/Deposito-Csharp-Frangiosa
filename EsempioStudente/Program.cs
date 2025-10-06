using System;

class Studente
{
    public string nome;
    public int matricola;
    public double media;

    public Studente(string nome, int matricola, double media)
    {
        this.nome = nome;
        this.matricola = matricola;
        this.media = media;
    }
}

class EsempioStudente
{
    static void Main(string[] args)
    {
        Studente s = new Studente("Gabriele", 123456, 7.5);
        Studente s2 = new Studente("Giovanni", 654321, 8.5);

        Console.WriteLine($"s.studente: {s.nome}, {s.matricola}, {s.media}");
        Console.WriteLine($"s2.studente: {s2.nome}, {s2.matricola}, {s2.media}");
    }
}
