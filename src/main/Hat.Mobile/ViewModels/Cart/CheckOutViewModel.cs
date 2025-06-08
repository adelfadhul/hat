using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    public class CheckOutViewModel : BaseViewModel
    {
        private ObservableCollection<CartItemViewModel> _Products = [];
        public ObservableCollection<CartItemViewModel> Products
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
        private decimal _SubTotal = 0;
        public decimal SubTotal
        {
            get => _SubTotal;
            set => SetProperty(ref _SubTotal, value);
        }

        private decimal _Vat = 0;
        public decimal Vat
        {
            get => _Vat;
            set => SetProperty(ref _Vat, value);
        }

        public ICommand CheckoutCommand { get; }
        public ICommand ApplyVoucherCommand { get; }
        public ICommand BackCommand { get; }



        public CheckOutViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {
           

            CheckoutCommand = new Command(Checkout);
            ApplyVoucherCommand = new Command<string>(ApplyVoucher);
            BackCommand = new Command(GoBack);
            IsLoaded = true;

            _ = populteDataAsync();
        }

        private async Task populteDataAsync()
        {
            var cartItems = await _dataService.GetShoppingCartItems();
            Products = cartItems.Select(x => new CartItemViewModel(x)).ToObservableCollection();
            SubTotal = Products.Sum(item => item.Amount);
            Vat = Products.Sum(item => item.Vat);
            IsLoaded = true;
        }
        private async void Checkout()
        => await _navigationService.NavigateToDeliverySelectorType();
        private void ApplyVoucher(string vaucher)
        {

        }

        private async void GoBack(object obj)
        => await _navigationService.GoBack();
    }
}
