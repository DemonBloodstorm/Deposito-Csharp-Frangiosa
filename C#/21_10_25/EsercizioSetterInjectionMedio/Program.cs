using System;

#region Interfacce IInventoryService, IPaymentProcessor
public interface IInventoryService // Interfaccia per il servizio del inventario
{
    void Stock(string[] item);
}
#endregion Interfacce IInventoryService, IPaymentProcessor

#region Implemntazione delle interfacce IInventoryService, IPaymentProcessor
public interface IPaymentProcessor // Interfaccia per il servizio di pagamento
{
    void Process(decimal amount);
}
public class PaymentProcessor : IPaymentProcessor // Implementazione del servizio di pagamento
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processo pagamento di {amount}"); // Processa il pagamento
    }
}

public class InventoryService : IInventoryService // Implementazione del servizio del inventario
{
    public void Stock(string[] item)
    {
        Console.WriteLine($"In inventario c'è: {string.Join(", ", item)}"); // Aggiunge gli item all'inventario
    }
}
#endregion Implemntazione delle interfacce IInventoryService, IPaymentProcessor

#region Interfaccia INotificationSender con implemetazione EmailNotificationSender
public interface INotificationSender // Interfaccia per il servizio di notifica
{
    void Send(string message);
}
public class EmailNotificationSender : INotificationSender // Implementazione del servizio di notifica per email
{
    public void Send(string message)
    {
        Console.WriteLine($"Invio email: {message}");
    }
}
#endregion 

#region Interfaccia IPricingStrategy con implementazione PricingStrategy
public interface IPricingStrategy // Interfaccia per il servizio di calcolo del prezzo
{
    public decimal CalculatePrice(int quantity, decimal unitPrice); // Calcola il prezzo totale
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount); // Calcola il prezzo scontato
}

public class PricingStrategy : IPricingStrategy // Implementazione del servizio di calcolo del prezzo
{
    public decimal CalculatePrice(int quantity, decimal unitPrice)
        => quantity * unitPrice; // Calcola il prezzo totale
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount)
        => CalculatePrice(quantity, unitPrice) * (1 - discount); // Calcola il prezzo scontato
}
#endregion

#region Classe OrderService
public class OrderService // Classe per il servizio di ordinazione
{
    private IInventoryService _inventoryService; // Servizio del inventario
    private IPaymentProcessor _paymentProcessor; // Servizio di pagamento
    public IPricingStrategy _pricingStrategy { get; set; } // Servizio di calcolo del prezzo
    public INotificationSender _notificationSender { get; set; } // Servizio di notifica
    public void SetInventoryService(IInventoryService inventoryService)  // Imposta il servizio del inventario
    {
        _inventoryService = inventoryService;
    }
    public void SetPaymentProcessor(IPaymentProcessor paymentProcessor) // Imposta il servizio di pagamento
    {
        _paymentProcessor = paymentProcessor;
    }
    public void PlaceOrder(string item, decimal amount) // PlaceOrder ordina l'item e processa il pagamento
    {
        _inventoryService.Stock(new string[] { item }); // Aggiunge l'item all'inventario
        _paymentProcessor.Process(amount); // Processa il pagamento
    }
    public void NotifyOrder(string item, decimal amount) // Notifica l'ordine
    {
        _notificationSender.Send($"Ordine per {item} a {amount}"); // Invia la notifica
    }
    public decimal CalculatePrice(int quantity, decimal unitPrice) // Calcola il prezzo totale
    {
        return _pricingStrategy.CalculatePrice(quantity, unitPrice);
    }
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount) // Calcola il prezzo scontato
    {
        return _pricingStrategy.DiscountPrice(quantity, unitPrice, discount);
    }
}
#endregion Classe OrderService

#region ProductFactory

public interface IProduct // Interfaccia per il prodotto
{
    string Name { get; }
    decimal Price { get; }
    void DisplayInfo();
}

public class Book_Digital : IProduct // Implementazione del prodotto nella versione digitale
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public void DisplayInfo()
        => Console.WriteLine($"Il libro digitale {Name} costa {Price}");
}

public class Book_Print : IProduct // Implementazione del prodotto nella versione stampata
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public void DisplayInfo()
        => Console.WriteLine($"Il libro stampato {Name} costa {Price}");
}

public class ProductFactory // Factory per la creazione dei prodotti
{
    public static ProductFactory Instance { get; set; }
    static ProductFactory() // Costruttore statico per inizializzare l'istanza della factory
    {
        Instance = new ProductFactory();
    }
    public IProduct CreateProduct(string type, string name, decimal price) // Crea un prodotto basato sul tipo specificato
    {
        switch (type)
        {
            case "Digital": // Se il tipo è digitale
                return new Book_Digital { Name = name, Price = price }; // Crea un libro digitale
            case "Print": // Se il tipo è stampato
                return new Book_Print { Name = name, Price = price }; // Crea un libro stampato
            default:
                throw new ArgumentException("Tipo prodotto non valido"); // Lancia un'eccezione se il tipo non è valido
        }
    }
}
#endregion ProductFactory

#region Main

public class Program
{
    public static void Main(string[] args)
    {
        var inventoryService = new InventoryService(); // Inizializzazione dell'inventario
        var paymentProcessor = new PaymentProcessor(); // Inizializzazione del servizio di pagamento
        var pricingStrategy = new PricingStrategy(); // Inizializzazione della strategia di prezzo
        var notificationSender = new EmailNotificationSender(); // Inizializzazione del servizio di notifica

        var orderService = new OrderService(); // Inizializzazione del servizio di ordine
        orderService.SetInventoryService(inventoryService); // Iniezione dell'inventario
        orderService.SetPaymentProcessor(paymentProcessor); // Iniezione del servizio di pagamento
        orderService._pricingStrategy = pricingStrategy; // Iniezione della strategia di prezzo
        orderService._notificationSender = notificationSender; // Iniezione del servizio di notifica

        var bookDigital = ProductFactory.Instance.CreateProduct("Digital", "C# 10 in a Nutshell", 50); // Creazione del libro digitale
        var bookPrint = ProductFactory.Instance.CreateProduct("Print", "C# 10 in a Nutshell", 100); // Creazione del libro stampato

        bookDigital.DisplayInfo(); // Stampa le informazioni del libro digitale
        bookPrint.DisplayInfo(); // Stampa le informazioni del libro stampato

        decimal digitalPrice = bookDigital.Price; // Prezzo del libro digitale
        decimal printPrice = bookPrint.Price; // Prezzo del libro stampato

        orderService.PlaceOrder(bookDigital.Name, digitalPrice); // Acquisto del libro digitale
        orderService.NotifyOrder(bookDigital.Name, digitalPrice); // Notifica dell'acquisto del libro digitale

        decimal discountedPrice = orderService.DiscountPrice(1, printPrice, 0.1m);  // Prezzo scontato del libro stampato
        orderService.PlaceOrder(bookPrint.Name, discountedPrice); // Acquisto del libro stampato
        orderService.NotifyOrder(bookPrint.Name, discountedPrice); // Notifica dell'acquisto del libro stampato

        decimal totalPrice = orderService.CalculatePrice(2, 50); // Prezzo totale per 2 libri digitali
        Console.WriteLine($"\nPrezzo totale per 2 libri digitali: {totalPrice}"); // Stampa il prezzo totale per 2 libri digitali
    }
}
#endregion Main
