using Hat.Domain.Enums;

namespace Hat.Domain.Models
{
    public class OrderModel
    {
       
        #region data

        public Guid Id { get; set; }
        public Guid UserId { get; set; } 
        public string Name { get; set; }

        public string Price { get; set; }

        public OrderStatus Status { get; set; }

        public string ImageUrls { get; set; }

        public DateTime OrderDate { get; set; }

        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerId { get; set; } // Assuming this is a string, could be Guid as well
        public string Currency { get; set; } // e.g. "BHD", "USD"
        public string OrderNumber { get; set; } // Unique order number
        public string PaymentStatus { get; set; } // e.g. "Paid", "Pending", "Failed"
        public string PaymentReference { get; set; } // Reference for the payment transaction
        public string Notes { get; set; } // Any additional notes for the order
        public string CouponCode { get; set; } // If any coupon was applied
        public decimal TotalAmount { get; set; } // Total amount for the order
        public string ShippingMethod { get; set; } // e.g. "Standard", "Express"
        public string ShippingCost { get; set; } // Cost of shipping
        public string TaxAmount { get; set; } // Tax amount applied to the order
        public string DiscountAmount { get; set; } // Any discount applied to the order
        public string PaymentGateway { get; set; } // e.g. "Stripe", "PayPal", "FakePayment"
        public string PaymentGatewayTransactionId { get; set; } // Transaction ID from the payment gateway
        public string OrderStatus { get; set; } // e.g. "Pending", "Processing", "Completed", "Cancelled"


        #endregion

        #region rich
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
