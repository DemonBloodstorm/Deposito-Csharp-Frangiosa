using System;

#region Interfacce IInventoryService, IPaymentProcessor
public interface IInventoryService
{
    void Stock(string[] item);
}
#endregion Interfacce IInventoryService, IPaymentProcessor

#region Implemntazione delle interfacce IInventoryService, IPaymentProcessor
public interface IPaymentProcessor
{
    void Process(decimal amount);
}
public class PaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processo pagamento di {amount}");
    }
}

public class InventoryService : IInventoryService
{
    public void Stock(string[] item)
    {
        Console.WriteLine($"In inventario c'è: {string.Join(", ", item)}");
    }
}
#endregion Implemntazione delle interfacce IInventoryService, IPaymentProcessor

#region Interfaccia INotificationSender con implemetazione EmailNotificationSender
public interface INotificationSender
{
    void Send(string message);
}
public class EmailNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"Invio email: {message}");
    }
}
#endregion 

#region Interfaccia IPricingStrategy con implementazione PricingStrategy
public interface IPricingStrategy
{
    public decimal CalculatePrice(int quantity, decimal unitPrice);
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount);
}

public class PricingStrategy : IPricingStrategy
{
    public decimal CalculatePrice(int quantity, decimal unitPrice)
        => quantity * unitPrice;
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount)
    =>  CalculatePrice(quantity, unitPrice) * (1 - discount);
    
}
#endregion

#region Classe OrderService
public class OrderService
{
    private IInventoryService _inventoryService;
    private IPaymentProcessor _paymentProcessor;
    public IPricingStrategy _pricingStrategy { get; set; }
    public INotificationSender _notificationSender { get; set; }
    public void SetInventoryService(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    public void SetPaymentProcessor(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }
    public void PlaceOrder(string item, decimal amount)
    {
        _inventoryService.Stock(new string[] { item });
        _paymentProcessor.Process(amount);
    }
    public void NotifyOrder(string item, decimal amount)
    {
        _notificationSender.Send($"Ordine per {item} a {amount}");
    }
    public decimal CalculatePrice(int quantity, decimal unitPrice)
    {
        return _pricingStrategy.CalculatePrice(quantity, unitPrice);
    }
    public decimal DiscountPrice(int quantity, decimal unitPrice, decimal discount)
    {
        return _pricingStrategy.DiscountPrice(quantity, unitPrice, discount);
    }
}
#endregion Classe OrderService

#region ProductFactory

public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
    void DisplayInfo();
}



#endregion ProductFactory