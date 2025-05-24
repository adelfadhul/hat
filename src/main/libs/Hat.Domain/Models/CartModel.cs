namespace Hat.Domain.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<ShoppingCartItemModel> CartItems { get; set; } = new List<ShoppingCartItemModel>();
        public double TotalPrice => CartItems.Sum(p => p.Price * p.Qty);
    }
}
