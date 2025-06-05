namespace Hat.Domain.Models
{
    public class ShippingAddressModel
    {

        #region data
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public string Address { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsInactive { get; set; }
        #endregion

        #region rich
        
        public Dictionary<string, string> Dictionary { get; set; } = new();
        #endregion
    }
}
