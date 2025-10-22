using System;
using System.Collections.Generic;

namespace EsercizioN_Tier.Domain
{
    #region Interfacce
    public interface IOrderRepository
    {
        void Add(Order order);
        Order? GetById(int id);
        IEnumerable<Order> GetAll();
        void Update(Order order);
    }

    public interface ICustomerRepository
    {
        void Add(Customer customer);
        Customer? GetById(int id);
        IEnumerable<Customer> GetAll();
    }

    public interface IProductRepository
    {
        void Add(Product product);
        Product? GetById(int id);
        IEnumerable<Product> GetAll();
        void Update(Product product);
    }

    public interface INotificationService
    {
        void Notify(string message);
    }
    #endregion

    #region Entità
    public class Product
    {
        private static int _nextId = 1;
        public int Id { get; private set; } = _nextId++;
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Customer
    {
        private static int _nextId = 1;
        public int Id { get; private set; } = _nextId++;
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    public class Order
    {
        private static int _nextId = 1;
        public int Id { get; private set; } = _nextId++;
        public Customer Customer { get; }
        private readonly List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
        public OrderStatus Status { get; private set; } = OrderStatus.New;
        public DateTime CreatedAt { get; } = DateTime.Now;
        public Money Totale { get; private set; } = new(0, "EUR");
        public OrderStatus GetStatus() => Status;

        public Order(Customer customer)
        {
            Customer = customer;
        }
        

        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem
            {
                ProductId = product.Id,
                UnitPrice = product.Price,
                Quantity = quantity,
                Price = new Money(product.Price * quantity, "EUR")
            };
            _items.Add(item);
            CalcolaTotale();
        }

        public void CalcolaTotale()
        {
            decimal somma = 0;
            foreach (var i in Items)
                somma += i.UnitPrice * i.Quantity;

            Totale = new Money(somma, "EUR");
        }
        

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (Status == newStatus)
            {
                return;
            }

            if (Status == OrderStatus.New &&
                (newStatus == OrderStatus.Paid || newStatus == OrderStatus.Shipped || newStatus == OrderStatus.Cancelled))
            {
                Status = newStatus;
            }
            else if (Status == OrderStatus.Paid &&
                    (newStatus == OrderStatus.Shipped || newStatus == OrderStatus.Cancelled))
            {
                Status = newStatus;
            }
            else
            {
                throw new InvalidOperationException($"Transizione da {Status} a {newStatus} non valida.");
            }
        }
    }

    public class OrderItem
    {
        private static int _nextId = 1;
        public int Id { get; private set; } = _nextId++;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Money Price { get; set; }
    }

    public class Money
    {
        public decimal Value { get; }
        public string Currency { get; }

        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }

    public enum OrderStatus
    {
        New,
        Paid,
        Shipped,
        Cancelled
    }
    #endregion
}
