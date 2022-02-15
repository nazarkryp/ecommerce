using System;

namespace eCommerce.Payments.WayForPay.Cryptography
{
    public class PaymentStatus
    {
        public string MerchantAccount { get; set; }

        public string Reason { get; set; }

        public int ReasonCode { get; set; }

        public string OrderReference { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string AuthCode { get; set; }

        public Int64 CreatedDate { get; set; }

        public Int64 ProcessingDate { get; set; }

        public string CardPan { get; set; }

        public string CardType { get; set; }

        public string IssuerBankCountry { get; set; }

        public string IssuerBankName { get; set; }

        public string TransactionStatus { get; set; }

        public decimal RefundAmount { get; set; }

        public string SettlementDate { get; set; }

        public decimal SettlementAmount { get; set; }

        public decimal Fee { get; set; }

        public string MerchantSignature { get; set; }

    }
}
