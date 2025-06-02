namespace Hat.Domain.Models
{
    public class InventoryModel
    {
        #region data
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } 
        public string SKU { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        #endregion

       
    }
}
