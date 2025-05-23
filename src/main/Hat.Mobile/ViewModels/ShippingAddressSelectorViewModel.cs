using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.ViewModels
{
    public class ShippingAddressSelectorViewModel : BaseViewModel
    {
        private ObservableCollection<ShippingAddressViewModel> _Addressess = [];
        public ObservableCollection<ShippingAddressViewModel> Addressess
        {
            get => _Addressess;
            set => SetProperty(ref _Addressess, value);

        }
        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand SelectAddressCommand { get; }


        public ShippingAddressSelectorViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {
            SelectAddressCommand = new Command<ShippingAddressViewModel>(SelectAddress);
            _ = InitializeAsync();
        }

        private void SelectAddress(ShippingAddressViewModel address)
        {
            foreach (var add in Addressess)
            {
                if (add.AddressType == address.AddressType)
                {
                    add.IsSelected = true;
                }
                else
                {
                    add.IsSelected = false;
                }
            }
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }

        async Task PopulateDataAsync()
        {
            var storedShippingAddresses = await _dataService.GetShippingAddresses();
            Addressess = storedShippingAddresses.Select(x => new ShippingAddressViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
    }
}
