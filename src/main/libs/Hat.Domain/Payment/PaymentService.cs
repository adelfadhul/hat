namespace Hat.Domain.Payment
{
    public interface IPaymentService
    {
        Task<PaymentResult> ProcessPaymentAsync(decimal amount, string currency, string reference);
    }
}
