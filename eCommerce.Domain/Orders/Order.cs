using System;

namespace eCommerce.Domain.Orders
{
    public class Order
    {
        public string OrderId { get; set; }

        public Guid ShoppingCartId { get; set; }

        public OrderState State { get; set; }
    }

    public enum OrderState : byte
    {
        Open,
        InProgress,
        Completed,
        Cancelled
    }
}
