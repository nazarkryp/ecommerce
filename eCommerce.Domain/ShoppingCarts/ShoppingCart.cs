using System;
using System.Collections.Generic;

using eCommerce.Domain.Common;
using eCommerce.Domain.ShoppingCarts.Events;

namespace eCommerce.Domain.ShoppingCarts
{
    public class ShoppingCart : AggregateRoot
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

        private ShoppingCart()
        {
        }

        public Guid Id { get; set; }

        public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

        public void AddItem(ShoppingCartItem item)
        {
            _items.Add(item);

            AddEvent(new ItemAddedEvent
            {
                Item = item
            });
        }

        public void RemoveItem(ShoppingCartItem item)
        {
            _items.Remove(item);

            AddEvent(new ItemRemoved
            {
                Item = item
            });
        }

        public static ShoppingCart Create()
        {
            var shoppingCart = new ShoppingCart
            {
                Id = Guid.NewGuid()
            };

            shoppingCart.AddEvent(new ShoppingCartCreated(shoppingCart.Id));

            return shoppingCart;
        }

        public static ShoppingCart Aggregate(IEvent[] events)
        {
            var shoppingCart = new ShoppingCart();

            foreach (var @event in events)
            {
                shoppingCart.Apply(@event);
            }

            return shoppingCart;
        }

        public override void When(IEvent @event)
        {
            if (@event is ShoppingCartCreated created)
            {
                Id = created.Id;
            }
            else if (@event is ItemAddedEvent added)
            {
                _items.Add(added.Item);
            }
            else if (@event is ItemRemoved removed)
            {
                _items.Remove(removed.Item);
            }
        }
    }
}
