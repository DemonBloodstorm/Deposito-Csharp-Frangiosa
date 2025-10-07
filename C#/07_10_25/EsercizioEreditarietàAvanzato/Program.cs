using System;
using System.Collections.Generic;

public class Corso
{
    public string NomeCorso;
    public int DurataOre;
    public string Docente;
    public List<string> Studenti = new List<string>();

    public static List<Corso> TuttiICorsi = new List<Corso>();

    public void AggiungiStudente(string nomeStudente)
    {
        Studenti.Add(nomeStudente);
        Console.WriteLine($"Studente {nomeStudente} aggiunto al corso {NomeCorso}");
    }

    public virtual void MetodoSpeciale()
    {
        Console.WriteLine("Metodo speciale del corso");
    }

    public override string ToString()
    {
        return $"{NomeCorso}, di {Docente}, {DurataOre} ore, studenti iscritti: {Studenti.Count}";
    }

    public static List<int> CercaCorsiPerDocente(string docente)
    {
        List<int> indici = new List<int>();
        for (int i = 0; i < TuttiICorsi.Count; i++)
        {
            if (TuttiICorsi[i].Docente.Equals(docente, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[{i}] {TuttiICorsi[i]}");
                indici.Add(i);
            }
        }
        if (indici.Count == 0)
            Console.WriteLine($"Nessun corso trovato per il docente {docente}");
        return indici;
    }

    public static void VisualizzaTuttiICorsi()
    {
        if (TuttiICorsi.Count == 0)
        {
            Console.WriteLine("Nessun corso disponibile.");
            return;
        }
        for (int i = 0; i < TuttiICorsi.Count; i++)
            Console.WriteLine($"[{i}] {TuttiICorsi[i]}");
    }
}

public class CorsoMusica : Corso
{
    public string Strumento;

    public CorsoMusica(string nomeCorso, int durataOre, string docente, string strumento)
    {
        NomeCorso = nomeCorso;
        DurataOre = durataOre;
        Docente = docente;
        Strumento = strumento;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si tiene una prova pratica dello strumento: {Strumento}");
    }

    public override string ToString()
    {
        return base.ToString() + $", strumento: {Strumento}";
    }
}

public class CorsoPittura : Corso
{
    public string Tecnica;

    public CorsoPittura(string nomeCorso, int durataOre, string docente, string tecnica)
    {
        NomeCorso = nomeCorso;
        DurataOre = durataOre;
        Docente = docente;
        Tecnica = tecnica;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si lavora su tela usando la tecnica: {Tecnica}");
    }

    public override string ToString()
    {
        return base.ToString() + $", tecnica: {Tecnica}";
    }
}

public class CorsoDanza : Corso
{
    public string Stile;

    public CorsoDanza(string nomeCorso, int durataOre, string docente, string stile)
    {
        NomeCorso = nomeCorso;
        DurataOre = durataOre;
        Docente = docente;
        Stile = stile;
    }

    public override void MetodoSpeciale()
    {
        Console.WriteLine($"Si fa una prova di danza: {Stile}");
    }

