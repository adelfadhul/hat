namespace Hat.Domain.Models
{
    public class CartModel:IUserModel
    {
        #region data
        public Guid Id { get; set; }

        public Guid UserId { get; set; } // Optional, if you want to track the user who owns the cart
        public Guid CustomerId { get; set; }

        public string Address { get; set; } // Optional, if you want to track the delivery address for the cart

        #endregion 
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
        public decimal TotalPrice => CartItems.Sum(p => p.Price * p.Quantity);

     
    }
}
