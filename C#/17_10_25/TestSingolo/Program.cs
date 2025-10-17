using System;
using System.Collections.Generic;

#region Singleton

public sealed class AppContext : IObserver // non sono riuscito a implementare l'observer in AppContext
{
    public String Valuta{get; private set;}
    public int Iva{get; private set;}
    public int Sconto{get; private set;}
    private AppContext(String Valuta, int Iva, int Sconto)
    {
        this.Valuta = Valuta;
        this.Iva = Iva;
        this.Sconto = Sconto;
    }
    private static AppContext _instance;
    private static readonly object _lock = new object();
    public static AppContext GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AppContext("Euro", 22, 10);
                }
            }
        }
        return _instance;
    }
}

#endregion Singleton

#region Factory Method

public abstract class Product
{
    public string productCode {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    public virtual string Description {get;}
    public virtual decimal GetPrice() => Price;
} 

public class TShirt : Product
{
    public string size {get; set;}
    public TShirt()
    {
        productCode = "TSHIRT";
        Name = "T-Shirt";
        size = "M";
        Price = 19.99m;
    }
    public override string Description => $"{Name} {size} at {Price} ";
    public override decimal GetPrice() => Price;
}
public class Mug : Product
{
    public Mug()
    {
        productCode = "MUG";
        Name = "Mug";
        Price = 9.99m;
    }
    public override string Description => $"{Name} at {Price} ";
    public override decimal GetPrice() => Price;
}
public class Skin : Product
{
    public Skin()
    {
        productCode = "SKIN";
        Name = "Skin";
        Price = 14.99m;
    }
    public virtual string Description => $"{Name} at {Price}";
    public virtual decimal GetPrice() => Price;
}


public class ProductFactory
{
    public static Product Create()
    {
        switch (productCode)
        {
            case "TSHIRT": return new TShirt();
            case "MUG": return new Mug();
            case "SKIN": return new Skin();
            default: throw new ArgumentException("Invalid product code");
        }
    }
}
#endregion Factory Method

#region Decorator

public abstract class Addon : Product
{
    protected Product _inner;
    protected Addon(Product inner) { _inner = inner; }
    public override string Description => _inner.Description;
    public override decimal GetPrice() => _inner.GetPrice();
}


public class ConfezzioneRegalo : Addon
{
    public ConfezzioneRegalo(Product inner) : base(inner) { Name = inner.Name + " + Confezzione Regalo"; }
    public override string Description => _inner.Description + " [Confezzione Regalo]";
    public override decimal GetPrice() => _inner.GetPrice() + 3.5m;
}

#endregion Decorator

#region Strategy

public interface IPricingStrategy
{
    decimal CalcolaPrezzo(Order order);
    string Name { get; }
}

public class StandardPricing : IPricingStrategy
{
    public string Name => "StandardPricing";

    public decimal CalcolaPrezzo(Order order)
    {
        var ctx = AppContext.GetInstance();
        decimal subtotal = 0;

        foreach (var item in order.Items)
        {
            subtotal += item.Product.GetPrice() * item.Quantity;
        }

        decimal discount = ctx.Sconto / 100m;
        decimal tax = ctx.Iva / 100m;

        decimal finalPrice = (subtotal - (subtotal * discount)) * (1 + tax);
        return finalPrice;
    }
}

#endregion Strategy

#region Observer

public interface IObserver
{
    void Update(AppContext context);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

public class Order : IObserver
{
    public List<OrderItem> Items { get; } = new List<OrderItem>();
    public decimal LastCalculatedTotal { get; private set; }

    public void Update(AppContext context)
    {
        Console.WriteLine($"  Order notified: IVA = {context.Iva}%, Sconto = {context.Sconto}%");
        IPricingStrategy strategy = new StandardPricing();
        LastCalculatedTotal = strategy.CalcolaPrezzo(this);
        Console.WriteLine($"New total (auto recalculated): {LastCalculatedTotal:F2} {context.Valuta}");
    }
}


#endregion observer
