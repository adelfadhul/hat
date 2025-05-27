namespace Hat.Domain.Models
{
    public class ShippingAddressModel
    {

        #region data
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public bool IsPrimary { get; set; }
        #endregion
    }
}
