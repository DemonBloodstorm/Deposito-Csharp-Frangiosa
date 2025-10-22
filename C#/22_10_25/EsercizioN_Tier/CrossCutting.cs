using EsercizioN_Tier.Application;
using EsercizioN_Tier.Domain;
using EsercizioN_Tier.Infrastructure;

namespace EsercizioN_Tier.CrossCutting
{
    public sealed class ServicesContainer
    {
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public INotificationService NotificationService { get; }
        
        public ProductService ProductService { get; }
        public OrderService OrderService { get; }
        public ICustomerRepository CustomerRepository { get; }
        public CustomerService CustomerService { get; }

        public static readonly ServicesContainer Instance = new();

        private ServicesContainer()
        {
            CustomerRepository = new InMemoryCustomerRepository();
            ProductRepository = new InMemoryProductRepository();
            OrderRepository = new InMemoryOrderRepository();
            NotificationService = new Notifica();

            CustomerService = new CustomerService(CustomerRepository);
            ProductService = new ProductService(ProductRepository);
            OrderService = new OrderService(OrderRepository, ProductRepository, NotificationService);
        
        }
    }
}