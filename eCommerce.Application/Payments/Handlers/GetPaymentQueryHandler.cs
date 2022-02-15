using System.Threading;
using System.Threading.Tasks;

using eCommerce.Application.Payments.Queries;
using eCommerce.Payments.WayForPay;

using MediatR;

namespace eCommerce.Application.Payments.Handlers
{
    internal class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, object>
    {
        private readonly WayForPay _wayForPay;

        public GetPaymentQueryHandler(WayForPay wayForPay)
        {
            _wayForPay = wayForPay;
        }

        public async Task<object> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {
            var result = await _wayForPay.GetPaymentAsync(request.OrderId);

            return result;
        }
    }
}
