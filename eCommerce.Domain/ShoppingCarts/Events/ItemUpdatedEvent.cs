using System;

using eCommerce.Domain.Common;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    public class ItemUpdatedEvent : Event
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }
    }
}
