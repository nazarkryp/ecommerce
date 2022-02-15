namespace eCommerce.Request.Dtos.Payments
{
    public class CreatePaymentResult
    {
        public string MerchantAccount { get; set; }

        public string MerchantDomainName { get; set; }

        public string AuthorizationType { get; set; }

        public string MerchantSignature { get; set; }

        public string OrderReference { get; set; }

        public string OrderDate { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public string ProductCount { get; set; }

        public string ClientFirstName { get; set; }

        public string ClientLastName { get; set; }

        public string ClientEmail { get; set; }

        public string ClientPhone { get; set; }

        public string Language { get; set; }
    }
}
