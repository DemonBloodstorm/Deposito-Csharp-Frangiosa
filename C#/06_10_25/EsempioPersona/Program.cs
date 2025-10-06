using System;

class Persona
{
    public string nome;
    public string Cognome;
    public int AnnoNascita;

    public Persona(string nome, string cognome, int annoNascita)
    {
        this.nome = nome;
        this.Cognome = cognome;
        this.AnnoNascita = annoNascita;
    }
}

class EsempioPersona
{
    static void Main(string[] args)
    {
        string[] persona = new string[2];
        Persona p = new Persona("Gabriele", "Frangiosa", 2002);
        Persona p2 = new Persona("Giovanni", "Frangiosa", 2000);

        persona[0] = p.nome + " " + p.Cognome + " " + p.AnnoNascita;
        persona[1] = p2.nome + " " + p2.Cognome + " " + p2.AnnoNascita;

        Console.WriteLine($"{p.nome} {p2.Cognome} è nato nell anno {p.AnnoNascita}");
        Console.WriteLine($"{p2.nome} {p.Cognome} è nato nell anno {p2.AnnoNascita}");
        Console.WriteLine($"La persona 0 è {persona[0]}");
        Console.WriteLine($"La persona 1 è {persona[1]}");
    }
}