    public override string ToString()
    {
        return base.ToString() + $", stile: {Stile}";
    }
}

public class Menu
{
    public void MostraMenu()
    {
        Console.WriteLine("\n--- MENU ---");
        Console.WriteLine("[1] Aggiungi un corso di Musica");
        Console.WriteLine("[2] Aggiungi un corso di Pittura");
        Console.WriteLine("[3] Aggiungi un corso di Danza");
        Console.WriteLine("[4] Aggiungi studente a un corso (con selezione per indice)");
        Console.WriteLine("[5] Visualizza tutti i corsi");
        Console.WriteLine("[6] Cerca corsi per nome docente (con selezione per indice)");
        Console.WriteLine("[7] Esegui metodo speciale di un corso (selezionato per indice)");
        Console.WriteLine("[0] Esci");
        Console.Write("Scelta: ");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        bool continua = true;

        string nomeMusica, docenteMusica, strumento;
        string nomePittura, docentePittura, tecnica;
        string nomeDanza, docenteDanza, stile;
        string nomeStudente, docenteRicerca;
        int durataMusica = 0, durataPittura = 0, durataDanza = 0;

        while (continua)
        {
            menu.MostraMenu();
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci nome corso: ");
                    nomeMusica = Console.ReadLine();
                    Console.Write("Inserisci durata ore: ");
                    if (!int.TryParse(Console.ReadLine(), out durataMusica))
                    {
                        Console.WriteLine("Valore durata non valido.");
                        break;
                    }
                    Console.Write("Inserisci nome docente: ");
                    docenteMusica = Console.ReadLine();
                    Console.Write("Inserisci strumento: ");
                    strumento = Console.ReadLine();

                    CorsoMusica corsoMusica = new CorsoMusica(nomeMusica, durataMusica, docenteMusica, strumento);
                    Corso.TuttiICorsi.Add(corsoMusica);
                    Console.WriteLine("Corso di Musica aggiunto.");
                    break;

                case "2":
                    Console.Write("Inserisci nome corso: ");
                    nomePittura = Console.ReadLine();
                    Console.Write("Inserisci durata ore: ");
                    if (!int.TryParse(Console.ReadLine(), out durataPittura))
                    {
                        Console.WriteLine("Valore durata non valido.");
                        break;
                    }
                    Console.Write("Inserisci nome docente: ");
                    docentePittura = Console.ReadLine();
                    Console.Write("Inserisci tecnica: ");
                    tecnica = Console.ReadLine();

                    CorsoPittura corsoPittura = new CorsoPittura(nomePittura, durataPittura, docentePittura, tecnica);
                    Corso.TuttiICorsi.Add(corsoPittura);
                    Console.WriteLine("Corso di Pittura aggiunto.");
                    break;

                case "3":
                    Console.Write("Inserisci nome corso: ");
                    nomeDanza = Console.ReadLine();
                    Console.Write("Inserisci durata ore: ");
                    if (!int.TryParse(Console.ReadLine(), out durataDanza))
                    {
                        Console.WriteLine("Valore durata non valido.");
                        break;
                    }
                    Console.Write("Inserisci nome docente: ");
                    docenteDanza = Console.ReadLine();
                    Console.Write("Inserisci stile: ");
                    stile = Console.ReadLine();

                    CorsoDanza corsoDanza = new CorsoDanza(nomeDanza, durataDanza, docenteDanza, stile);
                    Corso.TuttiICorsi.Add(corsoDanza);
                    Console.WriteLine("Corso di Danza aggiunto.");
                    break;

                case "4":
                    if (Corso.TuttiICorsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile.");
                        break;
                    }
                    Console.Write("Inserisci nome studente: ");
                    nomeStudente = Console.ReadLine();
                    Corso.VisualizzaTuttiICorsi();
                    Console.Write("Seleziona indice corso a cui aggiungere studente: ");
                    if (!int.TryParse(Console.ReadLine(), out int indiceCorsoStudente) || indiceCorsoStudente < 0 || indiceCorsoStudente >= Corso.TuttiICorsi.Count)
                    {
                        Console.WriteLine("Indice non valido.");
                        break;
                    }
                    Corso.TuttiICorsi[indiceCorsoStudente].AggiungiStudente(nomeStudente);
                    break;

                case "5":
                    Corso.VisualizzaTuttiICorsi();
                    break;

                case "6":
                    Console.Write("Inserisci nome docente da cercare: ");
                    docenteRicerca = Console.ReadLine();
                    Corso.CercaCorsiPerDocente(docenteRicerca);
                    break;

                case "7":
                    if (Corso.TuttiICorsi.Count == 0)
                    {
                        Console.WriteLine("Nessun corso disponibile.");
                        break;
                    }
                    Corso.VisualizzaTuttiICorsi();
                    Console.Write("Seleziona indice corso per eseguire metodo speciale: ");
                    if (!int.TryParse(Console.ReadLine(), out int indiceMetodo) || indiceMetodo < 0 || indiceMetodo >= Corso.TuttiICorsi.Count)
                    {
                        Console.WriteLine("Indice non valido.");
                        break;
                    }
                    Corso.TuttiICorsi[indiceMetodo].MetodoSpeciale();
                    break;

                case "0":
                    Console.WriteLine("Uscita dal programma.");
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
