using System;

namespace eCommerce.Request.Dtos.Orders
{
    public class CreateOrderRequest
    {
        public Guid ShoppingCartId { get; set; }
    }
}
