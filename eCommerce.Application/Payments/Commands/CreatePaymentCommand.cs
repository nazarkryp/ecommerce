using eCommerce.Request.Dtos.Payments;

using MediatR;

namespace eCommerce.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<CreatePaymentResult>
    {
        private CreatePaymentCommand(string orderId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            OrderId = orderId;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
        }

        public string OrderId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string EmailAddress { get; }

        public string PhoneNumber { get; }

        public static CreatePaymentCommand Create(string orderId, string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            return new CreatePaymentCommand(orderId, firstName, lastName, emailAddress, phoneNumber);
        }
    }
}
