using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using eCommerce.Payments.WayForPay.Exceptions;

namespace eCommerce.Payments.WayForPay.Handlers
{
    internal class WayForPayErrorHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            var content = await response.Content.ReadAsStringAsync();

            var document = JsonDocument.Parse(content);
            var reasonCode = document.RootElement.GetProperty("reasonCode").GetInt32();

            switch (reasonCode)
            {
                case 1127:
                    throw new TransactionNotFoundException();
            }

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
