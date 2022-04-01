namespace eCommerce.Request.Dtos.Payments
{
    public class CreatePaymentRequest
    {
        public string OrderId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
