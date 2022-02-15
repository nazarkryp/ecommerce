using System;

namespace eCommerce.Domain.ShoppingCarts
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid ProductId { get; set; }
    }
}
