using System;
using System.Collections.Generic;
using System.Linq;

using eCommerce.Domain.Common;
using eCommerce.Domain.Products;
using eCommerce.Domain.ShoppingCarts.Events;

namespace eCommerce.Domain.ShoppingCarts
{
    public class ShoppingCart : AggregateRoot
    {
        private readonly List<ShoppingCartItem> _items = new List<ShoppingCartItem>();

        protected ShoppingCart()
        {
        }

        public Guid Id { get; set; }

        public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

        public void AddItem(Product product)
        {
            var item = _items.FirstOrDefault(e => e.Product.Id == product.Id);

            if (item == null)
            {
                item = new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    Product = product,
                    Quantity = 1
                };

                AddEvent(new ItemAddedEvent
                {
                    Id = item.Id,
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }
            else
            {
                item.Quantity++;
                _items.Add(item);

                AddEvent(new ItemUpdatedEvent
                {
                    Id = item.Id,
                    Quantity = item.Quantity
                });
            }
        }

        public void RemoveItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(e => e.Id == itemId);

            if (item == null)
            {
                throw new Exception($"ShoppingCartItem '{itemId}' not found");
            }

            _items.Remove(item);

            AddEvent(new ItemRemovedEvent
            {
                Id = item.Id
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

        public static ShoppingCart Aggregate(Event[] events)
        {
            var shoppingCart = new ShoppingCart();

            foreach (var @event in events)
            {
                shoppingCart.Apply(@event);
            }

            return shoppingCart;
        }

        public override void When(Event @event)
        {
            if (@event is ShoppingCartCreated created)
            {
                Id = created.Id;
            }
            else if (@event is ItemAddedEvent added)
            {
                _items.Add(new ShoppingCartItem
                {
                    Id = added.Id,
                    Product = added.Product,
                    Quantity = added.Quantity
                });
            }
            else if (@event is ItemUpdatedEvent updated)
            {
                var item = _items.First(e => e.Id == updated.Id);
                item.Quantity = updated.Quantity;
            }
            else if (@event is ItemRemovedEvent removed)
            {
                var item = _items.FirstOrDefault(e => e.Id == removed.Id);
                _items.Remove(item);
            }
        }
    }
}
