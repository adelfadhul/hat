using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class CartManagerViewModel : BaseViewModel
    {
        private CartViewModel? _Cart;
        public CartViewModel? Cart
        {
            get => _Cart;
            set => SetProperty(ref _Cart, value);
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

        private bool isCartFound = false;
        public bool IsCartFound
        {
            get => isCartFound;
            set => SetProperty(ref isCartFound, value);
        }
        public ICommand DeleteCommand { get; }
        public ICommand FavoriteCommand { get; }
        public ICommand QtyChangeCommand { get; }
        public ICommand CheckoutCommand { get; }




        public CartManagerViewModel(NavigationService navigationService, DataService dataService) : base(navigationService, dataService)
        {

            DeleteCommand = new Command<ProductViewModel>(DeleteProduct);
            FavoriteCommand = new Command<ProductViewModel>(FavoriteProduct);
            QtyChangeCommand = new Command<ProductViewModel>(ChangeProductQty);
            CheckoutCommand = new Command(Checkout);
            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        public async Task PopulateDataAsync()
        {

            var storedUserCart = await _dataService.GetUserCart();

            if (storedUserCart is not null)
            {
                Cart = new CartViewModel(storedUserCart);
                SubTotal = storedUserCart.TotalPrice;
                IsCartFound = true;
            }

            IsLoaded = true;
        }
        private void DeleteProduct(ProductViewModel product)
        {

        }
        private void FavoriteProduct(ProductViewModel product)
        {

        }
        private void ChangeProductQty(ProductViewModel product)
        {
            SubTotal = Cart.CartItems.Sum(item => (decimal)item.Qty * item.Price);
        }
        private async void Checkout()
        => await _navigationService.NavigateToCheckOut();
    }
}
