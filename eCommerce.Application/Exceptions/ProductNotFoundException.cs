using System;

namespace eCommerce.Application.Exceptions
{
    [Serializable]
    internal class ProductNotFoundException : ResourceNotFoundException
    {
        public ProductNotFoundException(Guid productId)
        : base("Product not found")
        {
            ProductId = productId;
        }

        public Guid ProductId { get; set; }
    }
}
