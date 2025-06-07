namespace Hat.Domain.Models
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; } // Assuming this is a reference to the order
        public Guid ProductId { get; set; } // Assuming this is a reference to a product
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string Size { get; set; } // Assuming size is a string, could be an enum or other type based on your requirements
        public string ImageUrl { get; set; } // Assuming a single image URL for simplicity
    }
}
