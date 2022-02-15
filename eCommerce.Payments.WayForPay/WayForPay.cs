using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using eCommerce.Payments.WayForPay.Configuration;
using eCommerce.Payments.WayForPay.Cryptography;

using Microsoft.Extensions.Options;

namespace eCommerce.Payments.WayForPay
{
    public class WayForPay
    {
        private readonly HttpClient _httpClient;
        private readonly WayForPayConfiguration _configuration;
        private readonly SignatureProvider _signature;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public WayForPay(HttpClient httpClient, SignatureProvider signature, IOptions<WayForPayConfiguration> options)
        {
            _httpClient = httpClient;
            _signature = signature;
            _configuration = options.Value;
        }

        public async Task<PaymentStatus> GetPaymentAsync(string orderReference)
        {
            var hashString = _signature.CreateSignature(_configuration.MerchantAccount, orderReference.ToString());

            var body = new
            {
                transactionType = TransactionType.Status,
                merchantAccount = _configuration.MerchantAccount,
                orderReference = orderReference,
                merchantSignature = hashString,
                apiVersion = 1
            };

            var response = await _httpClient.PostAsync(string.Empty, new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json"));

            var content = await response.Content.ReadAsStringAsync();

            var status = JsonSerializer.Deserialize<PaymentStatus>(content, _jsonSerializerOptions) ?? throw new ArgumentException();

            return status;
        }
    }
}
