using System;

namespace eCommerce.Application.Exceptions
{
    [Serializable]
    internal class ShoppingCartNotFoundException : ResourceNotFoundException
    {
        public ShoppingCartNotFoundException(Guid shoppingCartId)
            : base("ShoppingCart not found")
        {
            ShoppingCartId = shoppingCartId;
        }

        public Guid ShoppingCartId { get; set; }
    }
}
