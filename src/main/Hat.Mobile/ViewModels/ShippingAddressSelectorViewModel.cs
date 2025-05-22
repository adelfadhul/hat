using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Domain.Models;
using Hat.Domain.Store;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
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
        private readonly HttpClient _httpCleint;
        public ShippingAddressSelectorViewModel(IHttpClientFactory httpClientFactory)
        {
            _httpCleint = httpClientFactory.CreateClient("Default");
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

            var storedShippingAddresses = await _httpCleint.GetFromJsonAsync<List<ShippingAddressModel>>("/api/shipping-address");
            Addressess = storedShippingAddresses.Select(x => new ShippingAddressViewModel(x)).ToObservableCollection();
            IsLoaded = true;
        }
    }
}
