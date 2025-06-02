using CommunityToolkit.Maui.Core.Extensions;
using Hat.DataViewModels;
using Hat.Mobile.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hat.Mobile.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
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
        private decimal _SubTotal = 0;
        public decimal SubTotal
        {
            get => _SubTotal;
            set => SetProperty(ref _SubTotal, value);
        }

        public ICommand DeleteCommand { get; }
        public ICommand FavoriteCommand { get; }
        public ICommand QtyChangeCommand { get; }
        public ICommand CheckoutCommand { get; }




        public ShoppingCartViewModel(NavigationService navigationService, DataService dataService):base(navigationService,dataService)
        {
          
            DeleteCommand = new Command<ProductViewModel>(DeleteProduct);
            FavoriteCommand = new Command<ProductViewModel>(FavoriteProduct);
            QtyChangeCommand = new Command<ProductViewModel>(ChangeProductQty);
            CheckoutCommand = new Command(Checkout);
            _=  PopulateDataAsync();
            _ = InitializeAsync();
        }      

        private async Task InitializeAsync()
        {
            await PopulateDataAsync();
        }
        public async Task PopulateDataAsync()
        {

            var storedProducts = await _dataService.GetShoppingCartItems();
           
            Products = storedProducts.Select(x=> new ShoppingCartItemViewModel(x)).ToObservableCollection();
            SubTotal = Products.Sum(item => (decimal)item.Qty * item.Price);
            IsLoaded = true;
        }
        private async void DeleteProduct(ProductViewModel product)
        {
            
        }
        private async void FavoriteProduct(ProductViewModel product)
        {

        }
        private void ChangeProductQty(ProductViewModel product)
        {
            SubTotal = Products.Sum(item => (decimal)item.Qty * item.Price);
        }
        private async void Checkout()
        => await _navigationService.NavigateToCheckOut();
    }
}
