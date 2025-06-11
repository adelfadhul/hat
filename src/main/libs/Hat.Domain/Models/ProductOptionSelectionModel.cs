namespace Hat.Domain.Models
{
    public class ProductOptionSelectionModel
    {

        #region data1
        public Guid Id { get; set; }
        public Guid ProductOptionId { get; set; }
        public string Value { get; set; }     // e.g., "Too Hot", "Cold", "Mild"

        #endregion
    }
}
