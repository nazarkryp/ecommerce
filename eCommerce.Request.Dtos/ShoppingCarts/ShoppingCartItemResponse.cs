using System;

using eCommerce.Request.Dtos.Products;

namespace eCommerce.Request.Dtos.ShoppingCarts
{
    public class ShoppingCartItemResponse
    {
        public Guid Id { get; set; }

        public ProductResponse Product { get; set; }

        public int Quantity { get; set; }
    }
}
