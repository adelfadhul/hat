using Hat.Domain.Models;
using Hat.Mobile.ViewModels;

namespace Hat.DataViewModels
{
    public class ShippingAddressViewModel : BaseViewModel
    {
        public ShippingAddressViewModel()
        {

        }
        public ShippingAddressViewModel(ShippingAddressModel data)
        {
            Name = data.Name;
            Address = data.Address;
            IsPrimary = data.IsPrimary;
        }
        #region data
        public string Name { get; set; }
        public string Address { get; set; }

        public bool IsPrimary { get; set; }

        #endregion

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get => _IsSelected;
            set => SetProperty(ref _IsSelected, value);
        }
    }
}
