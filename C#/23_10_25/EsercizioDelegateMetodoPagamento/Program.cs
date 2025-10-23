using System;


namespace DelegatePagamentoApp
{
    #region Interfaccia Pagamenti e Classi Implementazioni
    public interface IPagamento
    {
        string TipoPagamento { get;}
        decimal Pagamento(decimal importo);
    }

    public class Bonifico : IPagamento
    {
        public string TipoPagamento { get; set; } = "Bonifico";
        public decimal Pagamento(decimal importo)
        {
            return importo;
        }
    }
    public class PayPal : IPagamento
    {
        public string TipoPagamento { get; set; } = "PayPal";
        public decimal Pagamento(decimal importo)
        {
            return importo;
        }
    }
    public class CartaDiCredito : IPagamento
    {
        public string TipoPagamento { get; set; } = "CartaDiCredito";
        public decimal Pagamento(decimal importo)
        {
            return importo;
        }
    }
    #endregion

    #region Factory Pagamenti
    public class PagamentoFactory
    {
        public enum TipoPagamento
        {
            Bonifico,
            CartaDiCredito,
            PayPal
        }
        public IPagamento CreaPagamento(TipoPagamento tipo)
        {
            return tipo switch
            {
                TipoPagamento.Bonifico => new Bonifico(),
                TipoPagamento.CartaDiCredito => new CartaDiCredito(),
                TipoPagamento.PayPal => new PayPal(),
                _ => throw new ArgumentException("Tipo di pagamento non valido")
            };
        }
    }
    #endregion

    #region Logger con sconti

    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"[LOG] {message}");
    }

    public interface IDiscountPolicy
    {
        decimal ApplicaSconto(decimal importo);
    }

    public class NessunoSconto : IDiscountPolicy
    {
        public decimal ApplicaSconto(decimal importo) => importo;
    }

    public class DieciPercentoSconto : IDiscountPolicy
    {
        public decimal ApplicaSconto(decimal importo) => importo * 0.9m;
    }
    #endregion

    #region Processa Pagamenti dependecncy injection
    public class ProcessaPagamento
    {
        public delegate void PagamentoCompletatoHandler(string id, decimal totale);
        private readonly IPagamento _pagamento;
        private readonly IDiscountPolicy _discountPolicy;
        private readonly ILogger _logger;
        public event PagamentoCompletatoHandler OnPagamentoCompletato;
        public ProcessaPagamento(IPagamento pagamento, IDiscountPolicy discountPolicy, ILogger logger)
        {
            _pagamento = pagamento;
            _discountPolicy = discountPolicy;
            _logger = logger;
        }
        public void EseguiPagamento(string id, decimal importo)
        {
            decimal importoScontato = _discountPolicy.ApplicaSconto(importo);
            _logger.Log($"Eseguendo pagamento {id} con {_pagamento.TipoPagamento}, importo scontato: {importoScontato:C}");
            
            decimal totale = _pagamento.Pagamento(importoScontato);
            _logger.Log($"Pagamento {id} completato, totale: {totale:C}");

            OnPagamentoCompletato?.Invoke(id, totale);
        }
    }
    #endregion

    #region Program
    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new PagamentoFactory();
            var logger = new ConsoleLogger();

            // Scelta tipo pagamento
            Console.WriteLine("Scegli il tipo di pagamento:");
            Console.WriteLine("0. Bonifico");
            Console.WriteLine("1. Carta di Credito");
            Console.WriteLine("2. PayPal");

            int sceltaTipo;
            while (!int.TryParse(Console.ReadLine(), out sceltaTipo) || sceltaTipo < 0 || sceltaTipo > 2)
            {
                Console.WriteLine("Scelta non valida. Inserisci 0, 1 o 2:");
            }

            var tipoPagamento = (PagamentoFactory.TipoPagamento)sceltaTipo; // Converte l'intero in enum
            IPagamento pagamento = factory.CreaPagamento(tipoPagamento); // Crea l'oggetto di pagamento basato sul tipo scelto

            Console.Write($"Inserisci importo da pagare con {pagamento.TipoPagamento}: "); // Chiede all'utente di inserire l'importo
            decimal importo;
            while (!decimal.TryParse(Console.ReadLine(), out importo) || importo <= 0) // Verifica che l'importo sia valido
            {
                Console.WriteLine("Importo non valido. Inserisci un numero maggiore di 0:");
            }

            Console.WriteLine($"Applicare sconto del 10%? (s/n)");
            string risposta = Console.ReadLine()?.ToLower();
            IDiscountPolicy discount = (risposta == "s") ? new DieciPercentoSconto() : new NessunoSconto(); // Se l'utente sceglie s, applica sconto del 10%, altrimenti nessuno

            var service = new ProcessaPagamento(pagamento, discount, logger); // Crea il servizio di processamento di pagamento

            service.OnPagamentoCompletato += (id, totale) =>
                Console.WriteLine($"[EVENTO] Invio email conferma pagamento {id}, totale: {totale:C}"); // Gestore dell'evento PagamentoCompletato che invia una conferma di pagamento via email
            service.OnPagamentoCompletato += (id, totale) =>
                Console.WriteLine($"[EVENTO] pagamento {id}, totale: {totale}"); // Gestore dell'evento PagamentoCompletato che registra il pagamento nel sistema

            int pagamentoId = 1;
            service.EseguiPagamento(pagamentoId.ToString(), importo);
        }
    }
    #endregion
}