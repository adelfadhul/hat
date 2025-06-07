namespace Hat.Domain.Enums
{
    public enum OrderStatus
    {
        Draft = 0,             // Cart just submitted, not yet processed
        PendingPayment = 1,    // Order created, waiting for payment
        Paid = 2,              // Payment successful
        FailedPayment = 3,     // Payment failed
        Cancelled = 4,         // User or system cancelled the order
        Refunded = 5,          // Payment refunded after being paid
        Processing = 6,        // Order is being processed (e.g., packed)
        Shipped = 7,           // Order shipped (if applicable)
        Completed = 8          // Fully delivered or completed
    }
}
