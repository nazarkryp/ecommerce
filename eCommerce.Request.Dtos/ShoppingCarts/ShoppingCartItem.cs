using System;

namespace eCommerce.Request.Dtos.ShoppingCarts
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
