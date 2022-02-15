namespace eCommerce.Payments.WayForPay.Configuration
{
    public class WayForPayConfiguration
    {
        public string MerchantAccount { get; set; }

        public string MerchantSecret { get; set; }

        public string MerchantDomainName { get; set; }

        public string AuthorizationType { get; set; }

        public string Currency { get; set; }

        public string Language { get; set; }
    }
}
