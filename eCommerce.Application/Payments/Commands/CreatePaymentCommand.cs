using eCommerce.Request.Dtos.Payments;

using MediatR;

namespace eCommerce.Application.Payments.Commands
{
    public class CreatePaymentCommand : IRequest<CreatePaymentResult>
    {
        private CreatePaymentCommand(string orderId)
        {
            OrderId = orderId;
        }

        public string OrderId { get;  }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; } // 380685293558

        public static CreatePaymentCommand Create(string orderId)
        {
            return new CreatePaymentCommand(orderId);
        }
    }
}
