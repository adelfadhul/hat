namespace Hat.Domain.Models
{
    public class DeliveryTypeModel
    {
        #region data
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsSelected { get; set; }

        #endregion

    }
}
