using System;

namespace eCommerce.Application.Exceptions
{
    [Serializable]
    internal class OrderNotFoundException : ResourceNotFoundException
    {
        public OrderNotFoundException(string orderId)
            : base("Order not found")
        {
            OrderId = orderId;
        }

        public string OrderId { get; set; }
    }
}
