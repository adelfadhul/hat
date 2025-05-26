namespace Hat.Domain.Models
{
    public class CartModel
    {
        #region data
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        #endregion 
        public List<ShoppingCartItemModel> CartItems { get; set; } = new List<ShoppingCartItemModel>();
        public double TotalPrice => CartItems.Sum(p => p.Price * p.Qty);
    }
}
