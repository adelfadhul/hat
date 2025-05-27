namespace Hat.Domain.Models
{
    public class ShippingAddressModel
    {

        #region data
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public bool IsPrimary { get; set; }
        #endregion
    }
}
