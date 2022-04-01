using System;

using eCommerce.Domain.Common;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    public class ShoppingCartCreated : Event
    {
        public ShoppingCartCreated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
