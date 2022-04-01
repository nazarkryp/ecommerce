using System;

namespace eCommerce.Request.Dtos.Orders
{
    public class OrderResponse
    {
        public string OrderId { get; set; }

        public Guid ShoppingCartId { get; set; }

        public int State { get; set; }
    }
}
