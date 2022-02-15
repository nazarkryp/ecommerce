using System;
using System.Security.Cryptography;
using System.Text;

using eCommerce.Payments.WayForPay.Configuration;

using Microsoft.Extensions.Options;

namespace eCommerce.Payments.WayForPay.Cryptography
{
    public class SignatureProvider
    {
        private readonly WayForPayConfiguration _configuration;

        public SignatureProvider(IOptions<WayForPayConfiguration> options)
        {
            _configuration = options.Value;
        }

        public string CreateSignature(params string[] parameters)
        {
            string input = string.Join(';', parameters);

            var keyBytes = Encoding.UTF8.GetBytes(_configuration.MerchantSecret);
            var data = Encoding.UTF8.GetBytes(input);

            using var hmac = new HMACMD5(keyBytes);
            var hash = hmac.ComputeHash(data);

            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
