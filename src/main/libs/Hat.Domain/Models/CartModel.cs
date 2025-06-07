namespace Hat.Domain.Models
{
    public class CartModel
    {
        #region data
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        #endregion 
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
        public decimal TotalPrice => CartItems.Sum(p => p.Price * p.Qty);
    }
}
