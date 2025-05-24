using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ShippingAddressViewModel: BaseViewModel
    {
        public ShippingAddressViewModel()
        {

        }
        public ShippingAddressViewModel(ShippingAddressModel data)
        {
            AddressType = data.AddressType;
            FullAddress = data.FullAddress;
            StreetOne = data.StreetOne;
            StreetTwo = data.StreetTwo;
            City = data.City;
            State = data.State;
        }
        #region data
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        #endregion

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get => _IsSelected;
            set => SetProperty(ref _IsSelected, value);
        }
    }
}
