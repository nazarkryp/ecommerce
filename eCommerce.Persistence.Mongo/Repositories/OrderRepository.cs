using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eCommerce.Domain.Orders;

namespace eCommerce.Persistence.Mongo.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new List<Order>();

        public Task<Order> GetOrderAsync(string orderId)
        {
            return Task.FromResult(_orders.FirstOrDefault(e => e.OrderId == orderId));
        }

        public Task<Order> GetOrderAsync(Guid shoppingCartId)
        {
            var order = _orders.LastOrDefault(e => e.ShoppingCartId == shoppingCartId);

            return Task.FromResult(order);
        }

        public Task SaveOrderAsync(Order order)
        {
            var existing = _orders.FirstOrDefault(e => e.OrderId == order.OrderId);

            if (existing == null)
            {
                _orders.Add(order);
            }
            else
            {
                existing.State = order.State;
            }

            return Task.CompletedTask;
        }
    }
}
