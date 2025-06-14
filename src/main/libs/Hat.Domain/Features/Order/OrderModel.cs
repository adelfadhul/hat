using Hat.Domain.Enums;
using Hat.Domain.Features.Order.Address;
using Hat.Domain.Features.Order.Item;

namespace Hat.Domain.Features.Order
{
    public class Order
    {
        #region data
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }
       
        public string PaymentMethod { get; set; } = "Unknown"; // e.g., "CreditCard", "Tap"
        public bool IsPaid { get; set; }

        #endregion

        #region rich
        public AddressModel BillingAddress { get; set; }
        public AddressModel ShippingAddress { get; set; }

        public decimal Total => Subtotal + Tax + ShippingCost - Discount;

        public ICollection<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();
        #endregion
    }

}
