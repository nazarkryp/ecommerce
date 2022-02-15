using System;

namespace eCommerce.Request.Dtos.ShoppingCarts
{
    public class ShoppingCartResponse
    {
        public Guid Id { get; set; }

        public ShoppingCartItem[] Items { get; set; }
    }
}
