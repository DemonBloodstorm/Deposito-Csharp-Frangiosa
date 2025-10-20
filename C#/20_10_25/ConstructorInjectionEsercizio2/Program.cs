using System;

public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public class PayPalGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"processo di pagamento di {amount} tramite PayPal");
    }
}
public class StripeGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"processo di pagamento di {amount} tramite Stripe");
    }
}

public class PaymentProcessor : IPaymentGateway
{
    private readonly IPaymentGateway _paymentGateway;
    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }
    public void ProcessPayment(decimal amount)
    {
        _paymentGateway.ProcessPayment(amount);
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        decimal prezzo = 0;
        string metodo;
        Console.WriteLine($"Qunato devi pagare?");
        prezzo = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Con cosa vuoi pagare?");
        metodo = Console.ReadLine().Trim().ToLower();
        IPaymentGateway gateway = metodo switch
        {
            "paypal" => new PayPalGateway(),
            "stripe" => new StripeGateway(),
            _ => new PayPalGateway() // default
        };
        var processor = new PaymentProcessor(gateway);
        processor.ProcessPayment(prezzo);
    }
}