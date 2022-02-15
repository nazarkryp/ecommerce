using System;

using MediatR;

namespace eCommerce.Application.Payments.Queries
{
    public class GetPaymentQuery : IRequest<object>
    {
        private GetPaymentQuery(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get; }

        public static GetPaymentQuery Create(string orderId)
        {
            return new GetPaymentQuery(orderId);
        }
    }
}
