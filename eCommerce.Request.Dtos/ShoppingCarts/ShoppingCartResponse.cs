using System;
using System.Linq;

namespace eCommerce.Request.Dtos.ShoppingCarts
{
    public class ShoppingCartResponse
    {
        public Guid Id { get; set; }

        public ShoppingCartItemResponse[] Items { get; set; }

        public ShoppingCartSummary Summary => new ShoppingCartSummary
        {
            Total = Items.Sum(e => e.Product.Price)
        };
    }

    public class ShoppingCartSummary
    {
        public decimal Total { get; set; }
    }
}
