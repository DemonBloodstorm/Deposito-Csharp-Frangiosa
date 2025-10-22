using System;
using System.Collections.Generic;
using EsercizioN_Tier.Domain;

namespace EsercizioN_Tier.Infrastructure
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public void Add(Order order) => _orders.Add(order);
        public Order? GetById(int id) => _orders.Find(o => o.Id == id);
        public IEnumerable<Order> GetAll() => _orders;

        public void Update(Order order)
        {
            var existing = GetById(order.Id);
            if (existing != null)
                existing.ChangeStatus(order.Status);
        }
    }

    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new();

        public void Add(Customer customer) => _customers.Add(customer);
        public Customer? GetById(int id) => _customers.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Customer> GetAll() => _customers;
    }

    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();
        public void Add(Product product) => _products.Add(product);
        public Product? GetById(int id) => _products.Find(p => p.Id == id);
        public IEnumerable<Product> GetAll() => _products;

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }
    }

    public class Notifica : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"[NOTIFICA] {message}");
        }
    }
}
