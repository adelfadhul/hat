namespace Hat.Domain.Features.Order.ItemAddon
{
    public class OrderItemAddonModel
    {
        public Guid OrderItemId { get; set; }
        public Guid AddonId { get; set; }

        public string Value { get; set; } = string.Empty; // selected value or quantity
        public decimal CalculatedPrice { get; set; } // e.g., AdditionalPrice * Quantity
    }
}
