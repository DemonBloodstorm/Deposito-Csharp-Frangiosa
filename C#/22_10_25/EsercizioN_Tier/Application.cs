using System;
using System.Collections.Generic;
using EsercizioN_Tier.Domain;

namespace EsercizioN_Tier.Application
{
    public class OrderService // Application Service
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly INotificationService _notificationService;

        public OrderService(IOrderRepository orderRepository,
                            IProductRepository productRepository,
                            INotificationService notificationService)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _notificationService = notificationService;
        }

        public void CreateOrder(int customerId, List<(int productId, int quantity)> items)
        {
            var customer = new Customer($"Cliente {customerId}", $"cliente{customerId}@example.com");
            var order = new Order(customer);

            foreach (var (productId, quantity) in items)
            {
                var product = _productRepository.GetById(productId)
                    ?? throw new Exception($"Prodotto con ID {productId} non trovato.");
                order.AddItem(product, quantity);
            }

            _orderRepository.Add(order);
            _notificationService.Notify($"Ordine {order.Id} creato per cliente {customer.Id}");
        }

        public void ChangeOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = _orderRepository.GetById(orderId)
                ?? throw new Exception("Ordine non trovato.");

            order.ChangeStatus(newStatus);
            _orderRepository.Update(order);

            _notificationService.Notify($"Stato dell'ordine {order.Id} cambiato in {newStatus}");
        }

        public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAll();

        public OrderStatus GetOrderStatus(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order == null)
                Console.WriteLine($"Ordine con ID {orderId} non trovato.");

            return order.Status; // qui accedi alla proprietà del Domain
        }

    }

    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(string name, decimal price)
        {
            var product = new Product(name, price);
            _productRepository.Add(product);
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();
    }

    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(string name, string email)
        {
            var customer = new Customer(name, email);
            _customerRepository.Add(customer);
        }

        public Customer? GetCustomerById(int id) => _customerRepository.GetById(id);

        public IEnumerable<Customer> GetAllCustomers() => _customerRepository.GetAll();
    }


}