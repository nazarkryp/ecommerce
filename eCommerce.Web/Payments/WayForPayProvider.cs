using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eCommerce.Web.Payments
{
    public class WayForPayProvider
    {
        private readonly string _baseAddress = "https://api.wayforpay.com/api";

        public async Task ProcessPaymentAsync(object payment)
        {
            var body = new
            {

            };

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                _baseAddress,
                new StringContent(JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    "application/json"));
        }

        public async Task<object> GetPaymentAsync(string orderReference)
        {
            string input = $"test_merch_n1;{orderReference}";
            var keyBytes = Encoding.UTF8.GetBytes("flk3409refn54t54t*FNJRET");
            var data = Encoding.UTF8.GetBytes(input);
            var hmac = new HMACMD5(keyBytes);
            var hash = hmac.ComputeHash(data);
            var hashString = System.BitConverter.ToString(hash).Replace("-", "").ToLower();

            var body = new
            {
                transactionType = "CHECK_STATUS",
                merchantAccount = "test_merch_n1",
                orderReference = orderReference,
                merchantSignature = hashString,
                apiVersion = 1
            };

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(
                _baseAddress,
                new StringContent(JsonSerializer.Serialize(body),
                    Encoding.UTF8,
                    "application/json"));

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
