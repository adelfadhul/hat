using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Hat.Mobile.ViewModels
{
    public class ShoppingCartCalculationViewModel : BaseViewModel
    {
        private ObservableCollection<ShoppingCartItemViewModel> _Products = [];
        public ObservableCollection<ShoppingCartItemViewModel> Products
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
        private double _SubTotal = 0;
        public double SubTotal
        {
            get => _SubTotal;
            set => SetProperty(ref _SubTotal, value);
        }
        public ICommand CheckoutCommand { get; }
        public ICommand ApplyVoucherCommand { get; }
        public ICommand BackCommand { get; }



        public ShoppingCartCalculationViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {
            Products = new();
            SubTotal = Products.Sum(item => item.Qty * item.Price);
            CheckoutCommand = new Command(Checkout);
            ApplyVoucherCommand = new Command<string>(ApplyVoucher);
            BackCommand = new Command(GoBack);
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
