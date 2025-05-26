namespace Hat.Infrastructure.Persistance.SqlServer.Entities
{
    public class CartEntity
    {
        #region data
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<ShoppingCartItemEntity> CartItems { get; set; } = new List<ShoppingCartItemEntity>();
        #endregion
    }
}
