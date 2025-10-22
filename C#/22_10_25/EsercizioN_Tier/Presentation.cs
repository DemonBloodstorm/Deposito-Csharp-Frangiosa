using System;
using System.Collections.Generic;
using EsercizioN_Tier.Application;
using EsercizioN_Tier.CrossCutting;
using EsercizioN_Tier.Domain;

namespace EsercizioN_Tier.Presentation
{
    public class ConsoleApp // Presentation Layer
    {
        private readonly ProductService _productService;
        private readonly OrderService _orderService;

        public ConsoleApp()
        {
            _productService = ServicesContainer.Instance.ProductService;
            _orderService = ServicesContainer.Instance.OrderService;
        }

        public void Run() // Esegue il programma
        {
            while (true)
            {
                Menu();
                int choice = ReadMenuChoice();
                ProcessMenuChoice(choice);
                Console.WriteLine();
            }
        }

        private void Menu() // Mostra il menu principale
        {
            Console.WriteLine("  MENU PRINCIPALE ");
            Console.WriteLine("1. Crea ordine");
            Console.WriteLine("2. Aggiungi prodotto");
            Console.WriteLine("3. Lista ordini");
            Console.WriteLine("4. Cambia stato ordine");
            Console.WriteLine("5. Esci");
        }

        private int ReadMenuChoice() // Legge la scelta dell'utente dal menu
        {
            Console.Write("Scelta: ");
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : 0;
        }

        private void ProcessMenuChoice(int choice) // Processa la scelta dell'utente
        {
            switch (choice)
            {
                case 1: // Crea ordine
                    Console.Write("ID Cliente: ");
                    int customerId = int.TryParse(Console.ReadLine(), out int cid) ? cid : 0; // Legge l'ID del cliente
                    var existingCustomer = ServicesContainer.Instance.CustomerRepository.GetById(customerId); // Recupera il cliente dal repository altrimenti
                    Customer customer; // Crea un nuovo cliente se non esiste

                    if (existingCustomer == null)
                    {
                        Console.Write("Cliente non trovato. Inserisci il nome: ");
                        string customerName = Console.ReadLine() ?? "";
                        Console.Write("Email: ");
                        string email = Console.ReadLine() ?? "";

                        ServicesContainer.Instance.CustomerService.AddCustomer(customerName, email); // Aggiunge il nuovo cliente al repository

                        Customer? lastCustomer = null; // Se il cliente è nuovo, recupera l'ultimo cliente aggiunto al repository
                        foreach (var c in ServicesContainer.Instance.CustomerRepository.GetAll())
                        {
                            lastCustomer = c; // Recupera l'ultimo cliente aggiunto al repository
                        }
                        customer = lastCustomer!; // In questo caso, l'ultimo cliente aggiunto al repository è il nuovo cliente, 
                                                  // il ! serve per dire al programma che questa assegnazione è sicuramente non nulla
                        Console.WriteLine($"Cliente creato con ID {customer.Id}");
                        
                    }
                    else
                    {
                        customer = existingCustomer;
                        Console.WriteLine($"Cliente trovato: {customer.Name}"); 
                    }

                    var items = new List<(int productId, int quantity)>();
                    foreach (var item in _productService.GetAllProducts())
                    {
                        Console.WriteLine($"id: {item.Id} {item.Name} {item.Price}");
                    }
                    Console.WriteLine("Inserisci i prodotti (id quantità), vuoto per terminare:");
                    while (true)
                    {
                        var input = Console.ReadLine();
                        if (string.IsNullOrEmpty(input)) break;

                        var parts = input.Split(' ');
                        if (parts.Length != 2 ||
                            !int.TryParse(parts[0], out int pid) ||
                            !int.TryParse(parts[1], out int q))
                        {
                            Console.WriteLine("Formato non valido. Usa: id quantità");
                            continue;
                        }
                        items.Add((pid, q));
                    }

                    if (items.Count == 0)
                    {
                        Console.WriteLine("Errore: devi inserire almeno un prodotto per creare l'ordine.");
                        break;
                    }

                    _orderService.CreateOrder(customer.Id, items);
                    Console.WriteLine("Ordine creato con successo!");
                    break;

                case 2:
                    Console.Write("Nome prodotto: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("Prezzo: ");
                    decimal price = decimal.TryParse(Console.ReadLine(), out decimal p) ? p : 0;
                    _productService.AddProduct(name, price);
                    Console.WriteLine("Prodotto aggiunto con successo.");
                    break;

                case 3:
                    Console.WriteLine("Lista ordini:");
                    foreach (var order in _orderService.GetAllOrders())
                    {
                        Console.WriteLine($"Ordine {order.Id}, Cliente {order.Customer.Name}, Stato {order.Status}, Totale {order.Totale.Value} {order.Totale.Currency}");
                    }
                    break;

                case 4:
                    Console.Write("ID ordine: ");
                    int orderId = int.TryParse(Console.ReadLine(), out int oid) ? oid : 0;
                    Console.WriteLine($"Stato attuale: {_orderService.GetOrderStatus(orderId)}");
                    Console.Write("Stato desiderato (1=Paid, 2=Shipped, 3=Cancelled): ");
                    int s = int.TryParse(Console.ReadLine(), out int sc) ? sc : 0;

                    var newStatus = s switch
                    {
                        1 => OrderStatus.Paid,
                        2 => OrderStatus.Shipped,
                        3 => OrderStatus.Cancelled,
                        _ => OrderStatus.New
                    };

                    try
                    {
                        _orderService.ChangeOrderStatus(orderId, newStatus);
                        Console.WriteLine("Stato ordine aggiornato!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Errore: {ex.Message}");
                    }
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
