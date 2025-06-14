using Hat.Domain.Features.Order.ItemAddon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hat.Domain.Features.Order.Item
{
    public class OrderItemModel
    {

        #region data
        public Guid Id { get; set; }

        // Reference to product/variation
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? SKU { get; set; }

        // Pricing & Quantity
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }  // price before tax/addons
 

        // Tax, discount, and final total
        public decimal TaxAmount { get; set; } = 0m;
        public decimal DiscountAmount { get; set; } = 0m;

        #endregion

        #region rich

        public decimal Subtotal => UnitPrice * Quantity;
        public decimal LineTotal => Subtotal + TaxAmount - DiscountAmount;

        // Selected addons (if any)
        public List<OrderItemAddonModel> Addons { get; set; } = new();
        #endregion
    }

}
