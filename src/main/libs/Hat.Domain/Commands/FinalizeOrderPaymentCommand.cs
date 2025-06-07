using Hat.Domain.Payment;
using MediatR;

namespace Hat.Domain.Commands
{
    public class FinalizeOrderPaymentCommand:IRequest
    {
        public Guid OrderId { get; set; }
        public PaymentResult PaymentResult { get; set; }
        public FinalizeOrderPaymentCommand(Guid orderId, PaymentResult paymentResult)
        {
            OrderId = orderId;
            PaymentResult = paymentResult ?? throw new ArgumentNullException(nameof(paymentResult), "Payment result cannot be null");
        }
    }


}
