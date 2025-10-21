using System;

public interface IInventoryService
{
    void Stock(string[] item);
}
public interface IPaaymentProcessor
{
    void Process(decimal amount);
}
public class InventoryService : IInventoryService
{
    public void Stock(string[] item)
    {
        Console.WriteLine($"In inventario c'è: {string.Join(", ", item)}");
    }
}
public class OrderService
{
    private IInventoryService _inventoryService;
    private IPaymentProcessor _paymentProcessor;
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
}

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
