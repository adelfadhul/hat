namespace Hat.Domain.Models
{
    public class InventoryModel
    {
        #region data
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } 
        public string SKU { get; set; }
        public string ProductSize { get; set; }
        public string Description { get; set; }
        public string ProductColor { get; set; }
        public string Location { get; set; }
        public bool IsSold { get; set; }

        #endregion


    }
}
