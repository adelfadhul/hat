using Hat.Domain.Payment;

namespace Hat.Infrastructure.Payment.Fake
{
    public class FakePaymentService : IPaymentService
    {
        public async Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string reference)
        {
            // Simulate delay to mimic real network/API call
            await Task.Delay(1000);

            // Simulate a fake successful payment
            return new PaymentResult
            {
                IsSuccess = true,
                Status = "SUCCESS",
                TransactionId = Guid.NewGuid().ToString(),
                Reference = reference,
                Amount = amount,
                Currency = currency,
                Message = "Payment processed successfully (FAKE)",
                ReceiptUrl = $"https://fake-payments.local/receipts/{reference}"
            };
        }
    }
}
