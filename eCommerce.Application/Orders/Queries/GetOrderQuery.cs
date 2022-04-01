using eCommerce.Request.Dtos.Orders;

using MediatR;

namespace eCommerce.Application.Orders.Queries
{
    public class GetOrderQuery : IRequest<OrderResponse>
    {
        private GetOrderQuery(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }

        public static GetOrderQuery Create(string orderId)
        {
            return new GetOrderQuery(orderId);
        }
    }
}
