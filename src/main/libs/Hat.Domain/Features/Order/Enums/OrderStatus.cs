namespace Hat.Domain.Features.Order.Enums
{
    public enum OrderStatus
    {
        Draft,        // Not submitted yet
        Pending,      // Submitted but not paid
        OnHold,       // Waiting for manual review
        Processing,   // Paid, preparing fulfillment
        Completed,    // Fulfilled and closed
        Cancelled,    // Manually cancelled
        Failed,       // Payment failed
        Refunded      // Money returned
    }
}
