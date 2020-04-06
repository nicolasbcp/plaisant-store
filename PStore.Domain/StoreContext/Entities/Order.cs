using System;
using System.Collections.Generic;
using System.Linq;
using PStore.Domain.StoreContext.Enums;

namespace PStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem item)
        {
            // Valida o item
            // Adiciona ao item
            _items.Add(item);
        }
        
        public void AddDelivery(Delivery delivery)
        {
            // Valida a entrega
            // Adiciona entrega
            _deliveries.Add(delivery);
        }

        // To place an order
        public void Place()
        {

        }
    }
}