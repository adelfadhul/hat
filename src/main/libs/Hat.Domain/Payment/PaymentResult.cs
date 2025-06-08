using Hat.Domain.Enums;

namespace Hat.Domain.Payment
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public PaymentStatus Status { get; set; }           // e.g. "SUCCESS", "FAILED", "PENDING"
        public string TransactionId { get; set; }    // From the gateway
        public string Reference { get; set; }        // Your internal reference
        public decimal Amount { get; set; }
        public string Currency { get; set; }         // e.g. "BHD", "USD"
        public string Message { get; set; }          // Friendly message or error
        public string ReceiptUrl { get; set; }       // Optional
    }
}
