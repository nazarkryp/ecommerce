using System;

using eCommerce.Domain.Products;

namespace eCommerce.Domain.ShoppingCarts
{
    public class ShoppingCartItem
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
