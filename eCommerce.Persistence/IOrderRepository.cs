using System;
using System.Threading.Tasks;

using eCommerce.Domain.Orders;

namespace eCommerce.Persistence
{
    public interface IOrderRepository
    {
        Task<Order?> GetOrderAsync(string orderId);

        Task<Order?> GetOrderAsync(Guid shoppingCartId);

        Task SaveOrderAsync(Order order);
    }
}
