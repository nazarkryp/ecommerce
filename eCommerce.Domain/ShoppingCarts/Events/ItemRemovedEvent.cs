using System;
using eCommerce.Domain.Common;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    internal class ItemRemovedEvent : Event
    {
        public Guid Id { get; set; }
    }
}
