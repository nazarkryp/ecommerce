using System;

namespace eCommerce.Payments.WayForPay.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException()
            : base("Transaction Not Found")
        {
        }
    }
}
