using System;
using Orders.ValueObjects;

namespace Orders.Domain
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DeliveryTypeEnum DeliveryType { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public string Comments { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}