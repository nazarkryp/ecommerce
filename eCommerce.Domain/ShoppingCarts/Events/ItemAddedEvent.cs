using System;

using eCommerce.Domain.Common;
using eCommerce.Domain.Products;

namespace eCommerce.Domain.ShoppingCarts.Events
{
    internal class ItemAddedEvent : Event
    {
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
