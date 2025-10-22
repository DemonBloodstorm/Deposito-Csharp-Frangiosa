using System;
using System.Collections.Generic;

namespace EsercizioN_Tier
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Order
    {
        public int Id { get; private set; }
        public int CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status;
        public DateTime CreatedAt { get; private set; }
        public Money Total { get; private set; }

        public void CalcolaTotale()
        {
            decimal somma = 0;
            foreach (var item in Items)
                somma += item.UnitPrice * item.Quantity;

            Totale = new Money(somma, "EUR");
        }
    }
    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Money Price { get; private set; }
    }
    public class Money
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }

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

}