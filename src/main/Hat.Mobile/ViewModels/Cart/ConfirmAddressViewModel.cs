using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class ConfirmAddressViewModel : BaseViewModel
    {
        private DeliveryTypeViewModel _DeliveryType;
        public DeliveryTypeViewModel DeliveryType
        {
            get => _DeliveryType;
            set => SetProperty(ref _DeliveryType, value);
        }

        private ShippingAddressViewModel _PrimaryAddress;
        public ShippingAddressViewModel PrimaryAddress
        {
            get => _PrimaryAddress;
            set => SetProperty(ref _PrimaryAddress, value);
        }

        private ObservableCollection<ProductViewModel> _Products = [];
        public ObservableCollection<ProductViewModel> Products
        {
            get => _Products;
            set => SetProperty(ref _Products, value);
        }

        private bool _IsLoaded = false;
        public bool IsLoaded
        {
            get => _IsLoaded;
            set => SetProperty(ref _IsLoaded, value);
        }
        public ICommand NextCommand { get; }
        public ICommand BackCommand { get; }

        public ConfirmAddressViewModel(NavigationService navigationService,DataService dataService):base(navigationService,dataService)
        {
  
            Products = new();
            NextCommand = new Command(ConfirmAddress);
            BackCommand = new Command(GoBack);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        async Task PopulateDataAsync()
        {
            var primaryShippingAddress = await _dataService.GetPrimaryAddress();
            PrimaryAddress = new ShippingAddressViewModel(primaryShippingAddress);
            IsLoaded =true;
        }

        private async void ConfirmAddress()
        {
            await _navigationService.NavigateToConfirmPyment();
           // await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PushAsync(_confirmPaymentView);
        }

        private async void GoBack(object obj)
        {
            await _navigationService.GoBack();  
            // await Microsoft.Maui.Controls.Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
