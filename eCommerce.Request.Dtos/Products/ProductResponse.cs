using System;

namespace eCommerce.Request.Dtos.Products
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUri { get; set; }
    }
}
