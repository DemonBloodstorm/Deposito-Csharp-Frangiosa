using System;
using System.Collections.Generic;

// Interfaccia comune
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}

// Pagamento con carta
public class PagamentoCarta : IPagamento
{
    public string Circuito { get; set; }

    public PagamentoCarta(string circuito)
    {
        Circuito = circuito;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro con carta (Circuito: {Circuito})");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Carta di credito");
    }
}

// Pagamento contanti
public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro in contanti");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: Contanti");
    }
}

// Pagamento PayPal
public class PagamentoPayPal : IPagamento
{
    public string EmailUtente { get; set; }

    public PagamentoPayPal(string email)
    {
        EmailUtente = email;
    }

    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}");
    }

    public void MostraMetodo()
    {
        Console.WriteLine("Metodo: PayPal");
    }
}


// Main
public class Program
{
    public static void Main()
    {
        decimal importo = 100m;

        // Creo la lista di pagamenti
        List<IPagamento> pagamenti = new List<IPagamento>
        {
            new PagamentoCarta("Visa"),
            new PagamentoContanti(),
            new PagamentoPayPal("utente@example.com")
        };

        // Richiamo i metodi per ogni oggetto nella lista
        pagamenti[0].MostraMetodo();
        pagamenti[0].EseguiPagamento(importo);
        Console.WriteLine();

        pagamenti[1].MostraMetodo();
        pagamenti[1].EseguiPagamento(importo);
        Console.WriteLine();

        pagamenti[2].MostraMetodo();
        pagamenti[2].EseguiPagamento(importo);
        Console.WriteLine();
    }
}
