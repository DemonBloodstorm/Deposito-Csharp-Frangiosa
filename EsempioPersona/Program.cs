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
        Persona p = new Persona("Gabriele", "Frangiosa", 2002);
        Persona p2 = new Persona("Giovanni", "Frangiosa", 2000);

        Console.WriteLine($"p.persona: {p.nome}, {p.Cognome}, {p.AnnoNascita}");
        Console.WriteLine($"p2.persona: {p2.nome}, {p2.Cognome}, {p2.AnnoNascita}");

    }
}
