using System;

using eCommerce.Payments.WayForPay.Configuration;
using eCommerce.Payments.WayForPay.Cryptography;

using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Payments.WayForPay
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWayForPayClient(this IServiceCollection services)
        {
            services.Configure<WayForPayConfiguration>(options =>
            {
                options.MerchantAccount = "test_merch_n1";
                options.Currency = "UAH";
                options.Language = "UA";
                options.MerchantDomainName = "https://example.com";
                options.MerchantSecret = "flk3409refn54t54t*FNJRET";
                options.AuthorizationType = "SimpleSignature";
            });

            services.AddHttpClient<WayForPay>(options =>
            {
                options.BaseAddress = new Uri("https://api.wayforpay.com/api");
            });

            services.AddSingleton<SignatureProvider>();

            return services;
        }
    }
}
